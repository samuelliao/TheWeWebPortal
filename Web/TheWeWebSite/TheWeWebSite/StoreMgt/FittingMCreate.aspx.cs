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
    public partial class FittingMCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    if (Session["FittingId"] != null && Session["FittingCategory"]!=null)
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.FittingMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        SetAllData(Session["FittingCategory"].ToString(), Session["FittingId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.FittingMaintainString
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
            Session.Remove("FittingId");
            Session.Remove("FittingCategory");
            Server.Transfer("FittingMaintain.aspx", true);
        }

        private void InitialControls()
        {
            FittingCategoryList();
            FittingTypeList();
            StatusList();
            EarringDropDownList();
            LengthDropDownList();
            GenderList();
        }

        private void SetDivByAccessoryCategory(string category)
        {
            switch (category)
            {
                case "AccessoryMan":
                    divLength.Visible = true;
                    break;
                case "DressGloves":
                    divGender.Visible = true;
                    divLength.Visible = true;
                    break;
                case "DressEarring":
                    divColor2.Visible = true;
                    divMaterial2.Visible = true;
                    divRelatedCategory.Visible = true;
                    divRelatedSn.Visible = true;
                    divEarringType.Visible = true;
                    break;
                case "DressNecklace":
                    divColor2.Visible = true;
                    divMaterial2.Visible = true;
                    divRelatedCategory.Visible = true;
                    divRelatedSn.Visible = true;
                    break;
                case "DressVeil":
                    divMaterial1.Visible = false;
                    divLength.Visible = true;
                    break;
                case "DressClogs":
                    divRelatedCategory.Visible = true;
                    divRelatedSn.Visible = true;
                    break;
                case "DressBouquet":
                case "DressBracelet":
                case "DressHeadwear":
                    divColor2.Visible = true;
                    divMaterial2.Visible = true;
                    break;
                case "DressShawl":
                case "AccessoryOther":
                case "AccessoryRingPillow":
                default:
                    break;
            }
        }

        #region DropDownList
        private void GenderList()
        {
            ddlGender.Items.Clear();
            ddlGender.Items.Add(new ListItem(Resources.Resource.FemaleString, "0"));
            ddlGender.Items.Add(new ListItem(Resources.Resource.MaleString, "1"));
        }
        private void EarringDropDownList()
        {
            ddlEarringType.Items.Clear();
            ddlEarringType.Items.Add(new ListItem(Resources.Resource.EarPiercingString, "0"));
            ddlEarringType.Items.Add(new ListItem(Resources.Resource.EarClipString, "1"));
        }
        private void LengthDropDownList()
        {
            ddlLength.Items.Clear();
            ddlLength.Items.Add(new ListItem(Resources.Resource.ExtraShortString, "0"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.ShortString, "1"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.MediumString, "2"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.LongString, "3"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.ExtraLongString, "4"));
            ddlLength.SelectedValue = "2";
        }
        private void FittingCategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where Type='Accessory' Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Description"].ToString()
                    ));
            }
        }
        private void FittingTypeList()
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where IsDelete=0 And Type='"
                + GetTypeNameFromCategory(ddlCategory.SelectedValue) + "' Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds))
            {
                ddlType.Enabled = false;
            }
            else
            {
                ddlType.Enabled = true;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlType.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()
                        ));
                }
            }
        }
        private void StatusList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressStatus Where IsDelete = 0";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            FittingTypeList();
            SetDivByAccessoryCategory(ddlCategory.SelectedValue);
        }
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSn.Text) || string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            if (SysProperty.GenDbCon.IsSnDuplicate(ddlCategory.SelectedValue ,tbSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            bool result = WriteBackData(ddlCategory.SelectedValue, AccessoryDbObject(), true, string.Empty);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSn.Text)) return;
            if (Session["FittingId"] == null || Session["FittingCategory"] == null) return;
            bool result = WriteBackData(ddlCategory.SelectedValue, AccessoryDbObject(), false, Session["FittingId"].ToString());
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbColor1.Text = string.Empty;
            tbColor2.Text = string.Empty;
            tbCost.Text = string.Empty;
            tbMaterial1.Text = string.Empty;
            tbMaterial2.Text = string.Empty;
            tbOptionalPrice.Text = string.Empty;
            tbRelatedSn.Text = string.Empty;
            tbRentPrice.Text = string.Empty;
            tbSalesPrice.Text = string.Empty;
            tbSn.Text = string.Empty;
            ddlCategory.SelectedIndex = 0;
            ddlLength.SelectedIndex = 0;
            ddlRelatedCategory.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ddlSupplier.SelectedIndex = 0;
            ddlType.SelectedIndex = 0;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["FittingCategory"] == null || Session["FittingId"] == null) return;
                if (string.IsNullOrEmpty(Session["ChurchId"].ToString())) return;
                string sql = "UPDATE " + Session["FittingCategory"].ToString() + " SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["FittingId"].ToString() + "'";
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }
        #endregion

        private string GetTypeNameFromCategory(string category)
        {
            if (category.StartsWith("Accessory")) return category.Replace("Accessory", string.Empty);
            if (category.StartsWith("Dress")) return category.Replace("Dress", string.Empty);
            return category;
        }

        private void SetAllData(string tableName, string id)
        {
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(id)) return;
            ddlCategory.SelectedValue = tableName;
            SetDivByAccessoryCategory(tableName);
            string sql = "Select * From " + tableName + " Where Id='" + id + "'";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbCost.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbOptionalPrice.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbRentPrice.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbSalesPrice.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbSn.Text = dr["Sn"].ToString();
            tbColor1.Text = dr["Color"].ToString();
            tbMaterial1.Text = dr["Material"].ToString();
            ddlType.SelectedValue = dr["Category"].ToString();
            ddlSupplier.SelectedValue = dr["Supplier"].ToString();
            ddlStatus.SelectedValue = dr["StatusCode"].ToString();
            try { tbColor2.Text = dr["Color2"].ToString(); }
            catch { tbColor2.Text = string.Empty; }
            try { tbMaterial2.Text = dr["Material2"].ToString(); }
            catch { tbMaterial2.Text = string.Empty; }
            try { tbRelatedSn.Text = dr["PairSn"].ToString(); }
            catch { tbRelatedSn.Text = string.Empty; }
            try { ddlEarringType.SelectedValue = dr["Type"].ToString(); }
            catch { ddlEarringType.SelectedIndex = 0; }
            try { ddlGender.SelectedValue = dr["Gender"].ToString(); }
            catch { ddlGender.SelectedIndex = 0; }
            try { ddlLength.SelectedValue = dr["Length"].ToString(); }
            catch { ddlLength.SelectedIndex = 0; }
            try { ddlRelatedCategory.SelectedValue = dr["PairId"].ToString(); }
            catch { ddlRelatedCategory.SelectedIndex = 0; }
        }

        private bool WriteBackData(string tableName, List<DbSearchObject> lst, bool isInsert, string id)
        {
            try
            {
                return isInsert ?
                    SysProperty.GenDbCon.InsertDataInToTable(
                        tableName
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst))
                        : SysProperty.GenDbCon.UpdateDataIntoTable(
                            tableName
                            , SysProperty.Util.SqlQueryUpdateConverter(lst)
                            , " Where Id = '" + id + "'");
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        private List<DbSearchObject> AccessoryDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Color"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbColor1.Text
                ));
            lst.Add(new DbSearchObject(
                "Material"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbMaterial1.Text
                ));
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCost.Text
                ));
            lst.Add(new DbSearchObject(
                "OptionalPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOptionalPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "RentPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRentPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "SellsPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSalesPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSn.Text
                ));
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Category"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlType.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlSupplier.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Supplier"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlSupplier.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "StatusCode"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlStatus.SelectedValue
                    ));
            }
            if (divColor2.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Color2"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbColor2.Text
                    ));
            }
            if (divMaterial2.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Material2"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbMaterial2.Text
                    ));
            }
            if (divRelatedSn.Visible)
            {
                lst.Add(new DbSearchObject(
                    "PairSn"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbRelatedSn.Text
                    ));
            }
            if (divRelatedCategory.Visible)
            {
                lst.Add(new DbSearchObject(
                    "PairId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlRelatedCategory.Text
                    ));
            }
            if (divGender.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Gender"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ddlGender.SelectedValue
                    ));
            }
            if (divLace.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Lace"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbLace.Text
                    ));
            }
            if (divLength.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Length"
                    , AtrrTypeItem.Integer
                    , AttrSymbolItem.Equal
                    , ddlLength.SelectedValue
                    ));
            }
            if (divEarringType.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Type"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlEarringType.SelectedValue
                    ));
            }
            return lst;
        }

        #region Db General Control
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
        private bool ModifyDataToDb(string sql)
        {
            try
            {
                return SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        #endregion
    }
}