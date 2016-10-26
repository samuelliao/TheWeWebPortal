using NLog;
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
        private Logger Log;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Log == null)
            {
                Log = NLog.LogManager.GetCurrentClassLogger();
            }
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.StoreString;
                    InitialLangList();
                    InitialCountryList();
                    InitialCurrency();
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
        private void InitialCurrency()
        {
            ddlCurrency.Items.Clear();
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Currency Where IsDelete = 0");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ddlCurrency.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }
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
                string sqlTxt = "SELECT s.[Id],s.Sn,s.CountryId,s.AreaId,s.Code"
                    + ",s.Name,s.CnName,s.EngName,s.JpName,s.Addr,s.Description"
                    + ",s.IsDelete,s.UpdateAccId,s.UpdateTime,e.Name as EmployeeName"
                    + ", s.HoldingCompany, s.GradeLv, s.Currency"
                    + " FROM [dbo].[Store] as s"
                    + " left join Employee as e on e.Id = s.UpdateAccId"
                    + " left join Country as c on c.Id = s.CountryId"
                    + " left join Area as a on a.Id = s.AreaId"
                    + " WHERE s.IsDelete = 0 " + condString + " " + sortString;
                DS = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
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
                Log.Error(ex.Message);
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
                DropDownList ddl4 = (DropDownList)dgStore.Items[dgStore.EditItemIndex].FindControl("ddlDgCurrency");
                List<DbSearchObject> updateLst = new List<DbSearchObject>();
                updateLst.Add(new DbSearchObject("Code", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[3].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[4].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[5].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[6].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Addr", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[7].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Description", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[12].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl1.SelectedValue));
                updateLst.Add(new DbSearchObject("HoldingCompany", AtrrTypeItem.Bit, AttrSymbolItem.Equal, (ddl3.SelectedValue == "0" ? "1" : "0")));
                updateLst.Add(new DbSearchObject("GradeLv", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl3.SelectedValue));
                updateLst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl2.SelectedValue));
                updateLst.Add(new DbSearchObject("Currency", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl4.SelectedValue));
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
                Log.Error(ex.Message);
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

                    DropDownList ddlCur = (DropDownList)e.Item.FindControl("ddlDgCurrency");
                    foreach(ListItem item in ddlCurrency.Items)
                    {
                        ddlCur.Items.Add(new ListItem(item.Text, item.Value));
                    }
                    ddlCur.SelectedValue = dataItem1["Currency"].ToString();
                }
                else
                {
                    Label label = (Label)e.Item.FindControl("labelDgCountry");
                    label.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), SysProperty.GetCountryById(dataItem1["CountryId"].ToString()));
                    Label labe2 = (Label)e.Item.FindControl("labelDgArea");
                    labe2.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), SysProperty.GetAreaById(dataItem1["AreaId"].ToString()));
                    ((Label)e.Item.FindControl("labelDgHoldingCompany")).Text = dataItem1["GradeLv"].ToString();
                    ((Label)e.Item.FindControl("labelDgCurrency")).Text = ddlCurrency.Items.FindByValue(dataItem1["Currency"].ToString()).Text;
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
            ddlArea.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)
                  || string.IsNullOrEmpty(ddlCountry.SelectedValue)
                  || string.IsNullOrEmpty(ddlArea.SelectedValue)
                  || string.IsNullOrEmpty(ddlLv.SelectedValue))
            {
                ShowErrorMsg(Resources.Resource.FieldEmptyString);
                return;
            }

            List<DbSearchObject> lst = CreateDbObject(true);
            try
            {
                bool result = WriteBackData(MsSqlTable.Store, true, lst, string.Empty);
                if (!result) return;
                string storeId = GetCreatedObjectId(MsSqlTable.Store, lst);
                if (string.IsNullOrEmpty(storeId)) return;
                lst = PermissionDbObject(tbName.Text, storeId);
                result = WriteBackData(MsSqlTable.Permission, true, lst, string.Empty);
                if (!result) return;
                string permissionId = GetCreatedObjectId(MsSqlTable.Permission, lst);
                if (string.IsNullOrEmpty(permissionId)) return;
                result = WriteBackPermissionItem(true, PermissionItemListFromTable(true, permissionId), permissionId);
                if (result)
                {
                    BindData(string.Empty);
                    btnClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dgStore.CurrentPageIndex = 0;
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

        #region Db instance
        private List<DbSearchObject> CreateDbObject(bool isCreate)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbName.Text)
                );
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            if (isCreate)
            {
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            }
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
            lst.Add(new DbSearchObject(
                "Code"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbStoreCode.Text)
                );
            lst.Add(new DbSearchObject(
                "Currency"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCurrency.SelectedValue)
                );

            lst.Add(new DbSearchObject("HoldingCompany", AtrrTypeItem.Bit, AttrSymbolItem.Equal, (ddlLv.SelectedValue == "0" ? "1" : "0")));
            lst.Add(new DbSearchObject("GradeLv", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlLv.SelectedValue));
            return lst;
        }
        private List<DbSearchObject> PermissionDbObject(string name, string storeId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , name)
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
            "CreatedateAccId"
            , AtrrTypeItem.String
            , AttrSymbolItem.Equal
            , ((DataRow)Session["AccountInfo"])["Id"].ToString()
            ));
            lst.Add(new DbSearchObject(
                "ObjectId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , storeId)
                );
            lst.Add(new DbSearchObject(
                "Type"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "Operation")
                );
            lst.Add(new DbSearchObject(
                "IsDelete"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , "0"));
            return lst;
        }
        private List<List<DbSearchObject>> PermissionItemListFromTable(bool isCreate, string newId)
        {
            int functionTypeCnt = 3;
            List<List<DbSearchObject>> root = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            DbSearchObject obj = new DbSearchObject();
            string sql = "SELECT * FROM [dbo].[FunctionItem] Where IsDelete = 0 And Type > 0 Order by Type";
            DataSet funDS = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(funDS)) return null;
            foreach (DataRow dr in funDS.Tables[0].Rows)
            {
                lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject(
                    "ObjectId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , dr["Id"].ToString()));
                lst.Add(new DbSearchObject(
                    "PermissionId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , newId));
                lst.Add(new DbSearchObject(
                    "CanEntry"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , (int.Parse(dr["Type"].ToString()) <= functionTypeCnt ? "1" : "0")));
                lst.Add(new DbSearchObject(
                    "CanCreate"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , (int.Parse(dr["Type"].ToString()) <= functionTypeCnt ? "1" : "0")));
                lst.Add(new DbSearchObject(
                    "CanModify"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , (int.Parse(dr["Type"].ToString()) <= functionTypeCnt ? "1" : "0")));
                lst.Add(new DbSearchObject(
                    "CanDelete"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , (int.Parse(dr["Type"].ToString()) <= functionTypeCnt ? "1" : "0")));
                lst.Add(new DbSearchObject(
                    "CanExport"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , (int.Parse(dr["Type"].ToString()) <= functionTypeCnt ? "1" : "0")));
                lst.Add(new DbSearchObject(
                    "Type"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , "Operation"));
                lst.Add(new DbSearchObject(
                    "ObjectSn"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , dr["Type"].ToString()));
                lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
                lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
                root.Add(lst);
            }
            return root;
        }
        #endregion
        #region Data Control
        #region Read Related
        private void GetPermissionList(string sortString)
        {
            try
            {
                string sqlTxt = "SELECT p.[Id],p.Name,p.Description,p.ObjectId"
                    + ",p.Type,p.[IsDelete],p.[UpdateAccId],p.[UpdateTime]"
                    + ",e.Name as EmloyeeName,s." + new ResourceUtil().OutputLangNameToAttrName(((string)Session["CultureCode"]))
                    + " as StoreName,s.Sn as StoreSn"
                    + " FROM [dbo].[Permission] as p"
                    + " left join Store as s on s.Id = p.ObjectId"
                    + " left join Employee as e on e.Id = p.UpdateAccId"
                    + " Where p.IsDelete = 0 And p.Type = 'Operation' " + sortString;
                DS = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                DS = null;
                ShowErrorMsg(ex.Message);
            }
        }

        private DataSet GetFunctionList()
        {
            try
            {
                string sql = "SELECT [Id],[Name],[Type]"
                    + " FROM  [dbo].[FunctionItem]"
                    + " where IsDelete = 0 And Type != 0"
                    + " Order by Type";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetPermissionItemByPermissionId(string permissionId)
        {
            try
            {
                string sql = "select * from PermissionItem "
                    + "where PermissionId = '" + permissionId + "' "
                    + " And IsDelete=0  Order by ObjectSn";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetStoreList()
        {
            try
            {
                string sql = "";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        #endregion
        #region Write Related
        private bool WriteBackData(MsSqlTable table, bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(table)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                    : (SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryUpdateConverter(lst)
                        , " Where Id = '" + id + "'"));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        private string GetCreatedObjectId(MsSqlTable table, List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(table)
                    , SysProperty.Util.SqlQueryConditionConverter(lst)).Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return string.Empty;
            }
        }

        private bool WriteBackPermissionItem(bool isInsert, List<List<DbSearchObject>> lst, string permissionId)
        {
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                try
                {
                    result = result |
                        (isInsert ? SysProperty.GenDbCon.InsertDataInToTable
                        (SysProperty.Util.MsSqlTableConverter(MsSqlTable.PermissionItem)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(item)
                        , SysProperty.Util.SqlQueryInsertValueConverter(item))
                        : (SysProperty.GenDbCon.UpdateDataIntoTable
                        (SysProperty.Util.MsSqlTableConverter(MsSqlTable.PermissionItem)
                        , SysProperty.Util.SqlQueryUpdateConverter(item)
                        , " Where PermissionId = '" + permissionId
                        + "' And ObjectId='" + item[0].AttrValue + "'")));
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    result = false;
                }
            }
            return result;
        }
        #endregion
        #endregion

        private DataSet GetDataFromDb(string sql)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }
    }
}