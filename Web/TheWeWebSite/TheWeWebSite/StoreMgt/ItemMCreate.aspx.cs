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
                    InitialPage();
                }
            }
        }

        private void InitialPage()
        {
            InitialAllDropDownList();
            FirstGridViewRow_dgChurchServiceItem();
            FirstGridViewRow_dgCutomServiceItem();
            InitialControlWithPermission();
            TextHint();

            if (Session["SetId"] != null)
            {
                labelPageTitle.Text = Resources.Resource.OrderMgtString
                + " > " + Resources.Resource.ProductMaintainString
                + " > " + Resources.Resource.ModifyString;
                btnModify.Visible = true;
                btnDelete.Visible = true;
                SetSetAllData(Session["SetId"].ToString());
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.OrderMgtString
                + " > " + Resources.Resource.ProductMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void TextHint()
        {
            tbSn.Attributes.Add("placeholder", Resources.Resource.SystemSnString);
            tbName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.NameString);
            tbCnName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.CnNameString);
            tbEngName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.EnglishNameString);
            tbJpName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.JpNameString);
            tbBridalHairStyle.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BridalMakeupString);
            tbGroomHairStyle.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.GroomMakeupString);
            tbFilmTime.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.FilmingTimeString);
            tbFilmLocation.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.FilmingLocationString);
            tbMovemont.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.TransportationString);
            tbPhotoNumber.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.PhotoNumberString);
            tbStay.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.StayNightString);
            tbRoom.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.RoomTypeString);
            tbCorsage.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.CorsageString);
            tbDecorate.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.ChurchArrangementsString);
            tbPerformence.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.WeddingPerformanceString);
            tbCost.Attributes.Add("placeHolder", "0.00");
            tbPrice.Attributes.Add("placeHolder", "0.00");


        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage(bool reload)
        {
            if (reload)
            {
                InitialPage();
            }
            else
            {
                Session.Remove("SetId");
                ViewState.Remove("CurrentTable");
                Response.Redirect("ItemMaintain.aspx", true);
            }
        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            btnDelete.Visible = item.CanDelete;
            btnDelete.Enabled = item.CanDelete;
            btnModify.Visible = item.CanModify;
            btnModify.Enabled = item.CanModify;
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                DisplayLevelPriceTable(true);
                BindPriceData(string.Empty);
            }
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
            StoreList();
            InitialCurrency();
        }
        private void InitialCurrency()
        {
            ddlCostCurrency.Items.Clear();
            ddlPriceCurrency.Items.Clear();
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Currency), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCostCurrency.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                    ddlPriceCurrency.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStore.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        + "(" + dr["Sn"].ToString() + ")"
                        , dr["Id"].ToString()));
                }
                ddlStore.SelectedValue = ((DataRow)Session["LocateStore"])["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
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
            FirstGridViewRow_dgChurchServiceItem();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow dr = SysProperty.GetAreaById(ddlArea.SelectedValue);
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            LocationDropDownList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            FirstGridViewRow_dgChurchServiceItem();
        }

        protected void ddlLocate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow dr = SysProperty.GetChurchById(ddlLocate.SelectedValue);
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            ddlArea.SelectedValue = dr["AreaId"].ToString();
            FirstGridViewRow_dgChurchServiceItem();
        }
        #endregion
        #endregion

        #region Button Control
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage(false);
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
                    TransferToOtherPage(false);
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
            if (Session["LocateStore"] != null)
            {
                if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    tbCnName.Text = string.Empty;
                    tbName.Text = string.Empty;
                    tbBridalHairStyle.Text = string.Empty;
                    tbCorsage.Text = string.Empty;
                    tbCost.Text = "0";
                    tbDecorate.Text = string.Empty;
                    tbFilmLocation.Text = string.Empty;
                    tbFilmTime.Text = string.Empty;
                    tbGroomHairStyle.Text = string.Empty;
                    tbMovemont.Text = string.Empty;
                    tbPerformence.Text = string.Empty;
                    tbPhotoNumber.Text = string.Empty;
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
                    ddlCategory.SelectedIndex = 0;
                    ddlArea.SelectedIndex = 0;
                    ddlLocate.SelectedIndex = 0;
                    ddlStaff.SelectedIndex = 0;
                    ddlCountry.SelectedIndex = 0;
                    ddlWeddingType.SelectedIndex = 0;
                    FirstGridViewRow_dgChurchServiceItem();
                }
            }
            FirstGridViewRow_dgCutomServiceItem();
            tbPrice.Text = tbCost.Text;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            //if (ComparePrice())
            //{
            //    ShowErrorMsg(Resources.Resource.ProductPriceWarnString);
            //    return;
            //}
            labelUpdateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (Session["SetId"] == null) { ShowErrorMsg(Resources.Resource.ModifyFailedString); return; }
            string id = Session["SetId"].ToString();
            if (string.IsNullOrEmpty(id)) { ShowErrorMsg(Resources.Resource.ModifyFailedString); return; }
            bool result = WriteBackInfo(MsSqlTable.ProductSet, false, SetDbObject(false), " Where Id='" + id + "'");
            if (!result) { ShowErrorMsg(Resources.Resource.ModifyFailedString); return; }
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                && ddlStore.SelectedValue == ((DataRow)Session["LocateStore"])["Id"].ToString())
            {
                result = WriteBackServiceItem(MsSqlTable.ProductSetChurchServiceItem, false, ServiceItemDbObject(true, "Church", id), id);
                result = WriteBackStoreLvPrice(false, StoreLvPriceDbObject(false, id));
            }
            result = WriteBackServiceItem(MsSqlTable.ProductSetServiceItem, false, ServiceItemDbObject(true, "Custom", id), id);
            if (result)
            {
                TransferToOtherPage(true);
                ShowErrorMsg(Resources.Resource.ModifySuccessString);
            }
            else { ShowErrorMsg(Resources.Resource.ModifyFailedString); }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //if (ComparePrice())
            //{
            //    ShowErrorMsg(Resources.Resource.ProductPriceWarnString);
            //    return;
            //}
            labelUpdateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            List<DbSearchObject> lst = SetDbObject(true);
            bool result = WriteBackInfo(MsSqlTable.ProductSet, true, lst, string.Empty);
            if (!result) { ShowErrorMsg(Resources.Resource.ModifyFailedString); return; }
            string id = GetCreateSetId(lst);
            if (string.IsNullOrEmpty(id)) { ShowErrorMsg(Resources.Resource.ModifyFailedString); return; }
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                && ddlStore.SelectedValue == ((DataRow)Session["LocateStore"])["Id"].ToString())
            {
                result = WriteBackServiceItem(MsSqlTable.ProductSetChurchServiceItem, false, ServiceItemDbObject(true, "Church", id), id);
                result = WriteBackStoreLvPrice(true, StoreLvPriceDbObject(true, id));
            }
            result = WriteBackServiceItem(MsSqlTable.ProductSetServiceItem, false, ServiceItemDbObject(true, "Custom", id), id);
            if (result)
            {
                Session["SetId"] = id;
                TransferToOtherPage(true);
                ShowErrorMsg(Resources.Resource.CreateSuccessString);
            }
            else { ShowErrorMsg(Resources.Resource.CreateFailedString); return; }
        }

        private bool ComparePrice()
        {
            bool result = false;
            if (divForStore.Visible)
            {
                decimal price = SysProperty.Util.ParseMoney(tbPrice.Text);
                decimal cost = SysProperty.Util.ParseMoney(tbCost.Text);
                return price < cost;
            }
            return result;
        }
        #endregion

        #region Church Service Item Table
        private void FirstGridViewRow_dgChurchServiceItem()
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
            dgChurchServiceItem.DataSource = dt;
            dgChurchServiceItem.DataBind();
        }

        private void AddNewRow_dgChurchServiceItem()
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
                            (DropDownList)dgChurchServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart =
                          (TextBox)dgChurchServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd =
                          (TextBox)dgChurchServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");


                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextStart.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextEnd.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    dgChurchServiceItem.DataSource = dtCurrentTable;
                    dgChurchServiceItem.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData_dgChurchServiceItem();
        }

        private void SetPreviousData_dgChurchServiceItem()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList DdlItem = (DropDownList)dgChurchServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart = (TextBox)dgChurchServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd = (TextBox)dgChurchServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
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

        private void SetRowData_dgChurchServiceItem()
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
                        DropDownList DdlItem = (DropDownList)dgChurchServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextNumber = (TextBox)dgChurchServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextPrice = (TextBox)dgChurchServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
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

        protected void btnAddRowChurchServiceItem_Click(object sender, EventArgs e)
        {
            AddNewRow_dgChurchServiceItem();
        }

        protected void dgChurchServiceItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData_dgChurchServiceItem();
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
                    dgChurchServiceItem.DataSource = dt;
                    dgChurchServiceItem.DataBind();

                    SetPreviousData_dgChurchServiceItem();
                }
            }
        }
        protected void dgChurchServiceItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                DropDownList ddlService = (DropDownList)e.Row.FindControl("ddlServiceItem");
                ddlService.Items.Add(new ListItem(Resources.Resource.ServiceItemSelectRemindString, string.Empty));
                if (string.IsNullOrEmpty(ddlLocate.SelectedValue)) return;
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ServiceItem Where IsStore = 0 And IsDelete=0 And SupplierId = '" + ddlLocate.SelectedValue + "'");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlService.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()
                        ));
                }
                ddlService.SelectedIndex = 0;
            }
        }
        protected void tbPrice_TextChanged(object sender, EventArgs e)
        {
            //bool result = false;
            //decimal dec = 0;
            //result = decimal.TryParse(((TextBox)sender).Text, out dec);
            //if (result)
            //{
            //    //tbPrice.Text = (SysProperty.Util.ParseMoney(tbPrice.Text) + dec).ToString();
            //}
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
        private DataSet GetDataFromDb(string sql)
        {
            return (DataSet)InvokeDbControlFunction(sql, true);
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

        private bool WriteBackServiceItem(MsSqlTable table, bool isInsert, List<List<DbSearchObject>> lst, string id)
        {
            string condStr = " Where SetId = '" + id + "'";
            if (!isInsert)
            {
                SysProperty.GenDbCon.ModifyDataInToTable("Delete From " + SysProperty.Util.MsSqlTableConverter(table) + " " + condStr);
            }
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                result = result | WriteBackInfo(table, true, item, condStr);
            }
            return result;
        }

        private bool WriteBackStoreLvPrice(bool isInsert, List<List<DbSearchObject>> lst)
        {
            string condStr = "";
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                if (!isInsert)
                {
                    condStr = " Where Id = '" + item[0].AttrValue + "'";
                }
                result = result & WriteBackInfo(MsSqlTable.StoreLvSetPrice, isInsert, item, condStr);
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
            ddlStore.SelectedValue = dr["StoreId"].ToString();
            ddlArea.SelectedValue = dr["AreaId"].ToString();
            ddlCategory.SelectedValue = dr["Category"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            ddlLocate.SelectedValue = dr["ChurchId"].ToString();
            tbName.Text = dr["Name"].ToString();
            tbCnName.Text = dr["CnName"].ToString();
            tbJpName.Text = dr["JpName"].ToString();
            tbEngName.Text = dr["EngName"].ToString();
            tbPhotoNumber.Text = dr["PhotosNum"].ToString();
            labelBaseId.Text = dr["BaseId"].ToString();
            tbBridalHairStyle.Text = dr["BridalMakeup"].ToString();
            tbCorsage.Text = dr["Corsage"].ToString();
            tbDecorate.Text = dr["Decoration"].ToString();
            tbFilmLocation.Text = dr["FilmingLocation"].ToString();
            tbFilmTime.Text = dr["WeddingFilmingTime"].ToString();
            tbGroomHairStyle.Text = dr["GroomMakeup"].ToString();
            tbMovemont.Text = dr["Moves"].ToString();
            tbPerformence.Text = dr["Performence"].ToString();
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
            ddlStaff.SelectedValue = dr["Staff"].ToString();
            ddlWeddingType.SelectedValue = dr["WeddingCategory"].ToString();

            labelUpdateTime.Text = dr["UpdateTime"].ToString();

            decimal cost = SysProperty.Util.ParseMoney(dr["Cost"].ToString());
            tbCost.Text = cost.ToString("#0.00");
            ddlCostCurrency.SelectedValue = dr["CostCurrencyId"].ToString();
            decimal price = SysProperty.Util.ParseMoney(dr["Price"].ToString());
            tbPrice.Text = price > 0 ? price.ToString("#0.00") : cost.ToString("#0.00");
            ddlPriceCurrency.SelectedValue = dr["PriceCurrencyId"].ToString();
            if (string.IsNullOrEmpty(labelBaseId.Text))
            {
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    DisplayLevelPriceTable(false);
                    labelBaseId.Text = id;
                    GetCostAndPrice(
                        string.IsNullOrEmpty(labelBaseId.Text)
                        , labelBaseId.Text
                        , SplitString(ddlStore.SelectedItem.Text, "(", 1).Replace(")", ""));
                    LoadDataFromBasedId(labelBaseId.Text);
                }
                else
                {
                    DisplayLevelPriceTable(true);
                    BindPriceData(id);
                }
            }
            else
            {
                DisplayLevelPriceTable(false);
                GetCostAndPrice(
                    string.IsNullOrEmpty(labelBaseId.Text)
                    , labelBaseId.Text
                    , ddlStore.SelectedValue);
                LoadDataFromBasedId(labelBaseId.Text);
            }

            SetServiceItemTable(id);
            FirstGridViewRow_dgChurchServiceItem();
            SetServiceChurchItemTable(string.IsNullOrEmpty(labelBaseId.Text) ? id : labelBaseId.Text);

            SetControlWithPermission();
        }

        private void LoadDataFromBasedId(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            DataSet dsBase = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ProductSet), " Where Id='" + id + "'");
            if (SysProperty.Util.IsDataSetEmpty(dsBase)) return;
            DataRow drBase = dsBase.Tables[0].Rows[0];
            tbBridalHairStyle.Text = drBase["BridalMakeup"].ToString();
            tbCorsage.Text = drBase["Corsage"].ToString();
            tbDecorate.Text = drBase["Decoration"].ToString();
            tbFilmLocation.Text = drBase["FilmingLocation"].ToString();
            tbFilmTime.Text = drBase["WeddingFilmingTime"].ToString();
            tbGroomHairStyle.Text = drBase["GroomMakeup"].ToString();
            tbMovemont.Text = drBase["Moves"].ToString();
            tbPerformence.Text = drBase["Performence"].ToString();
            tbRoom.Text = drBase["RoomId"].ToString();
            tbStay.Text = drBase["StayNight"].ToString();
            cbBreakfast.Checked = bool.Parse(drBase["Breakfast"].ToString());
            cbCertificate.Checked = bool.Parse(drBase["Certificate"].ToString());
            cbChurchCost.Checked = bool.Parse(drBase["ChurchCost"].ToString());
            cbDinner.Checked = bool.Parse(drBase["Dinner"].ToString());
            cbIroning.Checked = bool.Parse(drBase["DressIroning"].ToString());
            cbLegal.Checked = bool.Parse(drBase["IsLegal"].ToString());
            cbLounge.Checked = bool.Parse(drBase["Lounge"].ToString());
            cbLunch.Checked = bool.Parse(drBase["Lunch"].ToString());
            cbMeeting.Checked = bool.Parse(drBase["Kickoff"].ToString());
            cbPastor.Checked = bool.Parse(drBase["Pastor"].ToString());
            cbPen.Checked = bool.Parse(drBase["SignPen"].ToString());
            cbPillow.Checked = bool.Parse(drBase["RingPillow"].ToString());
            cbRehersal.Checked = bool.Parse(drBase["Rehearsal"].ToString());
            ddlStaff.SelectedValue = drBase["Staff"].ToString();
            ddlWeddingType.SelectedValue = drBase["WeddingCategory"].ToString();
        }

        private void GetCostAndPrice(bool hasBased, string setId, string storeId)
        {
            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                if (storeId != ((DataRow)Session["LocateStore"])["Id"].ToString())
                {
                    string condSql = " Where IsDelete=0 And SetId='" + setId
                        + "' And StoreLv=" + ((DataRow)Session["LocateStore"])["GradeLv"].ToString();
                    DataSet ds = GetDataFromDb("StoreLvSetPrice", condSql);
                    if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                    tbCost.Text = SysProperty.Util.ParseMoney(ds.Tables[0].Rows[0]["Price"].ToString()).ToString("#0.00");
                    tbPrice.Text = SysProperty.Util.ParseMoney(tbPrice.Text) == 0 ? tbCost.Text : tbPrice.Text;
                    try
                    {
                        ddlCostCurrency.SelectedValue = ds.Tables[0].Rows[0]["Currency"].ToString();
                        ddlPriceCurrency.SelectedValue = ds.Tables[0].Rows[0]["Currency"].ToString();
                    }
                    catch { }
                }
            }

        }

        private void SetControlWithPermission()
        {
            if (!string.IsNullOrEmpty(labelBaseId.Text))
            {
                tbBridalHairStyle.Enabled = false;
                //tbCnName.Enabled = false;
                tbCorsage.Enabled = false;
                tbCost.Enabled = false;
                tbDecorate.Enabled = false;
                //tbEngName.Enabled = false;
                tbFilmLocation.Enabled = false;
                tbFilmTime.Enabled = false;
                tbGroomHairStyle.Enabled = false;
                //tbJpName.Enabled = false;
                tbMovemont.Enabled = false;
                //tbName.Enabled = false;
                tbPerformence.Enabled = false;
                //tbPhotoNumber.Enabled = false;
                tbRoom.Enabled = false;
                tbSn.Enabled = false;
                tbStay.Enabled = false;
                ddlArea.Enabled = false;
                ddlArea.CssClass = "Enable";
                ddlCategory.Enabled = false;
                ddlCategory.CssClass = "Enable";
                ddlCountry.Enabled = false;
                ddlCountry.CssClass = "Enable";
                ddlLocate.Enabled = false;
                ddlLocate.CssClass = "Enable";
                ddlStaff.Enabled = false;
                ddlStore.Enabled = false;
                ddlWeddingType.Enabled = false;
                ddlWeddingType.CssClass = "Enable";
                ddlCostCurrency.Enabled = false;
                cbBreakfast.Enabled = false;
                cbCertificate.Enabled = false;
                cbChurchCost.Enabled = false;
                cbDinner.Enabled = false;
                cbIroning.Enabled = false;
                cbLegal.Enabled = false;
                cbLounge.Enabled = false;
                cbLunch.Enabled = false;
                cbMeeting.Enabled = false;
                cbPastor.Enabled = false;
                cbPen.Enabled = false;
                cbPillow.Enabled = false;
                cbRehersal.Enabled = false;
                dgChurchServiceItem.Enabled = false;
                dgChurchServiceItem.ShowFooter = false;
            }

            if (ddlStore.SelectedValue != ((DataRow)Session["LocateStore"])["Id"].ToString())
            {
                btnModify.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void SetServiceItemTable(string id)
        {
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ProductSetServiceItem Where IsDelete = 0 And SetId='" + id + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgCutomServiceItem.Rows.Count == 0)
                {
                    AddNewRow_dgCutomServiceItem();
                }
                ((DropDownList)dgCutomServiceItem.Rows[cnt].FindControl("ddlServiceItem")).SelectedValue = dr["ItemId"].ToString();
                ((TextBox)dgCutomServiceItem.Rows[cnt].FindControl("tbNumber")).Text = dr["Number"].ToString();
                ((TextBox)dgCutomServiceItem.Rows[cnt].FindControl("tbPrice")).Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
                cnt++;
                AddNewRow_dgCutomServiceItem();
            }
        }
        private void SetServiceChurchItemTable(string id)
        {
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ProductSetChurchServiceItem Where IsDelete = 0 And SetId='" + id + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgChurchServiceItem.Rows.Count == 0)
                {
                    AddNewRow_dgChurchServiceItem();
                }
                ((DropDownList)dgChurchServiceItem.Rows[cnt].FindControl("ddlServiceItem")).SelectedValue = dr["ItemId"].ToString();
                ((TextBox)dgChurchServiceItem.Rows[cnt].FindControl("tbNumber")).Text = dr["Number"].ToString();
                ((TextBox)dgChurchServiceItem.Rows[cnt].FindControl("tbPrice")).Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
                cnt++;
                AddNewRow_dgChurchServiceItem();
            }
        }
        #endregion

        #region Db Instance
        private List<List<DbSearchObject>> ServiceItemDbObject(bool isCreate, string type, string id)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            string str = string.Empty;
            GridView gridView;
            if (type == "Custom") gridView = dgCutomServiceItem;
            else gridView = dgChurchServiceItem;
            if (gridView.Rows.Count > 0)
            {
                foreach (GridViewRow dr in gridView.Rows)
                {
                    lst = new List<DbSearchObject>();
                    str = ((DropDownList)dr.Cells[0].FindControl("ddlServiceItem")).SelectedValue;
                    if (string.IsNullOrEmpty(str)) continue;
                    lst.Add(new DbSearchObject(
                        "ItemId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , str
                        ));
                    str = ((TextBox)dr.Cells[1].FindControl("tbNumber")).Text;
                    if (string.IsNullOrEmpty(str)) continue;
                    lst.Add(new DbSearchObject(
                        "Number"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , str
                        ));
                    str = ((TextBox)dr.Cells[2].FindControl("tbPrice")).Text;
                    if (string.IsNullOrEmpty(str)) continue;
                    lst.Add(new DbSearchObject(
                        "Price"
                        , AtrrTypeItem.String
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
                    result.Add(lst);
                }
            }
            return result;
        }
        private List<DbSearchObject> SetDbObject(bool isCreate)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            #region TextBox
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , tbCost.Text
                ));
            lst.Add(new DbSearchObject(
            "Price"
            , AtrrTypeItem.Integer
            , AttrSymbolItem.Equal
            , tbPrice.Text
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
                "Corsage"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCorsage.Text
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
            lst.Add(new DbSearchObject(
                "CostCurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCostCurrency.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "PriceCurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlPriceCurrency.SelectedValue
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
            lst.Add(new DbSearchObject(
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["LocateStore"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , labelUpdateTime.Text
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
            if (!string.IsNullOrEmpty(labelBaseId.Text))
            {
                lst.Add(new DbSearchObject(
                    "BaseId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , labelBaseId.Text
                    ));
            }
            return lst;
        }
        private List<List<DbSearchObject>> StoreLvPriceDbObject(bool isCreate, string setId)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            string str = string.Empty;
            int rowCnt = 3;
            if (PriceTable.Rows.Count > 0)
            {
                foreach (GridViewRow dr in PriceTable.Rows)
                {
                    lst = new List<DbSearchObject>();
                    str = PriceTable.DataKeys[dr.RowIndex].Value.ToString();
                    if (!string.IsNullOrEmpty(str) && !isCreate)
                    {
                        lst.Add(new DbSearchObject(
                            "Id"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , str
                            ));
                    }
                    str = dr.Cells[1].Text;
                    rowCnt -= int.Parse(str);
                    if (string.IsNullOrEmpty(str)) continue;
                    lst.Add(new DbSearchObject(
                        "StoreLv"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , str
                        ));

                    str = ((TextBox)dr.Cells[2].FindControl("tbStorePrice")).Text;
                    if (string.IsNullOrEmpty(str))
                    {
                        lst.Add(new DbSearchObject(
                            "Price"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , tbCost.Text
                            ));
                        lst.Add(new DbSearchObject(
                            "Currency"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ddlCostCurrency.SelectedValue
                            ));
                    }
                    else
                    {
                        lst.Add(new DbSearchObject(
                            "Price"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = ((DropDownList)dr.Cells[2].FindControl("ddlStoreCurrency")).SelectedValue;
                        lst.Add(new DbSearchObject(
                            "Currency"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , str
                            ));
                    }
                    lst.Add(new DbSearchObject(
                        "SetId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , setId
                        ));
                    lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                        ));
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
                    result.Add(lst);
                }
            }
            return result;
        }
        #endregion

        #region Custom Service Item Table
        protected void dgCutomServiceItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                DropDownList ddlService = (DropDownList)e.Row.FindControl("ddlServiceItem");
                ddlService.Items.Add(new ListItem(Resources.Resource.ServiceItemSelectRemindString, string.Empty));
                string sql = "Select * From ServiceItem Where IsDelete = 0 And StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlService.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()
                        ));
                }
                ddlService.SelectedIndex = 0;
            }
        }

        protected void dgCutomServiceItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData_dgCutomServiceItem();
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    dgCutomServiceItem.DataSource = dt;
                    dgCutomServiceItem.DataBind();

                    SetPreviousData_dgCutomServiceItem();
                }
            }
        }

        private void FirstGridViewRow_dgCutomServiceItem()
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

            ViewState["CurrentTable2"] = dt;
            dgCutomServiceItem.DataSource = dt;
            dgCutomServiceItem.DataBind();
        }

        private void AddNewRow_dgCutomServiceItem()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList DdlItem =
                            (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart =
                          (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd =
                          (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");


                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextStart.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextEnd.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable2"] = dtCurrentTable;

                    dgCutomServiceItem.DataSource = dtCurrentTable;
                    dgCutomServiceItem.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData_dgCutomServiceItem();
        }

        private void SetPreviousData_dgCutomServiceItem()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList DdlItem = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
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

        private void SetRowData_dgCutomServiceItem()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList DdlItem = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextNumber = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextPrice = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextNumber.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextPrice.Text;
                        rowIndex++;
                    }

                    ViewState["CurrentTable2"] = dtCurrentTable;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        protected void btnAddRowCutomServiceItem_Click(object sender, EventArgs e)
        {
            AddNewRow_dgCutomServiceItem();
        }
        #endregion

        private string SplitString(string str, string splitExp, int index)
        {
            return str.Contains(splitExp) ? str.Split(splitExp.ToCharArray())[index] : str;
        }

        #region Price Table
        private void DisplayLevelPriceTable(bool isDisplay)
        {
            divForHoldingCompany.Visible = isDisplay;
            divForStore.Visible = !isDisplay;
        }

        private void BindPriceData(string setId)
        {
            string sql = string.Empty;
            if (!string.IsNullOrEmpty(setId))
            {
                sql = "IF((Select COUNT(*) From StoreLvSetPrice Where IsDelete=0 And SetId = '" + setId + "') != 0)"
                    + " BEGIN"
                    + " SELECT Id,[Price],[StoreLv],Currency FROM StoreLvSetPrice Where IsDelete = 0 And SetId = '" + setId + "' Order by StoreLv"
                    + " END"
                    + " ELSE"
                    + " BEGIN"
                    + " Select Distinct GradeLv As StoreLv, '' As Id, '' As Currency, 0 as Price From Store Where IsDelete = 0 And GradeLv!=0 Order by GradeLv"
                    + " END";
            }
            else
            {
                sql = "Select Distinct GradeLv As StoreLv, '' As Id, '' As Currency, 0 as Price From Store Where IsDelete = 0 And GradeLv!=0 Order by GradeLv";
            }
            DataSet ds = GetDataFromDb(sql);
            if (ds.Tables[0].Rows.Count < 2)
            {

            }
            PriceTable.DataSource = ds;
            PriceTable.DataBind();
        }
        protected void PriceTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                #region Initial Currency Control
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlStoreCurrency");
                ddl.Items.Clear();
                foreach (ListItem item in ddlCostCurrency.Items)
                {
                    ddl.Items.Add(new ListItem(item.Text, item.Value));
                }
                ddl.SelectedValue = dataItem1["Currency"].ToString();
                #endregion

                #region Price 
                decimal price = SysProperty.Util.ParseMoney(dataItem1["Price"].ToString());
                if (price <= 0)
                {
                    ((TextBox)e.Row.FindControl("tbStorePrice")).Text = tbCost.Text;
                }
                else
                {
                    ((TextBox)e.Row.FindControl("tbStorePrice")).Text = price.ToString("#0.00");
                }
                #endregion

            }
        }
        #endregion
    }
}