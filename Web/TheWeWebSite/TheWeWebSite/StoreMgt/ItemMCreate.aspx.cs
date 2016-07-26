using AjaxControlToolkit;
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
    public partial class ItemMCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    FirstGridViewRow();
                    InitialAllDropDownList();

                    if (Session["SetId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.CustomerMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        SetSetAllData(Session["SetId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.CustomerMaintainString
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
        private void TransferToOtherPage()
        {
            Session.Remove("SetId");
            ViewState.Remove("CurrentTable");
            Response.Redirect("ItemMaintain.aspx", true);
        }

        #region DropDownList Control
        public void InitialAllDropDownList()
        {
            CountryDropDownList();
            AreaDropDownList(string.Empty);
            LocationDropDownList(string.Empty, string.Empty);
            ServiceCategoryDropDownList();
            WeddingTypeDropDownList();
            StaffDropDownList();
        }
        private void WeddingTypeDropDownList()
        {
            ddlWeddingType.Items.Clear();
            ddlWeddingType.Items.Add(new ListItem(Resources.Resource.WeddingTypeSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.WeddingCategory), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlWeddingType.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        public void CountryDropDownList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        public void AreaDropDownList(string countryId)
        {
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                if (!string.IsNullOrEmpty(countryId))
                {
                    lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, countryId));
                }
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlArea.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        public void LocationDropDownList(string countryId, string areaId)
        {
            ddlLocate.Items.Clear();
            ddlLocate.Items.Add(new ListItem(Resources.Resource.ChurchSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                if (!string.IsNullOrEmpty(countryId))
                {
                    lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, countryId));
                }
                if (!string.IsNullOrEmpty(areaId))
                {
                    lst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, areaId));
                }

                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlLocate.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void ServiceCategoryDropDownList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.ProjectSelectionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("TypeLv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "0"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ServiceItemCategory), lst, " Order by Type");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem
                    (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void StaffDropDownList()
        {
            ddlStaff.Items.Clear();
            ddlStaff.Items.Add(new ListItem(Resources.Resource.EnglishString, "0"));
            ddlStaff.Items.Add(new ListItem(Resources.Resource.ChineseString, "1"));
            ddlStaff.Items.Add(new ListItem(Resources.Resource.JapaneseString, "3"));
            ddlStaff.SelectedIndex = 1;
        }
        #region DropDownList Selected Index Change Control
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDropDownList(ddlCountry.SelectedValue);
            LocationDropDownList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            FirstGridViewRow();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocationDropDownList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            FirstGridViewRow();
        }

        protected void ddlLocate_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirstGridViewRow();
        }
        #endregion
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
                if (string.IsNullOrEmpty(Session["ConsultId"].ToString())) return;
                string sql = "UPDATE ProductSet SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["ConsultId"].ToString() + "'";
                if (((bool)InvokeDbControlFunction(sql, false)))
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
            tbBridalHairStyle.Text = string.Empty;
            tbCorsage.Text = string.Empty;
            tbCost.Text = string.Empty;
            tbDecorate.Text = string.Empty;
            tbFilmLocation.Text = string.Empty;
            tbFilmTime.Text = string.Empty;
            tbGroomHairStyle.Text = string.Empty;
            tbMovemont.Text = string.Empty;
            tbPerformence.Text = string.Empty;
            tbPhotoNumber.Text = string.Empty;
            tbPrice.Text = string.Empty;
            tbRoom.Text = string.Empty;
            tbSn.Text = string.Empty;
            tbStay.Text = string.Empty;
            cbBreakfast.Checked = false;
            cbCertificate.Checked = false;
            cbChurchCost.Checked = false;
            cbDinner.Checked = false;
            cbIroning.Checked = false;
            cbLegal.Checked = false;
            cbLounge.Checked = false;
            cbLunch.Checked = false;
            cbMeeting.Checked = false;
            cbPastor.Checked = false;
            cbPen.Checked = false;
            cbPillow.Checked = false;
            cbRehersal.Checked = false;
            FirstGridViewRow();
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["SetId"] == null) return;
            string id = Session["SetId"].ToString();
            if (string.IsNullOrEmpty(id)) return;
            bool result = WriteBackInfo(MsSqlTable.ProductSet, false, SetDbObject(), " Where Id='" + id + "'");
            if (!result) return;
            result = WriteBackServiceItem(false, ServiceItemDbObject(id), id);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSn.Text))
            {
                ShowErrorMsg("Sn cannot be null");
                return;
            }
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ProductSet), tbSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            List<DbSearchObject> lst = SetDbObject();
            bool result = WriteBackInfo(MsSqlTable.ProductSet, true, lst, string.Empty);
            if (!result) return;
            string id = GetCreateSetId(lst);
            if (string.IsNullOrEmpty(id)) return;
            result = WriteBackServiceItem(true, ServiceItemDbObject(id), id);
            if (result)
            {
                TransferToOtherPage();
            }
        }
        #endregion

        #region Service Item Table
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
                    dgServiceItem.DataSource = dt;
                    dgServiceItem.DataBind();

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
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dr = dt.NewRow();
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            dgServiceItem.DataSource = dt;
            dgServiceItem.DataBind();
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
                        DropDownList DdlItem =
                            (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");


                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextStart.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextEnd.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    dgServiceItem.DataSource = dtCurrentTable;
                    dgServiceItem.DataBind();
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
                        DropDownList DdlItem = (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart = (TextBox)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd = (TextBox)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
                        if (TextStart == null) continue;
                        if (TextEnd == null) continue;
                        DdlItem.SelectedValue = dt.Rows[i]["Col1"].ToString();
                        TextStart.Text = dt.Rows[i]["Col2"] == null ? string.Empty : dt.Rows[i]["Col2"].ToString();
                        TextEnd.Text = dt.Rows[i]["Col3"] == null ? string.Empty : dt.Rows[i]["Col3"].ToString();
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
                        DropDownList DdlItem = (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextNumber = (TextBox)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextPrice = (TextBox)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextNumber.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextPrice.Text;
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

        protected void dgServiceItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                    dgServiceItem.DataSource = dt;
                    dgServiceItem.DataBind();

                    SetPreviousData();
                }
            }
        }
        protected void dgServiceItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                if (Session["CultureCode"] == null) return;
                string cultureCode = Session["CultureCode"].ToString();
                DropDownList ddlService = (DropDownList)e.Row.FindControl("ddlServiceItem");
                ddlService.Items.Add(new ListItem(Resources.Resource.ServiceItemSelectRemindString, string.Empty));
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ServiceItem Where IsDelete = 0 And IsGeneral = 1");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlService.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(cultureCode, dr)
                        , dr["Id"].ToString()
                        ));
                }
                if (string.IsNullOrEmpty(ddlLocate.SelectedValue)) return;
                ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ServiceItem Where IsGeneral = 0 And SupplierId = '" + ddlLocate.SelectedValue+"'");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlService.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(cultureCode, dr)
                        , dr["Id"].ToString()
                        ));
                }
                ddlService.SelectedIndex = 0;
            }
        }
        protected void tbPrice_TextChanged(object sender, EventArgs e)
        {
            bool result = false;
            decimal dec = 0;
            result = decimal.TryParse(((TextBox)sender).Text, out dec);
            if (result)
            {
                tbPrice.Text = (SysProperty.Util.ParseMoney(tbPrice.Text) + dec).ToString();
            }
        }
        #endregion        

        #region DB Control
        private DataSet GetDataFromDb(string tableName, List<DbSearchObject> lst)
        {
            string sqlTxt = "Select * From " + tableName + SysProperty.Util.SqlQueryConditionConverter(lst);
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
        private DataSet GetDataFromDb(string tableName, List<DbSearchObject> lst, string sortStr)
        {
            string sqlTxt = "Select * From " + tableName
                + SysProperty.Util.SqlQueryConditionConverter(lst)
                + " " + sortStr;
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
        private DataSet GetDataFromDb(string tableName, string whereString)
        {
            string sqlTxt = "Select * From " + tableName + whereString;
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
        private Object InvokeDbControlFunction(string sql, bool isSelect)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                if (isSelect)
                    return SysProperty.GenDbCon.GetDataFromTable(sql);
                else
                    return SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private string GetCreateSetId(List<DbSearchObject> lst)
        {
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ProductSet), lst);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return string.Empty;
            return ds.Tables[0].Rows[0]["Id"].ToString();
        }

        private bool WriteBackServiceItem(bool isInsert, List<List<DbSearchObject>> lst, string id)
        {
            string condStr = " Where SetId = '" + id + "'";
            if (!isInsert)
            {
                SysProperty.GenDbCon.ModifyDataInToTable("Delete From ProductSetServiceItem " + condStr);
            }
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                result = result | WriteBackInfo(MsSqlTable.ProductSetServiceItem, true, item, condStr);
            }
            return result;
        }

        private bool WriteBackInfo(MsSqlTable table, bool isInsert, List<DbSearchObject> lst, string condStr)
        {
            try
            {
                return isInsert ?
                    SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst))
                        : SysProperty.GenDbCon.UpdateDataIntoTable(
                            SysProperty.Util.MsSqlTableConverter(table)
                            , SysProperty.Util.SqlQueryUpdateConverter(lst)
                            , condStr);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        #endregion

        #region Initial By Given Set Id
        private void SetSetAllData(string id)
        {
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ProductSet), " Where Id='" + id + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbName.Text = dr["Name"].ToString();
            tbCnName.Text = dr["CnName"].ToString();
            tbJpName.Text = dr["JpName"].ToString();
            tbEngName.Text = dr["EngName"].ToString();
            tbBridalHairStyle.Text = dr["BridalMakeup"].ToString();
            tbCorsage.Text = dr["Corsage"].ToString();
            tbCost.Text = dr["Cost"].ToString();
            tbDecorate.Text = dr["Decoration"].ToString();
            tbFilmLocation.Text = dr["FilmingLocation"].ToString();
            tbFilmTime.Text = dr["WeddingFilmingTime"].ToString();
            tbGroomHairStyle.Text = dr["GroomMakeup"].ToString();
            tbMovemont.Text = dr["Moves"].ToString();
            tbPerformence.Text = dr["Performence"].ToString();
            tbPhotoNumber.Text = dr["PhotosNum"].ToString();
            tbPrice.Text = dr["Price"].ToString();
            tbRoom.Text = dr["RoomId"].ToString();
            tbSn.Text = dr["Sn"].ToString();
            tbStay.Text = dr["StayNight"].ToString();
            cbBreakfast.Checked = bool.Parse(dr["Breakfast"].ToString());
            cbCertificate.Checked = bool.Parse(dr["Certificate"].ToString());
            cbChurchCost.Checked = bool.Parse(dr["ChurchCost"].ToString());
            cbDinner.Checked = bool.Parse(dr["Dinner"].ToString());
            cbIroning.Checked = bool.Parse(dr["DressIroning"].ToString());
            cbLegal.Checked = bool.Parse(dr["IsLegal"].ToString());
            cbLounge.Checked = bool.Parse(dr["Lounge"].ToString());
            cbLunch.Checked = bool.Parse(dr["Lunch"].ToString());
            cbMeeting.Checked = bool.Parse(dr["Kickoff"].ToString());
            cbPastor.Checked = bool.Parse(dr["Pastor"].ToString());
            cbPen.Checked = bool.Parse(dr["SignPen"].ToString());
            cbPillow.Checked = bool.Parse(dr["RingPillow"].ToString());
            cbRehersal.Checked = bool.Parse(dr["Rehearsal"].ToString());
            ddlArea.SelectedValue = dr["AreaId"].ToString();
            ddlCategory.SelectedValue = dr["Category"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            ddlLocate.SelectedValue = dr["ChurchId"].ToString();
            ddlStaff.SelectedValue = dr["Staff"].ToString();
            ddlWeddingType.SelectedValue = dr["WeddingCategory"].ToString();
            SetServiceItemTable(id);
        }

        private void SetServiceItemTable(string id)
        {
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ProductSetServiceItem Where IsDelete = 0 And SetId='" + id + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgServiceItem.Rows.Count == 0)
                {
                    AddNewRow();
                }
                ((DropDownList)dgServiceItem.Rows[cnt].FindControl("ddlServiceItem")).SelectedValue = dr["ItemId"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbNumber")).Text = dr["Number"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbPrice")).Text = dr["Price"].ToString();
                cnt++;
                AddNewRow();
            }
        }
        #endregion

        #region Db Instance
        private List<List<DbSearchObject>> ServiceItemDbObject(string id)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (ViewState["CurrentTable"] != null)
            {
                string str = string.Empty;
                if (dgServiceItem.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in dgServiceItem.Rows)
                    {
                        lst = new List<DbSearchObject>();
                        str = ((DropDownList)dr.Cells[0].FindControl("ddlServiceItem")).SelectedValue;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "ItemId"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = ((TextBox)dr.Cells[1].FindControl("tbNumber")).Text;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "Number"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = ((TextBox)dr.Cells[2].FindControl("tbPrice")).Text;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "Price"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        lst.Add(new DbSearchObject(
                            "SetId"
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

        private List<DbSearchObject> SetDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            #region TextBox
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
                "CnName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCnName.Text
                ));
            lst.Add(new DbSearchObject(
                "JpName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbJpName.Text
                ));
            lst.Add(new DbSearchObject(
                "EngName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEngName.Text
                ));
            lst.Add(new DbSearchObject(
                "BridalMakeup"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalHairStyle.Text
                ));
            lst.Add(new DbSearchObject(
                "GroomMakeup"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomHairStyle.Text
                ));
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , tbCost.Text
                ));
            lst.Add(new DbSearchObject(
                "Corsage"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCorsage.Text
                ));
            lst.Add(new DbSearchObject(
                "Price"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , tbPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "WeddingFilmingTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbFilmTime.Text
                ));
            lst.Add(new DbSearchObject(
                "FilmingLocation"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbFilmLocation.Text
                ));
            lst.Add(new DbSearchObject(
                "Decoration"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbDecorate.Text
                ));
            lst.Add(new DbSearchObject(
                "Moves"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbMovemont.Text
                ));
            lst.Add(new DbSearchObject(
                "PhotosNum"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbPhotoNumber.Text) ? "0" : tbPhotoNumber.Text
                ));
            lst.Add(new DbSearchObject(
                "Performence"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPerformence.Text
                ));
            lst.Add(new DbSearchObject(
                "RoomId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRoom.Text
                ));
            lst.Add(new DbSearchObject(
                "StayNight"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbStay.Text) ? "0" : tbStay.Text
                ));
            #endregion
            #region DropDownList
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
                "ChurchId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlLocate.SelectedValue
                ));
            if (!string.IsNullOrEmpty(ddlWeddingType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "WeddingCategory"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlWeddingType.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                "Category"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCategory.SelectedValue
                ));
            }
            lst.Add(new DbSearchObject(
                "Staff"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , ddlStaff.SelectedValue
                ));
            #endregion
            #region CheckBox
            lst.Add(new DbSearchObject(
                "Breakfast"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbBreakfast.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Certificate"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbCertificate.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "ChurchCost"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbChurchCost.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Dinner"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbDinner.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "DressIroning"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbIroning.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "IsLegal"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbLegal.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Lounge"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbLounge.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Lunch"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbLunch.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Kickoff"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbMeeting.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Pastor"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbPastor.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "SignPen"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbPen.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "RingPillow"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbPillow.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Rehearsal"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbRehersal.Checked ? "1" : "0"
                ));
            #endregion
            return lst;
        }
        #endregion        
    }
}