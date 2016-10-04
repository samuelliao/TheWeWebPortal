using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                    InitialPage();
                }
            }
        }

        #region Initial Page
        private void InitialPage()
        {
            FirstGridViewRow();
            InitialControl();
            InitialControlWithPermission();
            SetPlaceHolder();
            if (Session["ChurchId"] != null)
            {

                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.ChurchMaintainString
                + " > " + Resources.Resource.ModifyString;
                SetChurchData(Session["ChurchId"].ToString());
            }
            else
            {
                //SetEnableCss();
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.ChurchMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void SetPlaceHolder()
        {
            tbSn.Attributes.Add("placeholder", Resources.Resource.SystemSnString);
            tbName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.NameString);
            tbCnName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.CnNameString);
            tbEngName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.EnglishNameString);
            tbJpName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.JpNameString);
            tbCapacities.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.CapacitiesString);
            tbRedCarpetType.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.RedCarpetTypeString);
            tbMealDescription.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.ServiceAndPriceDescriptionString);
            tbRemark.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.RemarkString);
            tbRedCarpetLength.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.RedCarpetLengthString);
            tbPatioHeight.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PatioHeightString);
            tbPrice.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PriceString);
        }

        private void SetEnableCss()
        {
            ddlCountry.CssClass = "Enable";
            ddlArea.CssClass = "Enable";
            tbName.CssClass = "Enable";
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
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            if (Session["LocateStore"] != null)
            {
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    btnCreate.Visible = false;
                    btnDelete.Visible = false;
                    btnModify.Visible = false;
                    btnClear.Visible = false;
                    dgBookTable.Enabled = false;
                    divPhotoUpload.Attributes["style"] = "display: none;";
                }
            }
            else
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                btnCreate.Visible = item.CanCreate;
                btnCreate.Enabled = item.CanCreate;
                btnDelete.Visible = item.CanDelete;
                btnDelete.Enabled = item.CanDelete;
                btnModify.Visible = item.CanModify;
                btnModify.Enabled = item.CanModify;
            }
        }
        private void TransferToOtherPage(bool reload)
        {
            if (!reload)
            {
                ViewState.Remove("CurrentTable");
                Session.Remove("ChurchId");
                Response.Redirect("~/StoreMgt/ChurchMaintain.aspx", true);
            }
            else
            {
                InitialPage();
            }
        }
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
                if (string.IsNullOrEmpty(Session["ChurchId"].ToString())) return;
                string sql = "UPDATE Church SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["ChurchId"].ToString() + "'";
                if (SysProperty.GenDbCon.ModifyDataInToTable(sql))
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
            ImgFront.ImageUrl = null;
            ImgBack.ImageUrl = null;
            ImgSide.ImageUrl = null;
            ImgOther1.ImageUrl = null;
            ImgMeal.ImageUrl = null;
            ImgBouquet.ImageUrl = null;
            ImgMap.ImageUrl = null;
            ImgDM.ImageUrl = null;

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (Session["ChurchId"] == null) return;
            string id = Session["ChurchId"].ToString();
            List<DbSearchObject> lst = ChurchDbObject(false);
            result = WriteBackChurch(false, lst, id);
            if (!result) return;
            result = WriteBackAppointment(false, AppointmentTimeDbObject(true, id), id);

            if (result)
            {
                TransferToOtherPage(true);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            bool result = false;
            List<DbSearchObject> lst = ChurchDbObject(true);
            result = WriteBackChurch(true, lst, string.Empty);
            if (!result) return;
            string id = GetCreateChurchId(lst);
            if (string.IsNullOrEmpty(id)) return;
            result = WriteBackAppointment(true, AppointmentTimeDbObject(true, id), id);
            if (result)
            {
                Session["ChurchId"] = id;
                TransferToOtherPage(true);
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
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DynamicSn(ddlCountry.SelectedValue);
            SetAreaList(ddlCountry.SelectedValue);
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
            if (dr["Sn"].ToString().Length > 3)
            {
                tbSysSn.Text = dr["Sn"].ToString().Substring(dr["Sn"].ToString().Length - 3, 3);
            }
            else
            {
                tbSysSn.Text = dr["Sn"].ToString();
            }

            tbName.Text = dr["Name"].ToString();
            tbJpName.Text = dr["JpName"].ToString();
            tbCnName.Text = dr["CnName"].ToString();
            tbEngName.Text = dr["EngName"].ToString();
            tbCapacities.Text = dr["Capacities"].ToString();
            tbPatioHeight.Text = dr["PatioHeight"].ToString();
            tbMealDescription.Text = dr["Description"].ToString();
            tbPrice.Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
            tbRedCarpetLength.Text = dr["RedCarpetLong"].ToString();
            tbRedCarpetType.Text = dr["RedCarpetCategory"].ToString();
            tbRemark.Text = dr["Remark"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            ddlArea.SelectedValue = dr["AreaId"].ToString();
            SetChurchBookingTime(id);
            DynamicSn(ddlCountry.SelectedValue);

            #region Image Control
            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"\Church\" + tbSn.Text + @"\Img";
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            RefreshImage(0, ImgFolderPath);
            tbFolderPath.Text = Path.GetDirectoryName(ImgFolderPath);

            string imgMeal = @dr["MealImg"].ToString();
            if (string.IsNullOrEmpty(imgMeal)) imgMeal = SysProperty.ImgRootFolderpath + @"\Church\" + tbSn.Text + @"\Meal";
            else imgMeal = SysProperty.ImgRootFolderpath + imgMeal;
            string ImgFolderMealPath = imgMeal;
            RefreshImage(8, ImgFolderMealPath);

            string imgMap = @dr["MapImg"].ToString();
            if (string.IsNullOrEmpty(imgMap)) imgMap = SysProperty.ImgRootFolderpath + @"\Church\" + tbSn.Text + @"\Map";
            else imgMap = SysProperty.ImgRootFolderpath + imgMap;
            string ImgFolderMapPath = imgMap;
            RefreshImage(6, ImgFolderMapPath);

            string imgDM = @dr["DmImg"].ToString();
            if (string.IsNullOrEmpty(imgDM)) imgDM = SysProperty.ImgRootFolderpath + @"\Church\" + tbSn.Text + @"\Dm";
            else imgDM = SysProperty.ImgRootFolderpath + imgDM;
            string ImgFolderDMPath = imgDM;
            RefreshImage(7, ImgFolderDMPath);

            string imgBouquet = @dr["BouquetImg"].ToString();
            if (string.IsNullOrEmpty(imgBouquet)) imgBouquet = SysProperty.ImgRootFolderpath + @"\Church\" + tbSn.Text + @"\Bouquet";
            else imgBouquet = SysProperty.ImgRootFolderpath + imgBouquet;
            string ImgFolderBouquetPath = imgBouquet;
            RefreshImage(5, ImgFolderBouquetPath);
            #endregion

            if (Session["LocateStore"] != null)
            {
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    ddlCountry.CssClass = "Enable";
                    ddlArea.CssClass = "Enable";
                    tbName.CssClass = "Enable";
                    tbSn.Enabled = false;
                    tbRemark.Enabled = false;
                    tbRedCarpetType.Enabled = false;
                    tbRedCarpetLength.Enabled = false;
                    tbPrice.Enabled = false;
                    tbPatioHeight.Enabled = false;
                    tbName.Enabled = false;
                    tbMealDescription.Enabled = false;
                    tbJpName.Enabled = false;
                    tbFolderPath.Enabled = false;
                    tbEngName.Enabled = false;
                    tbCnName.Enabled = false;
                    tbCapacities.Enabled = false;
                    ddlArea.Enabled = false;
                    ddlCountry.Enabled = false;
                    divPhotoUpload.Attributes["style"] = "display: none;";
                    dgBookTable.Enabled = false;
                }
            }
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
            if (dgBookTable.Rows.Count == 0)
            {
                AddNewRow();
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ((TextBox)dgBookTable.Rows[cnt].FindControl("tbId")).Text = dr["Id"].ToString();
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
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dr = dt.NewRow();
            dr["Id"] = string.Empty;
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
                        TextBox TextId =
                          (TextBox)dgBookTable.Rows[rowIndex].Cells[0].FindControl("tbId");
                        TextBox TextStart =
                          (TextBox)dgBookTable.Rows[rowIndex].Cells[1].FindControl("tbStart");
                        TextBox TextEnd =
                          (TextBox)dgBookTable.Rows[rowIndex].Cells[2].FindControl("tbEnd");
                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["Id"] = TextId.Text;
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
                        TextBox TextId = (TextBox)dgBookTable.Rows[rowIndex].Cells[0].FindControl("tbId");
                        TextBox TextStart = (TextBox)dgBookTable.Rows[rowIndex].Cells[1].FindControl("tbStart");
                        TextBox TextEnd = (TextBox)dgBookTable.Rows[rowIndex].Cells[2].FindControl("tbEnd");

                        if (TextStart == null) continue;
                        TextId.Text = dt.Rows[i]["Id"] == null ? string.Empty : dt.Rows[i]["Id"].ToString();
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
                        TextBox TextId = (TextBox)dgBookTable.Rows[rowIndex].Cells[0].FindControl("tbId");
                        TextBox TextStart = (TextBox)dgBookTable.Rows[rowIndex].Cells[1].FindControl("tbStart");
                        TextBox TextEnd = (TextBox)dgBookTable.Rows[rowIndex].Cells[2].FindControl("tbEnd");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Id"] = TextId.Text;
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

        #region Db Instance
        private List<DbSearchObject> ChurchDbObject(bool isCreate)
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
            return lst;
        }

        private List<List<DbSearchObject>> AppointmentTimeDbObject(bool isCreate, string id)
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
                        str = SysProperty.Util.ParseDateTime("Time", ((TextBox)dr.Cells[1].FindControl("tbStart")).Text);
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "StartTime"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = SysProperty.Util.ParseDateTime("Time", ((TextBox)dr.Cells[2].FindControl("tbEnd")).Text);
                        if (!string.IsNullOrEmpty(str))
                        {
                            lst.Add(new DbSearchObject(
                                "EndTime"
                                , AtrrTypeItem.Date
                                , AttrSymbolItem.Equal
                                , str
                                ));
                        }
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
            }
            return result;
        }
        #endregion

        #region DB data writeback
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
        #endregion

        private void DynamicSn(string cid)
        {
            string sn = "CH";
            if (!string.IsNullOrEmpty(cid))
            {
                sn += SysProperty.GetCountryById(cid)["Code"].ToString().Trim();
            }
            tbSn.Text = sn + tbSysSn.Text;
        }

        #region Image Related
        private void RefreshImage(int type, string path)
        {
            switch (type)
            {
                case 1:
                    ImgFront.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 2:
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 4:
                    ImgOther1.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 5:
                    ImgBouquet.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_bouquet.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 6:
                    ImgMap.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_map.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 7:
                    ImgDM.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_dm.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 8:
                    ImgMeal.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_meal.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther1.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
            }
        }

        private void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            bool needRefresh = false;
            CheckFolder(tbFolderPath.Text);
            string folderPath = string.Empty;
            
            for (int i = 1; i <= 8; i++)
            {
                FileUpload upload = divUpload.FindControl("FileUpload" + i) as FileUpload;
                if (upload == null) continue;
                if (upload.HasFile)
                {
                    folderPath = tbFolderPath.Text + "\\" + FolderName(i);
                    CheckFolder(folderPath);
                    upload.PostedFile.SaveAs(folderPath + "\\" + tbSn.Text + "_" + (i > 4 ? FolderName(i).Trim().ToLower() : i.ToString()) + ".jpg");
                    needRefresh = true;
                }
            }

            if (needRefresh)
            {
                RefreshImage(0, tbFolderPath.Text + @"\\Img");
                for (int i = 5; i <= 8; i++)
                {
                    RefreshImage(i, tbFolderPath + "\\" + FolderName(i));
                }
            }
        }

        private string FolderName(int cnt)
        {
            switch (cnt)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return "Img";
                case 5:
                    return "Bouquet";
                case 6:
                    return "Map";
                case 7:
                    return "Dm";
                case 8:
                    return "Meal";
                default:
                    return string.Empty;
            }
        }
        #endregion
        
    }
}