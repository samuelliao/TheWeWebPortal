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
                    BindData();
                }
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
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
                LinkButton hyperLink1 = (LinkButton)e.Item.FindControl("linkConsult");
                hyperLink1.Text = dataItem1["ConsultSn"].ToString();
                hyperLink1.CommandArgument = dataItem1["ConsultId"].ToString();

                LinkButton hyperLink3 = (LinkButton)e.Item.FindControl("linkCustomerName");
                hyperLink3.Text = dataItem1["CustomerName"].ToString();
                hyperLink3.CommandArgument = dataItem1["CustomerId"].ToString();

                Label label4 = (Label)e.Item.FindControl("labelStatus");
                label4.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["StatusName"].ToString()
                    , dataItem1["StatusCnName"].ToString()
                    , dataItem1["StatusEngName"].ToString()
                    , dataItem1["StatusJpName"].ToString());

                ((Label)e.Item.FindControl("labelCountry")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetCountryById(dataItem1["CountryId"].ToString()));
                ((Label)e.Item.FindControl("labelArea")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetAreaById(dataItem1["AreaId"].ToString()));
                ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()));

                ((Label)e.Item.FindControl("labelSet")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["SetName"].ToString()
                    , dataItem1["SetCnName"].ToString()
                    , dataItem1["SetEngName"].ToString()
                    , dataItem1["SetJpName"].ToString());
            }
        }
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["OrderId"] = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Response.Redirect("CaseMCreate.aspx");
        }
        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetDressList(
                    ((DataRow)Session["LocateStore"]) == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString()
                    , OtherConditionString + " Order by c." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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
            string storeId = ((DataRow)Session["LocateStore"]) == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
            GetDressList(storeId, OtherConditionString);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetDressList(string storeId, string condStr)
        {
            string sqlTxt = "Select * From Dress Where IsDelete=0 "
                + (string.IsNullOrEmpty(storeId) ? string.Empty : " And o.StoreId='" + storeId + "' ")
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