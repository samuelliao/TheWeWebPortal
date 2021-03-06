﻿using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;
using TheWeLib.DbControl;

namespace TheWeWebSite.StoreMgt
{
    public partial class ChurchMaintain : System.Web.UI.Page
    {
        DataSet ChurchDataSet;
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
                    labelPageTitle.Text = Resources.Resource.StoreMgtString + " > " + Resources.Resource.ChurchMaintainString;
                    InitialAllList();
                    InitialControlWithPermission();
                    BindData(string.Empty);
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
            if (Session["LocateStore"] != null)
            {
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    btnCreate.Visible = false;
                    dgChurch.Columns[dgChurch.Columns.Count - 1].Visible = false;
                }
            }
            else
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                btnCreate.Visible = item.CanCreate;
                btnCreate.Enabled = item.CanCreate;
                dgChurch.Columns[dgChurch.Columns.Count - 1].Visible = item.CanDelete;                
            }
        }
        private void InitialAllList()
        {
            GetCountryList();
            GetAreaList(ddlCountry.SelectedValue);
            //GetChurchList(string.Empty, string.Empty);
        }

        private void GetCountryList()
        {
            ddlCountry.Items.Clear();
            try
            {
                ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty, true));
                DataSet CountryDataSet = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country), string.Empty);
                foreach (DataRow dr in CountryDataSet.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString(), true));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return;
            }
        }

        private void GetAreaList(string countryId)
        {
            ddlArea.Items.Clear();
            try
            {
                ddlArea.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty, true));
                DataSet AreaDataSet = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                    , string.IsNullOrEmpty(countryId) ? string.Empty : " Where CountryId = '" + countryId + "'");
                foreach (DataRow dr in AreaDataSet.Tables[0].Rows)
                {
                    ddlArea.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString(), true));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return;
            }
        }

        private void GetChurchList(string condStr, string sortStr)
        {
            try
            {
                ChurchDataSet = SysProperty.GenDbCon.GetDataFromTable(" TOP 100 * "
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
                    , " Where IsDelete = 0" + condStr + " " + sortStr);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return;
            }
        }

        #region DropDownList Controller
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAreaList(ddlCountry.SelectedValue);
        }
        #endregion

        #region DataGrid Control
        private void BindData(string condStr)
        {
            GetChurchList(condStr, string.Empty);
            dgChurch.DataSource = ChurchDataSet;
            if (SysProperty.Util.IsDataSetEmpty(ChurchDataSet))
            {
                dgChurch.AllowPaging = dgChurch.PageSize < ChurchDataSet.Tables[0].Rows.Count;
            }
            else
            {
                dgChurch.AllowPaging = false;
            }

            dgChurch.DataBind();
        }
        protected void dgChurch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgChurch.DataKeys[dgChurch.SelectedIndex].ToString();
            Session["ChurchId"] = id;
            Response.Redirect("~/StoreMgt/ChurchMCreate.aspx", true);
        }
        protected void dgChurch_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dgChurch.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE Church SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
            {
                BindData(string.Empty);
            }
        }

        protected void dgChurch_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgChurch.CurrentPageIndex = e.NewPageIndex;
            BindData(ConditionGen());
        }

        protected void dgChurch_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                DataRow countryDr = SysProperty.GetCountryById(dataItem1["CountryId"].ToString());
                Label label = (Label)e.Item.FindControl("dgLabelCountry");
                label.Text = SysProperty.Util.OutputRelatedLangName(
                    Session["CultureCode"].ToString()
                    , countryDr);
                Label label2 = (Label)e.Item.FindControl("dgLabelArea");
                label2.Text = SysProperty.Util.OutputRelatedLangName(
                    Session["CultureCode"].ToString()
                    , SysProperty.GetAreaById(dataItem1["AreaId"].ToString()));
                Label label3 = (Label)e.Item.FindControl("dgLabelChurch");
                label3.Text = SysProperty.Util.OutputRelatedLangName(
                    Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["Id"].ToString()));

                if(countryDr != null)
                    ((Label)e.Item.FindControl("dgLabelChurchOth")).Text = countryDr["Code"].ToString().Trim() == "JP" ? dataItem1["JpName"].ToString() : dataItem1["EngName"].ToString();
                else
                    ((Label)e.Item.FindControl("dgLabelChurchOth")).Text = dataItem1["EngName"].ToString();

                ((Label)e.Item.FindControl("dgLabelProvider")).Text = SysProperty.Util.OutputRelatedLangName(
                    Session["CultureCode"].ToString()
                    , dataItem1["LocationName"].ToString()
                    , dataItem1["LocationCnName"].ToString()
                    , dataItem1["LocationEngName"].ToString()
                    , dataItem1["LocationJpName"].ToString());
            }
        }
        #endregion

        #region Button Control
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dgChurch.CurrentPageIndex = 0;
            BindData(ConditionGen());
        }

        private string ConditionGen()
        {
            string condStr = string.Empty;

            if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                condStr += " And CountryId = '" + ddlCountry.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
            {
                condStr += " And AreaId = '" + ddlArea.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                condStr += " And (Name like '%" + tbName.Text + "%'"
                    + " Or EngName like '%" + tbName.Text + "%'"
                    + " Or JpName like '%" + tbName.Text + "%'"
                    + " Or CnName like '%" + tbName.Text + "%')";
            }
            return condStr;
        }
        #endregion

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Session.Remove("ChurchId");
            Response.Redirect("~/StoreMgt/ChurchMCreate.aspx", true);
        }
    }
}