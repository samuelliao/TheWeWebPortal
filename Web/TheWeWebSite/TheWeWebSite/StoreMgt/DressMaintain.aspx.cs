using NLog;
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
                    labelPageTitle.Text = Resources.Resource.StoreMgtString + " > " + Resources.Resource.DressMaintainString;
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
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                LinkDressMCreate.Visible = item.CanCreate;
                LinkDressMCreate.Enabled = item.CanCreate;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
                divStore.Attributes["style"] = "display: inline;";
            }
            else
            {
                LinkDressMCreate.Enabled = false;
                LinkDressMCreate.Visible = false;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = false;
            }
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
            StoreList();
        }



        #region DropDownList Control
        private void StoreList()
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From Store Where IsDelete=0 Order by GradeLv, Sn";
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ddlStore.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr) + "(" + dr["Code"].ToString() + ")"
                            , dr["Id"].ToString()));
                    }
                    if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                    {
                        ddlStore.SelectedValue = ((DataRow)Session["LocateStore"])["Id"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void DressType()
        {
            ddlDressType.Items.Clear();
            ddlDressType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressType Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
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
            ddlGender.Items.Add(new ListItem(Resources.Resource.MaleString, "1"));
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
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                ((Label)e.Item.FindControl("labelCategory")).Text = ddlDressCategory.Items.FindByValue(dataItem1["Category"].ToString()).Text;
                ((Label)e.Item.FindControl("labelType")).Text = ddlDressType.Items.FindByValue(dataItem1["Type"].ToString()).Text;
                ((Image)e.Item.FindControl("imgDress")).ImageUrl = "http:"+SysProperty.ImgRootFolderpath + @dataItem1["Img"].ToString()+ "\\" + dataItem1["Sn"].ToString() + "_1.jpg?" + DateTime.Now.Ticks.ToString();
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
                    , GetQueryString() + " Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {            
            dataGrid.CurrentPageIndex = 0;
            BindData();
        }

        private string GetQueryString()
        {
            string queryStr = string.Empty;
            if (!string.IsNullOrEmpty(tbSn.Text))
            {
                queryStr += " And Sn like '%" + tbSn.Text + "%'";
            }

            queryStr += string.IsNullOrEmpty(ddlDressCategory.SelectedValue) ? string.Empty : " And Category='" + ddlDressCategory.SelectedValue + "'";
            queryStr += string.IsNullOrEmpty(ddlBack.SelectedValue) ? string.Empty : " And Back='" + ddlBack.SelectedValue + "'";
            queryStr += string.IsNullOrEmpty(ddlColor.SelectedValue) ? string.Empty : " And Color like '%" + ddlColor.SelectedValue + "%'";
            queryStr += string.IsNullOrEmpty(ddlDressType.SelectedValue) ? string.Empty : " And Type='" + ddlDressType.SelectedValue + "'";
            queryStr += string.IsNullOrEmpty(ddlGender.SelectedValue) ? string.Empty : " And Gender=" + ddlGender.SelectedValue;
            queryStr += string.IsNullOrEmpty(ddlMaterial.SelectedValue) ? string.Empty : " And Material like '%" + ddlMaterial.SelectedValue + "%'";
            queryStr += string.IsNullOrEmpty(ddlNeckLine.SelectedValue) ? string.Empty : " And Neckline='" + ddlNeckLine.SelectedValue + "'";
            queryStr += string.IsNullOrEmpty(ddlShoulder.SelectedValue) ? string.Empty : " And Shoulder='" + ddlShoulder.SelectedValue + "'";
            queryStr += string.IsNullOrEmpty(ddlStatus.SelectedValue) ? string.Empty : " And StatusCode='" + ddlStatus.SelectedValue + "'";
            queryStr += string.IsNullOrEmpty(ddlUseStatus.SelectedValue) ? string.Empty : " And UseStatus='" + ddlUseStatus.SelectedValue + "'";
            queryStr += string.IsNullOrEmpty(ddlWorn.SelectedValue) ? string.Empty : " And Worn='" + ddlWorn.SelectedValue + "'";
            queryStr += cbAddPrice.Checked ? " And AddPrice = 1" : string.Empty;
            queryStr += cbBigSize.Checked ? " And BigSize = 1" : string.Empty;
            queryStr += cbDomesticWedding.Checked ? " And DomesticWedding = 1" : string.Empty;
            queryStr += cbOutPhoto.Checked ? " And OutPicture = 1" : string.Empty;
            return queryStr;
        }

        private void BindData()
        {
            string storeId = string.IsNullOrEmpty(ddlStore.SelectedValue) ? string.Empty : ddlStore.SelectedValue;
            GetDressList(storeId, GetQueryString() + " Order by Sn");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetDressList(string storeId, string condStr)
        {
            string sqlTxt = "Select TOP 100 * From Dress Where IsDelete=0 "
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
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        protected void LinkDressMCreate_Click(object sender, EventArgs e)
        {
            Session.Remove("DressId");
            Response.Redirect("DressMCreate.aspx", true);
        }
    }
}