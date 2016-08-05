using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.StoreMgt
{
    public partial class DressMaintain : System.Web.UI.Page
    {
        DataSet DS;
        string OtherConditionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.StoreMgtString + " > " + Resources.Resource.DressString;
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
            LinkDressMCreate.Visible = item.CanCreate;
            LinkDressMCreate.Enabled = item.CanCreate;
            dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
        }
        private void InitialControls()
        {
            DressBackList();
            DressCategory();
            DressType();
            WornList();
            NecklineList();
            ShoulderList();
            StatusCodeList();
            UseStatusList();
            ColorList();
            MaterialList();
            GenderList();
        }
        
        #region DropDownList Control
        private void DressType()
        {
            ddlDressType.Items.Clear();
            ddlDressType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressType Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ddlDressType.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void DressCategory()
        {
            ddlDressCategory.Items.Clear();
            ddlDressCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressCategory Where IsDelete = 0 And Type = 'Dress'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlDressCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void NecklineList()
        {
            ddlNeckLine.Items.Clear();
            ddlNeckLine.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressNeckline Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlNeckLine.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void WornList()
        {
            ddlWorn.Items.Clear();
            ddlWorn.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressWorn Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlWorn.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void DressBackList()
        {
            ddlBack.Items.Clear();
            ddlBack.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressBack Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlBack.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void ShoulderList()
        {
            ddlShoulder.Items.Clear();
            ddlShoulder.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressShoulder Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlShoulder.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void StatusCodeList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressStatusCode Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void UseStatusList()
        {
            ddlUseStatus.Items.Clear();
            ddlUseStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressUseStatus Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlUseStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void ColorList()
        {
            ddlColor.Items.Clear();
            ddlColor.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select Distinct Color From Dress Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlColor.Items.Add(new ListItem(
                    dr[0].ToString()
                    , dr[0].ToString()
                    ));
            }
        }
        private void MaterialList()
        {
            ddlMaterial.Items.Clear();
            ddlMaterial.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select Distinct Material From Dress Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlMaterial.Items.Add(new ListItem(
                    dr[0].ToString()
                    , dr[0].ToString()
                    ));
            }
        }
        private void GenderList()
        {
            ddlGender.Items.Clear();
            ddlGender.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            ddlGender.Items.Add(new ListItem(Resources.Resource.FemaleString, "0"));
            ddlGender.Items.Add(new ListItem(Resources.Resource.MainPageString, "1"));
        }
        #endregion        

        #region DataGrid Control
        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelCategory")).Text = ddlDressCategory.Items.FindByValue(dataItem1["Category"].ToString()).Text;
                ((Label)e.Item.FindControl("labelType")).Text = ddlDressType.Items.FindByValue(dataItem1["Type"].ToString()).Text;
                ((Label)e.Item.FindControl("labelNeckline")).Text = ddlNeckLine.Items.FindByValue(dataItem1["Neckline"].ToString()).Text;
                ((Label)e.Item.FindControl("labelDressBack")).Text = ddlBack.Items.FindByValue(dataItem1["Back"].ToString()).Text;
                ((Label)e.Item.FindControl("labelShoulder")).Text = ddlShoulder.Items.FindByValue(dataItem1["Shoulder"].ToString()).Text;
                ((Label)e.Item.FindControl("labelWorn")).Text = ddlWorn.Items.FindByValue(dataItem1["Worn"].ToString()).Text;

            }
        }
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["DressId"] = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Response.Redirect("DressMCreate.aspx");
        }
        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetDressList(
                    bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                    ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString()
                    , OtherConditionString + " Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }
        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE OrderInfo SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
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
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OtherConditionString = string.Empty;
            if (!string.IsNullOrEmpty(tbSn.Text))
            {
                OtherConditionString += " And Sn like '%" + tbSn.Text + "%'";
            }

            OtherConditionString += string.IsNullOrEmpty(ddlDressCategory.SelectedValue) ? string.Empty : " And Category='" + ddlDressCategory.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(ddlBack.SelectedValue) ? string.Empty : " And Back='" + ddlBack.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(ddlColor.SelectedValue) ? string.Empty : " And Color like '%" + ddlColor.SelectedValue + "%'";
            OtherConditionString += string.IsNullOrEmpty(ddlDressType.SelectedValue) ? string.Empty : " And Type='" + ddlDressType.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(ddlGender.SelectedValue) ? string.Empty : " And Gender=" + ddlGender.SelectedValue;
            OtherConditionString += string.IsNullOrEmpty(ddlMaterial.SelectedValue) ? string.Empty : " And Material like '%" + ddlMaterial.SelectedValue + "%'";
            OtherConditionString += string.IsNullOrEmpty(ddlNeckLine.SelectedValue) ? string.Empty : " And Neckline='" + ddlNeckLine.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(ddlShoulder.SelectedValue) ? string.Empty : " And Shoulder='" + ddlShoulder.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(ddlStatus.SelectedValue) ? string.Empty : " And StatusCode='" + ddlStatus.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(ddlUseStatus.SelectedValue) ? string.Empty : " And UseStatus='" + ddlUseStatus.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(ddlWorn.SelectedValue) ? string.Empty : " And Worn='" + ddlWorn.SelectedValue + "'";
            OtherConditionString += cbAddPrice.Checked ? " And AddPrice = 1" : string.Empty;
            OtherConditionString += cbBigSize.Checked ? " And BigSize = 1" : string.Empty;
            OtherConditionString += cbDomesticWedding.Checked ? " And DomesticWedding = 1" : string.Empty;
            OtherConditionString += cbOutPhoto.Checked ? " And OutPicture = 1" : string.Empty;
            BindData();
        }

        private void BindData()
        {
            string storeId = !bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
            GetDressList(storeId, OtherConditionString);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetDressList(string storeId, string condStr)
        {
            string sqlTxt = "Select * From Dress Where IsDelete=0 "
                + (string.IsNullOrEmpty(storeId) ? string.Empty : " And StoreId='" + storeId + "' ")
                + condStr;
            DS = (DataSet)GetDataSetFromTable(sqlTxt);
        }

        private DataSet GetDataSetFromTable(string sql)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
    }
}