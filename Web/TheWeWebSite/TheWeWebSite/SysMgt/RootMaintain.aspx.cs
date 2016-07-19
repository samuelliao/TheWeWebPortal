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
    public partial class RootMaintain : System.Web.UI.Page
    {
        private DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.PermissionCategoryString;
                    InitialStore();
                    InitialPermissionTable();
                    BindData();
                }
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }
        #region Initial
        private void InitialStore()
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SelectStoreString, string.Empty));
            try
            {
                string sql = "select * From Store Where IsDelete = 0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ddlStore.Items.Add(new ListItem(
                            (SysProperty.Util.OutputRelatedLangName(dr)
                            + "(" + dr["Sn"].ToString() + ")")
                            , dr["Id"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        private void InitialPermissionTable()
        {
            try
            {
                string sql = "select * From FunctionItem Where IsDelete = 0 And Type!=0 Order by Type";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    int cnt = 1;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        table1.Rows[cnt].Cells[1].Text = dr["Id"].ToString();
                        cnt++;
                    }
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion        

        private void BindData()
        {
            GetPermissionList(string.Empty);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        #region DataGrid
        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE Permission SET IsDelete = 1"
                + ", UpdateAccId=N'" + SysProperty.AccountInfo["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            try
            {
                if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPermissionCategory.Text = dataGrid.SelectedItem.Cells[2].Text;
            ddlStore.SelectedValue = ((Label)dataGrid.SelectedItem.FindControl("LabelStoreId")).Text;
            DataSet ds = GetPermissionItemByPermissionId(dataGrid.DataKeys[dataGrid.SelectedIndex].ToString());
            int cnt = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                table1.Rows[cnt].Cells[0].Text = dr["Id"].ToString();
                ((CheckBox)table1.Rows[cnt].Cells[3].Controls[0]).Checked = bool.Parse(dr["CanEntry"].ToString());
                ((CheckBox)table1.Rows[cnt].Cells[4].Controls[0]).Checked = bool.Parse(dr["CanCreate"].ToString());
                ((CheckBox)table1.Rows[cnt].Cells[5].Controls[0]).Checked = bool.Parse(dr["CanModify"].ToString());
                ((CheckBox)table1.Rows[cnt].Cells[6].Controls[0]).Checked = bool.Parse(dr["CanDelete"].ToString());
                ((CheckBox)table1.Rows[cnt].Cells[7].Controls[0]).Checked = bool.Parse(dr["CanExport"].ToString());
                cnt++;
            }
            btnUpdate.Visible = true;
        }

        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetPermissionList("Order by p." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }
        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                Label label = (Label)e.Item.FindControl("dgLabelStoreDisplayName");
                label.Text = dataItem1["StoreName"].ToString() + "(" + dataItem1["StoreSn"].ToString() + ")";
                Label labe2 = (Label)e.Item.FindControl("LabelStoreId");
                labe2.Text = dataItem1["ObjectId"].ToString();
            }
        }
        #endregion

        private void FreshScreen()
        {
            BindData();
            btnClear_Click(new object(), new EventArgs());
        }

        #region Button Control
        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbPermissionCategory.Text = string.Empty;
            ddlStore.SelectedIndex = 0;
            btnUpdate.Visible = false;
            for (int i = 1; i < table1.Rows.Count; i++)
            {
                for (int j = 3; j < 8; j++)
                {
                    ((CheckBox)table1.Rows[i].Cells[j].Controls[0]).Checked = true;
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPermissionCategory.Text)
                  || string.IsNullOrEmpty(ddlStore.SelectedValue))
            {
                return;
            }
            List<DbSearchObject> lst = PermissionDbObject();
            bool result = WriteBackPermission(true, lst, string.Empty);
            if (!result) return;
            string newId = GetCreatePermissionId(lst);
            if (string.IsNullOrEmpty(newId)) return;
            List<List<DbSearchObject>> lst2 = PermissionItemListFromTable(newId);
            result = WriteBackPermissionItem(true, lst2, newId);
            if (result)
            {
                FreshScreen();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPermissionCategory.Text)
                  || string.IsNullOrEmpty(ddlStore.SelectedValue))
            {
                return;
            }
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            List<DbSearchObject> lst = PermissionDbObject();
            bool result = WriteBackPermission(false, lst, id);
            List<List<DbSearchObject>> lst2 = PermissionItemListFromTable(id);
            result = WriteBackPermissionItem(false, lst2, id);
            if (result) FreshScreen();
            btnUpdate.Visible = false;
        }
        #endregion

        #region Db instqance 
        private List<DbSearchObject> PermissionDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPermissionCategory.Text)
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
                , SysProperty.AccountInfo["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
                "ObjectId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlStore.SelectedValue)
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

        private List<List<DbSearchObject>> PermissionItemListFromTable(string newId)
        {
            List<List<DbSearchObject>> root = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            DbSearchObject obj = new DbSearchObject();
            TableRow row = new TableRow();
            for (int cnt = 1; cnt < table1.Rows.Count; cnt++)
            {
                row = table1.Rows[cnt];
                lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject(
                    "ObjectId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , row.Cells[1].Text));
                lst.Add(new DbSearchObject(
                    "PermissionId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , newId));
                lst.Add(new DbSearchObject(
                    "CanEntry"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)row.Cells[3].Controls[0]).Checked ? "1" : "0"));
                lst.Add(new DbSearchObject(
                    "CanCreate"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)row.Cells[4].Controls[0]).Checked ? "1" : "0"));
                lst.Add(new DbSearchObject(
                    "CanModify"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)row.Cells[5].Controls[0]).Checked ? "1" : "0"));
                lst.Add(new DbSearchObject(
                    "CanDelete"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)row.Cells[6].Controls[0]).Checked ? "1" : "0"));
                lst.Add(new DbSearchObject(
                    "CanExport"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)row.Cells[7].Controls[0]).Checked ? "1" : "0"));
                lst.Add(new DbSearchObject(
                    "Type"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , "Operation"));
                lst.Add(new DbSearchObject(
                    "ObjectSn"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , cnt.ToString()));
                lst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, SysProperty.AccountInfo["Id"].ToString()));
                lst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
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
                    + ",e.Name as EmloyeeName,s." + new ResourceUtil().OutputLangNameToAttrName(SysProperty.CultureCode)
                    + " as StoreName,s.Sn as StoreSn"
                    + " FROM[TheWe].[dbo].[Permission] as p"
                    + " left join Store as s on s.Id = p.ObjectId"
                    + " left join Employee as e on e.Id = p.UpdateAccId"
                    + " Where p.IsDelete = 0 And p.Type = 'Operation' " + sortString;
                DS = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                DS = null;
                ShowErrorMsg(ex.Message);
            }
        }

        private DataSet GetFunctionList()
        {
            try
            {
                string sql = "SELECT [Id],[Name],[Type]"
                    + " FROM [TheWe].[dbo].[FunctionItem]"
                    + " where IsDelete = 0 And Type != 0"
                    + " Order by Type";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
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
                SysProperty.Log.Error(ex.Message);
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
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        #endregion
        #region Write Related
        private bool WriteBackPermission(bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Permission)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                    : (SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.Permission)
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

        private string GetCreatePermissionId(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Permission)
                    , SysProperty.Util.SqlQueryConditionConverter(lst)).Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
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
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    result = false;
                }
            }
            return result;
        }
        #endregion
        #endregion

        private string FunctionString(int type)
        {
            switch (type)
            {
                case 0:
                    return Resources.Resource.MainPageString;
                case 1:
                    return Resources.Resource.StoreMgtString;
                case 2:
                    return Resources.Resource.OrderMgtString;
                case 3:
                    return Resources.Resource.PurchaseMgtString;
                case 4:
                    return Resources.Resource.SalesMgtString;
                case 5:
                    return Resources.Resource.FinMgtString;
                case 6:
                    return Resources.Resource.SysMgtString;
                default:
                    return string.Empty;
            }
        }
    }
}