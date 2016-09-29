using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.BuyMgt
{
    public partial class BuyAutoPassMgt : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.BuyAutoPassMgtString;
                    InitialControls();
                    InitialControlWithPermission();
                    BindData();
                }
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }

        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            dgMethod.Columns[dgMethod.Columns.Count - 1].Visible = item.CanDelete;
            dgMethod.Columns[dgMethod.Columns.Count - 2].Visible = item.CanModify;
        }

        private void InitialControls()
        {
            InitialCurrency();
            CategoryList();
            TypeList(ddlCategory.SelectedValue);
            TypeTemplateList();
        }

        protected void LimitEnable_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = false;
            enable = LimitEnable.Checked;
            tbNumberLimit.Enabled = enable;
            tbAmount.Enabled = enable;
            ddlCurrency.Enabled = enable;
        }

        #region DropDownList Control
        private void InitialCurrency()
        {
            ddlCurrency.Items.Clear();
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Currency Where IsDelete = 0");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCurrency.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }
        }
        private void CategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataFromDb("Select * From BuyStuffCategory Where IsDelete = 0 And Lv = 0");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void TypeList(string categoryId)
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string cond = string.IsNullOrEmpty(categoryId) ? string.Empty : " And ParentId = '" + categoryId + "'";
            DataSet ds = GetDataFromDb("Select * From BuyStuffCategory Where IsDelete = 0 And Lv = 1" + cond);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlType.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString() + ";" + dr["ParentId"].ToString()));
            }
        }

        private void TypeTemplateList()
        {
            ddlTypeTemplate.Items.Clear();
            DataSet ds = GetDataFromDb("Select * From BuyStuffCategory Where IsDelete = 0 And Lv = 1");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlTypeTemplate.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeList(ddlCategory.SelectedValue);
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                string[] strs = ddlType.SelectedValue.Split(';');
                ddlCategory.SelectedValue = strs[1];
            }
        }
        #endregion

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (WriteBackData(MsSqlTable.BuyAutoPass, true, BuyCertDbObject(), string.Empty))
            {
                btnClear_Click(sender, e);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            tbRemark.Text = string.Empty;
            tbAmount.Text = "0";
            tbNumberLimit.Text = "0";
            ddlCategory.SelectedIndex = 0;
            ddlType.SelectedIndex = 0;
            LimitEnable.Checked = false;
            LimitEnable_CheckedChanged(LimitEnable, new EventArgs());
        }

        #region DataGrid Control
        protected void dgMethod_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string id = dgMethod.DataKeys[(int)e.Item.ItemIndex].ToString();
                string sqlTxt = "UPDATE [dbo].[BuyAutoPass] SET IsDelete = 1"
                    + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                    + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                    + " Where Id = '" + id + "'";
                if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
                {
                    GetBuyRequest(string.Empty, string.Empty);
                    BindData();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgMethod_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgMethod.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void dgMethod_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgMethod.EditItemIndex = -1;
            BindData();
        }

        protected void dgMethod_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                DropDownList ddl1 = (DropDownList)dgMethod.Items[dgMethod.EditItemIndex].FindControl("ddlCategory");
                DropDownList ddl2 = (DropDownList)dgMethod.Items[dgMethod.EditItemIndex].FindControl("ddlType");
                DropDownList ddl3 = (DropDownList)dgMethod.Items[dgMethod.EditItemIndex].FindControl("ddlCurrency");
                List<DbSearchObject> updateLst = new List<DbSearchObject>();
                string price = ((TextBox)e.Item.FindControl("dgTbPrcie")).Text;
                string number = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
                updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("PriceLimit", AtrrTypeItem.String, AttrSymbolItem.Equal, price));
                updateLst.Add(new DbSearchObject("NumberLimit", AtrrTypeItem.String, AttrSymbolItem.Equal, number));
                updateLst.Add(new DbSearchObject("Remark", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[6].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Category", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl1.SelectedValue));
                if (!string.IsNullOrEmpty(ddlType.SelectedValue))
                {
                    updateLst.Add(new DbSearchObject("Type", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl2.SelectedValue));
                }
                updateLst.Add(new DbSearchObject("NeedLimit", AtrrTypeItem.Bit, AttrSymbolItem.Equal, ((float.Parse(price) <= 0 && int.Parse(number) <= 0) ? "1" : "0")));
                updateLst.Add(new DbSearchObject("Currency", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl3.SelectedValue));
                updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
                updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyAutoPass)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgMethod.DataKeys[dgMethod.EditItemIndex].ToString() + "'"))
                {
                    dgMethod.EditItemIndex = -1;
                    GetBuyRequest(string.Empty, " Order by UpdateTime");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgMethod_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgMethod.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dgMethod_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetBuyRequest(string.Empty
                    , "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dgMethod.DataSource = DS;
                dgMethod.DataBind();
            }
        }

        protected void dgMethod_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlCategory");
                    dropDownList1.Items.Clear();
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                        , SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStuffCategory)
                        , " Where IsDelete = 0");
                    foreach (DataRow dr in ds.Tables[0].Select("Lv = 0"))
                    {
                        dropDownList1.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            , dr["Id"].ToString()));
                    }
                    dropDownList1.SelectedValue = dataItem1["Category"].ToString();

                    DropDownList dropDownList2 = (DropDownList)e.Item.FindControl("ddlType");
                    dropDownList2.Items.Clear();
                    dropDownList2.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
                    foreach (DataRow dr in ds.Tables[0].Select("Lv = 1"))
                    {
                        dropDownList2.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            , dr["Id"].ToString() + ";" + dr["ParentId"].ToString()));
                    }
                    dropDownList2.SelectedValue = dataItem1["Type"] == null ? string.Empty : dataItem1["Type"].ToString();

                    DropDownList ddlCur = (DropDownList)e.Item.FindControl("ddlCurrency");
                    foreach (ListItem item in ddlCurrency.Items)
                    {
                        ddlCur.Items.Add(new ListItem(item.Text, item.Value));
                    }
                    ddlCur.SelectedValue = dataItem1["Currency"].ToString();

                    ((TextBox)e.Item.FindControl("dgTbPrcie")).Text = dataItem1["Price"].ToString();
                }
                else
                {
                    ((Label)e.Item.FindControl("labelCategory")).Text = ddlCategory.Items.FindByValue(dataItem1["Category"].ToString()).Text;
                    if (!string.IsNullOrEmpty(dataItem1["Type"].ToString()))
                    {
                        ((Label)e.Item.FindControl("labelType")).Text = ddlTypeTemplate.Items.FindByValue(dataItem1["Type"].ToString()).Text;
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("labelType")).Text = string.Empty;
                    }
                    ((Label)e.Item.FindControl("dgLabelPrice")).Text = ddlCurrency.Items.FindByValue(dataItem1["CurrencyId"].ToString()).Text + " " + SysProperty.Util.ParseMoney(dataItem1["PriceLimit"].ToString()).ToString("#0.00");
                }
            }
        }

        protected void ddlCategory_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string category = (sender as DropDownList).SelectedValue;
            DropDownList ddl = (DropDownList)dgMethod.Items[dgMethod.EditItemIndex].FindControl("ddlType");
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                , SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStuffCategory)
                , " Where IsDelete = 0 and Lv = 1"
                + (string.IsNullOrEmpty(category) ? string.Empty : " And ParentId='" + category + "'"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddl.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString() + ";" + dr["ParentId"].ToString()));
            }
        }

        protected void ddlType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string[] strs = (sender as DropDownList).SelectedValue.Split(';');
            DropDownList ddl = (DropDownList)dgMethod.Items[dgMethod.EditItemIndex].FindControl("ddlCategory");
            ddl.SelectedValue = strs[1];
        }
        #endregion

        private void GetBuyRequest(string condStr, string sortStr)
        {
            string sql = "Select * From BuyRequest Where IsDelete = 0 " + condStr + " " + sortStr;
            DS = GetDataFromDb(sql);
        }

        private void BindData()
        {
            if (SysProperty.Util.IsDataSetEmpty(DS))
            {
                GetBuyRequest(string.Empty, string.Empty);
            }
            dgMethod.DataSource = DS;
            dgMethod.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dgMethod.DataBind();
        }

        private DataSet GetDataFromDb(string sql)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

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
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        private List<DbSearchObject> BuyCertDbObject()
        {
            List<DbSearchObject> updateLst = new List<DbSearchObject>();
            string price = tbAmount.Text;
            string number = tbNumberLimit.Text;
            updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, tbName.Text));
            updateLst.Add(new DbSearchObject("PriceLimit", AtrrTypeItem.String, AttrSymbolItem.Equal, price));
            updateLst.Add(new DbSearchObject("NumberLimit", AtrrTypeItem.String, AttrSymbolItem.Equal, number));
            updateLst.Add(new DbSearchObject("Remark", AtrrTypeItem.String, AttrSymbolItem.Equal, tbRemark.Text));
            updateLst.Add(new DbSearchObject("Category", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlCategory.SelectedValue));
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                updateLst.Add(new DbSearchObject("Type", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlType.SelectedValue));
            }
            updateLst.Add(new DbSearchObject("CurrencyId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlCurrency.SelectedValue));
            updateLst.Add(new DbSearchObject("NeedLimit", AtrrTypeItem.Bit, AttrSymbolItem.Equal, ((float.Parse(price) <= 0 && int.Parse(number) <= 0) ? "1" : "0")));
            updateLst.Add(new DbSearchObject("CreatedateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            updateLst.Add(new DbSearchObject("CreatedateTie", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.DateTime, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            updateLst.Add(new DbSearchObject("AutoPass", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "1"));
            return updateLst;
        }
    }
}