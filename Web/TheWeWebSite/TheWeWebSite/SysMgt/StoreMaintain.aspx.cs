using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.SysMgt
{
    public partial class StoreMaintain : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.StoreString;
                    InitialLangList();
                    InitialCountryList();
                    InitialStoreLvList();
                    InitialAreaList(string.Empty);
                    InitialControlWithPermission();
                    BindData(string.Empty);
                }
            }
        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            dgStore.Columns[dgStore.Columns.Count - 1].Visible = item.CanDelete;
            dgStore.Columns[dgStore.Columns.Count - 2].Visible = item.CanModify;
        }
        #region DropDownList Control
        private void InitialAreaList(string countryId)
        {
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));

            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Area "
                + "where IsDelete = 0 "
                + (string.IsNullOrEmpty(countryId) ? string.Empty : "and CountryId = '" + countryId + "'"));
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlArea.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
        }
        private void InitialStoreLvList()
        {
            ddlLv.Items.Clear();
            ddlLv.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            ddlLv.Items.Add(new ListItem("0", "0"));
            ddlLv.Items.Add(new ListItem("1", "1"));
            ddlLv.Items.Add(new ListItem("2", "2"));
        }

        private void InitialCountryList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty));

            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Country where IsDelete = 0");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
        }

        private void InitialLangList()
        {
            ddlLang.Items.Clear();
            ddlLang.Items.Add(new ListItem(Resources.Resource.TraditionalChineseString, "zh-TW"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.SimplifiedChineseString, "zh-CN"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.EnglishString, "en"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.JapaneseString, "ja-JP"));
            ddlLang.SelectedIndex = new ResourceUtil().OutputLangNameNumber(((string)Session["CultureCode"]));
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitialAreaList(ddlCountry.SelectedValue);
        }
        #endregion

        private void GetStoreList(string condString, string sortString)
        {
            try
            {
                string sqlTxt = "SELECT s.[Id],s.Sn,s.CountryId,s.AreaId"
                    + ",s.Name,s.CnName,s.EngName,s.JpName,s.Addr,s.Description"
                    + ",s.IsDelete,s.UpdateAccId,s.UpdateTime,e.Name as EmployeeName"
                    + ",c." + new ResourceUtil().OutputLangNameToAttrName(((string)Session["CultureCode"]))
                    + " as CountryName"
                    + ",a." + new ResourceUtil().OutputLangNameToAttrName(((string)Session["CultureCode"]))
                    + " as AreaName"
                    + ", s.HoldingCompany, s.GradeLv"
                    + " FROM[TheWe].[dbo].[Store] as s"
                    + " left join Employee as e on e.Id = s.UpdateAccId"
                    + " left join Country as c on c.Id = s.CountryId"
                    + " left join Area as a on a.Id = s.AreaId"
                    + " WHERE s.IsDelete = 0 " + condString + " " + sortString;
                DS = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;
            }
        }

        private void BindData(string condStr)
        {
            GetStoreList(condStr, string.Empty);
            dgStore.DataSource = DS;
            dgStore.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dgStore.DataBind();
        }

        #region DataSet Control
        protected void dgStore_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgStore.EditItemIndex = -1;
            BindData(string.Empty);
        }

        protected void dgStore_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string id = dgStore.DataKeys[(int)e.Item.ItemIndex].ToString();
                string sqlTxt = "UPDATE [dbo].[Store] SET IsDelete = 1"
                    + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                    + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                    + " Where Id = '" + id + "'";
                if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
                {
                    BindData(ConditionString(true, "s"));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgStore_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgStore.EditItemIndex = e.Item.ItemIndex;
            BindData(ConditionString(true, "s"));
        }

        protected void dgStore_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                DropDownList ddl1 = (DropDownList)dgStore.Items[dgStore.EditItemIndex].FindControl("ddlDgCountry");
                DropDownList ddl2 = (DropDownList)dgStore.Items[dgStore.EditItemIndex].FindControl("ddlDgArea");
                DropDownList ddl3 = (DropDownList)dgStore.Items[dgStore.EditItemIndex].FindControl("ddlDgHoldingCompany");
                List<DbSearchObject> updateLst = new List<DbSearchObject>();
                updateLst.Add(new DbSearchObject("Sn", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[3].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[4].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[5].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Addr", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[6].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Description", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[10].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl1.SelectedValue));
                updateLst.Add(new DbSearchObject("HoldingCompany", AtrrTypeItem.Bit, AttrSymbolItem.Equal, (ddl3.SelectedValue == "0" ? "1" : "0")));
                updateLst.Add(new DbSearchObject("GradeLv", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl3.SelectedValue));
                updateLst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl2.SelectedValue));
                updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
                updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgStore.DataKeys[dgStore.EditItemIndex].ToString() + "'"))
                {
                    dgStore.EditItemIndex = -1;
                    BindData(ConditionString(true, "s"));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgStore_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgStore.CurrentPageIndex = e.NewPageIndex;
            BindData(ConditionString(true, "s"));
        }

        protected void dgStore_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlDgCountry");
                    dropDownList1.Items.Clear();
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                        , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country)
                        , " Where IsDelete = 0");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dropDownList1.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            , dr["Id"].ToString()));
                    }
                    dropDownList1.SelectedValue = dataItem1["CountryId"].ToString();

                    DropDownList dropDownList2 = (DropDownList)e.Item.FindControl("ddlDgArea");
                    dropDownList2.Items.Clear();
                    ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                        , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                        , " Where IsDelete = 0"
                        + (string.IsNullOrEmpty(dropDownList1.SelectedValue)
                        ? string.Empty
                        : " and CountryId = '" + dropDownList1.SelectedValue + "'"));
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dropDownList2.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            , dr["Id"].ToString()));
                    }
                    dropDownList2.SelectedValue = dataItem1["AreaId"].ToString();

                    DropDownList ddlLv = ((DropDownList)e.Item.FindControl("ddlDgHoldingCompany"));
                    ddlLv.Items.Add(new ListItem("0", "0"));
                    ddlLv.Items.Add(new ListItem("1", "1"));
                    ddlLv.Items.Add(new ListItem("2", "2"));
                    ddlLv.SelectedValue = dataItem1["GradeLv"].ToString();
                }
                else
                {
                    Label label = (Label)e.Item.FindControl("labelDgCountry");
                    label.Text = dataItem1["CountryName"].ToString();
                    Label labe2 = (Label)e.Item.FindControl("labelDgArea");
                    labe2.Text = dataItem1["AreaName"].ToString();
                    ((Label)e.Item.FindControl("labelDgHoldingCompany")).Text = dataItem1["GradeLv"].ToString();
                }
            }
        }

        protected void ddlDgCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string countryId = (sender as DropDownList).SelectedValue;
            DropDownList ddl = (DropDownList)dgStore.Items[dgStore.EditItemIndex].FindControl("ddlDgArea");
            ddl.Items.Clear();
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                , " Where IsDelete = 0"
                + (string.IsNullOrEmpty(countryId) ? string.Empty : " And CountryId='" + countryId + "'"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddl.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString()));
            }
        }

        protected void dgStore_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetStoreList(ConditionString(true, "s")
                    , "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dgStore.DataSource = DS;
                dgStore.DataBind();
            }
        }
        #endregion

        #region Button Control
        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            tbAdress.Text = string.Empty;
            tbRemark.Text = string.Empty;
            tbSn.Text = string.Empty;
            ddlArea.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)
                  || string.IsNullOrEmpty(ddlCountry.SelectedValue)
                  || string.IsNullOrEmpty(ddlArea.SelectedValue)
                  || string.IsNullOrEmpty(tbSn.Text)
                  || string.IsNullOrEmpty(ddlLv.SelectedValue))
            {
                return;
            }

            List<DbSearchObject> lst = CreateDbObject();
            try
            {
                if (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                {
                    BindData(string.Empty);
                    btnClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(ConditionString(true, "s"));
        }
        #endregion

        private string ConditionString(bool needSymbol, string tableSymbol)
        {
            string otherConditionString = string.Empty;
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                otherConditionString += " And "
                    + (needSymbol ? (tableSymbol + ".") : string.Empty)
                    + new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
                    + " like '%" + tbName.Text + "%'";
            }

            if (!string.IsNullOrEmpty(tbAdress.Text))
            {
                otherConditionString += " And "
                    + (needSymbol ? (tableSymbol + ".") : string.Empty)
                    + "Addr like '%" + tbAdress.Text + "%'";
            }

            if (!string.IsNullOrEmpty(tbSn.Text))
            {
                otherConditionString += " And "
                    + (needSymbol ? (tableSymbol + ".") : string.Empty)
                    + "Sn like '%" + tbSn.Text + "%'";
            }

            otherConditionString += (string.IsNullOrEmpty(ddlCountry.SelectedValue)
                ? string.Empty
                : " And "
                + (needSymbol ? (tableSymbol + ".") : string.Empty)
                + "CountryId = '" + ddlCountry.SelectedValue + "'");
            otherConditionString += (string.IsNullOrEmpty(ddlArea.SelectedValue)
                ? string.Empty
                : " And "
                + (needSymbol ? (tableSymbol + ".") : string.Empty)
                + "AreaId = '" + ddlArea.SelectedValue + "'");

            return otherConditionString;
        }

        private List<DbSearchObject> CreateDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbName.Text)
                );
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                );
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCountry.SelectedValue)
                );
            lst.Add(new DbSearchObject(
                "AreaId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlArea.SelectedValue)
                );
            lst.Add(new DbSearchObject(
                "Addr"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbAdress.Text)
                );
            lst.Add(new DbSearchObject(
                "Description"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRemark.Text)
                );

            lst.Add(new DbSearchObject("HoldingCompany", AtrrTypeItem.Bit, AttrSymbolItem.Equal, (ddlLv.SelectedValue == "0" ? "1" : "0")));
            lst.Add(new DbSearchObject("GradeLv", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlLv.SelectedValue));
            return lst;
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }
    }
}