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
    public partial class ChurchMCreate : System.Web.UI.Page
    {
        DataSet ChurchDataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    FirstGridViewRow();
                    InitialControl();
                    if (Session["ChurchId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.ChurchMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        SetChurchData(Session["ChurchId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.ChurchMaintainString
                        + " > " + Resources.Resource.CreateString;
                        btnModify.Visible = false;
                        btnDelete.Visible = false;
                    }
                }
            }
        }
        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void InitialControl()
        {
            SetCountryList();
            SetAreaList(ddlCountry.SelectedValue);
        }
        private void TransferToOtherPage()
        {
            ViewState.Remove("CurrentTable");
            Session.Remove("ChurchId");
            Server.Transfer("ChurchMaintain.aspx", true);
        }

        #region Photo Control
        protected void btnPhoto1_Click(object sender, EventArgs e)
        {

        }

        protected void btnPhoto2_Click(object sender, EventArgs e)
        {

        }

        protected void btnPhoto3_Click(object sender, EventArgs e)
        {

        }

        protected void btnPhoto4_Click(object sender, EventArgs e)
        {

        }
        protected void btnUploadMeal_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button Control
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["ChurchId"].ToString())) return;
                string sql = "UPDATE Church SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["ChurchId"].ToString() + "'";
                if (SysProperty.GenDbCon.ModifyDataInToTable(sql))
                {
                    TransferToOtherPage();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbCapacities.Text = string.Empty;
            tbName.Text = string.Empty;
            tbJpName.Text = string.Empty;
            tbEngName.Text = string.Empty;
            tbCnName.Text = string.Empty;
            tbMealDescription.Text = string.Empty;
            tbPatioHeight.Text = string.Empty;
            tbPrice.Text = string.Empty;
            tbRedCarpetLength.Text = string.Empty;
            tbRedCarpetType.Text = string.Empty;
            tbRemark.Text = string.Empty;
            tbSn.Text = string.Empty;
            ddlArea.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            FirstGridViewRow();
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (Session["ChurchId"] == null) return;
            string id = Session["ChurchId"].ToString();
            List<DbSearchObject> lst = ChurchDbObject();
            result = WriteBackChurch(false, lst, id);
            if (!result) return;
            result = WriteBackAppointment(false, AppointmentTimeDbObject(id), id);

            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            bool result = false;
            List<DbSearchObject> lst = ChurchDbObject();
            result = WriteBackChurch(true, lst, string.Empty);
            if (!result) return;
            string id = GetCreateChurchId(lst);
            if (string.IsNullOrEmpty(id)) return;
            result = WriteBackAppointment(true, AppointmentTimeDbObject(id), id);
            if (result)
            {
                TransferToOtherPage();
            }
        }
        #endregion

        #region DropDownList Control
        private void SetCountryList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty));
            try
            {
                string sql = "Select * From Country Where IsDelete = 0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void SetAreaList(string countryId)
        {
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            try
            {
                string sql = "Select * From Area Where IsDelete = 0"
                    + (string.IsNullOrEmpty(countryId) ? string.Empty : " And CountryId = '" + countryId + "'");
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlArea.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        private void GetChurchList(string condStr, string sortString)
        {
            try
            {
                string sql = "Select * From Church Where IsDelete = 0 " + condStr + " " + sortString;
                ChurchDataSet = SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                ChurchDataSet = null;
            }
        }

        private string GetCreateChurchId(List<DbSearchObject> lst)
        {
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable
                    ("Id"
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
                    , SysProperty.Util.SqlQueryConditionConverter(lst));
                if (SysProperty.Util.IsDataSetEmpty(ds)) return string.Empty;
                return ds.Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return string.Empty;
            }
        }

        private void SetChurchData(string id)
        {
            GetChurchList(" And Id = '" + id + "'", string.Empty);
            if (SysProperty.Util.IsDataSetEmpty(ChurchDataSet)) return;
            DataRow dr = ChurchDataSet.Tables[0].Rows[0];
            tbSn.Text = dr["Sn"].ToString();
            tbName.Text = dr["Name"].ToString();
            tbJpName.Text = dr["JpName"].ToString();
            tbCnName.Text = dr["CnName"].ToString();
            tbEngName.Text = dr["EngName"].ToString();
            tbCapacities.Text = dr["Capacities"].ToString();
            tbPatioHeight.Text = dr["PatioHeight"].ToString();
            tbMealDescription.Text = dr["Description"].ToString();
            tbPrice.Text = dr["Price"].ToString();
            tbRedCarpetLength.Text = dr["RedCarpetLong"].ToString();
            tbRedCarpetType.Text = dr["RedCarpetCategory"].ToString();
            tbRemark.Text = dr["Remark"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            ddlArea.SelectedValue = dr["AreaId"].ToString();
            SetChurchBookingTime(id);
        }

        private DataSet GetChurchBookingTime(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return null;
                string sql = "Select * From ChurchBookingTime Where IsDelete = 0 And ChurchId = '" + id + "' Order by StartTime";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private void SetChurchBookingTime(string id)
        {
            DataSet ds = GetChurchBookingTime(id);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgBookTable.Rows.Count == 0)
                {
                    AddNewRow();
                }
                ((TextBox)dgBookTable.Rows[cnt].FindControl("tbStart")).Text = SysProperty.Util.ParseDateTime("Time", dr["StartTime"].ToString());
                ((TextBox)dgBookTable.Rows[cnt].FindControl("tbEnd")).Text = SysProperty.Util.ParseDateTime("Time", dr["EndTime"].ToString());
                cnt++;
                AddNewRow();
            }
        }

        #region Appointment Time Table
        protected void dgBookTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    dgBookTable.DataSource = dt;
                    dgBookTable.DataBind();

                    SetPreviousData();
                }
            }
        }

        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dr = dt.NewRow();
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            dgBookTable.DataSource = dt;
            dgBookTable.DataBind();
        }

        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextStart =
                          (TextBox)dgBookTable.Rows[rowIndex].Cells[0].FindControl("tbStart");
                        TextBox TextEnd =
                          (TextBox)dgBookTable.Rows[rowIndex].Cells[1].FindControl("tbEnd");
                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["Col1"] = TextStart.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextEnd.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    dgBookTable.DataSource = dtCurrentTable;
                    dgBookTable.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox TextStart = (TextBox)dgBookTable.Rows[rowIndex].Cells[0].FindControl("tbStart");
                        TextBox TextEnd = (TextBox)dgBookTable.Rows[rowIndex].Cells[1].FindControl("tbEnd");
                        if (TextStart == null) continue;
                        if (TextEnd == null) continue;
                        TextStart.Text = dt.Rows[i]["Col1"] == null ? string.Empty : dt.Rows[i]["Col1"].ToString();
                        TextEnd.Text = dt.Rows[i]["Col2"] == null ? string.Empty : dt.Rows[i]["Col2"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextStart = (TextBox)dgBookTable.Rows[rowIndex].Cells[0].FindControl("tbStart");
                        TextBox TextEnd = (TextBox)dgBookTable.Rows[rowIndex].Cells[1].FindControl("tbEnd");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextStart.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextEnd.Text;
                        rowIndex++;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
        #endregion

        private List<DbSearchObject> ChurchDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSn.Text
                ));
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbName.Text
                ));
            lst.Add(new DbSearchObject(
                "EngName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEngName.Text
                ));
            lst.Add(new DbSearchObject(
                "JpName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbJpName.Text
                ));
            lst.Add(new DbSearchObject(
                "CnName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCnName.Text
                ));
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCountry.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "AreaId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlArea.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "Capacities"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , tbCapacities.Text
                ));
            lst.Add(new DbSearchObject(
                "Price"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , tbPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "Remark"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRemark.Text
                ));
            lst.Add(new DbSearchObject(
                "PatioHeight"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , tbPatioHeight.Text
                ));
            lst.Add(new DbSearchObject(
                "RedCarpetLong"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , tbRedCarpetLength.Text
                ));
            lst.Add(new DbSearchObject(
                "RedCarpetCategory"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRedCarpetType.Text
                ));
            lst.Add(new DbSearchObject(
                "Description"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbMealDescription.Text
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }

        private List<List<DbSearchObject>> AppointmentTimeDbObject(string id)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (ViewState["CurrentTable"] != null)
            {
                //DataTable table = (DataTable)ViewState["CurrentTable"];
                string str = string.Empty;
                if (dgBookTable.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in dgBookTable.Rows)
                    {
                        lst = new List<DbSearchObject>();
                        str = SysProperty.Util.ParseDateTime("Time", ((TextBox)dr.Cells[0].FindControl("tbStart")).Text);
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "StartTime"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = SysProperty.Util.ParseDateTime("Time", ((TextBox)dr.Cells[1].FindControl("tbEnd")).Text);
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "EndTime"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        lst.Add(new DbSearchObject(
                            "ChurchId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , id
                            ));
                        lst.Add(new DbSearchObject(
                            "UpdateAccId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                            ));
                        result.Add(lst);
                    }
                }
            }
            return result;
        }

        private bool WriteBackChurch(bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                    : (SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
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

        private bool WriteBackAppointment(bool isInsert, List<List<DbSearchObject>> lst, string id)
        {
            bool result = true;
            try
            {
                if (!isInsert)
                {
                    SysProperty.GenDbCon.ModifyDataInToTable("DELETE FROM[dbo].[ChurchBookingTime] WHERE ChurchId = '" + id + "'");
                }
                foreach (List<DbSearchObject> item in lst)
                {
                    result = result | SysProperty.GenDbCon.InsertDataInToTable
                        (SysProperty.Util.MsSqlTableConverter(MsSqlTable.ChurchBookingTime)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(item)
                        , SysProperty.Util.SqlQueryInsertValueConverter(item));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
            return result;
        }
    }
}