using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.CaseMgt
{
    public partial class TimeMCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;

                    InitialConferenceItem();
                    InitialControlWithPermission();

                    if (Session["OrderId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.TimetableMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        InitialConferenceItem();
                        SetOrderInfo(Session["OrderId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.TimetableMaintainString
                        + " > " + Resources.Resource.CreateString;
                        btnModify.Visible = false;
                    }
                }
            }
        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnModify.Visible = item.CanModify;
            btnModify.Enabled = item.CanModify;
        }
        private void InitialConferenceItem()
        {
            try
            {
                tvConf.Nodes.Clear();
                DataSet ds = GetConferenceItem(" And ConferenceLv != 0");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                TreeNode conNode = new TreeNode();
                TreeNode itemNode = new TreeNode();
                foreach (int cnt in ds.Tables[0].AsEnumerable().Select(x => x["ConferenceLv"]).Distinct().ToList())
                {
                    conNode = new TreeNode(cnt.ToString(), string.Empty);
                    foreach (DataRow dr in ds.Tables[0].Select("ConferenceLv = " + cnt))
                    {
                        conNode.ChildNodes.Add(new TreeNode(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                            , dr["Id"].ToString()));
                    }
                    tvConf.Nodes.Add(conNode);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage()
        {
            Session.Remove("OrderId");
            Server.Transfer("TimeMaintain.aspx", true);
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            string itemId = tvConf.SelectedValue;
            string orderId = Session["OrderId"].ToString();
            if (string.IsNullOrEmpty(itemId)) return;
            bool result = WriteBackData(MsSqlTable.ConferenceInfo, ConferenceItemDbObject(itemId, orderId), orderId, itemId);
            if (!result) return;
            result = WriteBackData(MsSqlTable.OrderInfo, OrderInfoDbObject(itemId), orderId, itemId);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }

        private DataSet GetOrderInfo(string id)
        {
            try
            {
                string sql = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                + ",o.[CustomerId],cus.Name AS CustomerName,o.[ConferenceCategory], ci.Name As StatusName, ci.JpName AS StatusJpName"
                + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName"
                + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                + " FROM[TheWe].[dbo].[OrderInfo] as o"
                + " Left join Consultation as c on c.Id = o.ConsultId"
                + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                + " Left join ProductSet as p on p.Id = o.SetId"
                + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                + " WHERE o.IsDelete = 0 and o.Id='" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetConferenceList(string condStr)
        {
            try
            {
                string sql = "SELECT info.[Id],[ItemId],[OrderId],[BookingDate],[IsCheck]"
                    + ",[CheckTime],[EmployeeId],info.Remark,info.[IsDelete],info.[UpdateAccId]"
                    + ",info.[UpdateTime],item.ConferenceLv"
                    + " FROM[TheWe].[dbo].[ConferenceInfo] as info"
                    + " Left join ConferenceItem as item on item.Id = info.ItemId"
                    + " Where info.IsDelete=0 " + condStr;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetConferenceItem(string condStr)
        {
            try
            {
                string sql = "Select * From ConferenceItem Where IsDelete = 0 " + condStr + " order by Sn";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private void SetOrderInfo(string id)
        {
            string cultureCode = Session["CultureCode"].ToString();
            DataSet ds = GetOrderInfo(id);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbBridalName.Text = dr["CustomerName"].ToString();
            tbGroomName.Text = dr["PartnerName"].ToString();
            tbProductSet.Text = SysProperty.Util.OutputRelatedLangName(
                cultureCode
                , dr["SetName"].ToString()
                , dr["SetCnName"].ToString()
                , dr["SetEngName"].ToString()
                , dr["SetJpName"].ToString());
            tbLocation.Text = SysProperty.Util.OutputRelatedLangName(cultureCode, SysProperty.GetChurchById(dr["ChurchId"].ToString()));
            tbArea.Text = SysProperty.Util.OutputRelatedLangName(cultureCode, SysProperty.GetAreaById(dr["AreaId"].ToString()));
            tbCountry.Text = SysProperty.Util.OutputRelatedLangName(cultureCode, SysProperty.GetCountryById(dr["CountryId"].ToString()));
            tbContractDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["StartTime"].ToString());
            labelSn.Text = dr["Sn"].ToString();

            SetConferenceItem(id);
        }

        private void SetConferenceItem(string id)
        {
            DataSet ds = GetConferenceList(" And OrderId = '" + id + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;            
            int index = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {                
                if (bool.Parse(dr["IsCheck"].ToString()))
                {
                    index = int.Parse(dr["ConferenceLv"].ToString()) - 1;
                    for(int i = 0; i < tvConf.Nodes[index].ChildNodes.Count; i++)
                    {
                        if(tvConf.Nodes[index].ChildNodes[i].Value == dr["ItemId"].ToString())
                        {
                            tvConf.Nodes[index].ChildNodes[i].Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        protected void tvConf_SelectedNodeChanged(object sender, EventArgs e)
        {
            string id = tvConf.SelectedValue;
            if (string.IsNullOrEmpty(id))
            {
                tbConDate.Enabled = false;
                cbCompleted.Enabled = false;
                tbRemark.Enabled = false;
                btnModify.Enabled = false;
            }
            else
            {
                tbConDate.Enabled = true;
                cbCompleted.Enabled = true;
                tbRemark.Enabled = true;
                btnModify.Enabled = true;
                DataSet ds = GetConferenceList(" And ItemId = '" + id + "'");
                if (SysProperty.Util.IsDataSetEmpty(ds))
                {
                    tbRemark.Text = string.Empty;
                    tbConDate.Text = string.Empty;
                    cbCompleted.Checked = false;
                }
                else
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    tbRemark.Text = dr["Remark"].ToString();
                    tbConDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["BookingDate"].ToString());
                    cbCompleted.Checked = bool.Parse(dr["IsCheck"].ToString());
                }
            }
        }
        private List<DbSearchObject> OrderInfoDbObject(string itemId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "ConferenceCategory"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , itemId
                ));
            lst.Add(new DbSearchObject(
                "BookingDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , SysProperty.Util.ParseDateTime("DateTime", tbConDate.Text)
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "EmployeeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }
        private List<DbSearchObject> ConferenceItemDbObject(string itemId, string orderId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "OrderId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , orderId
                ));
            lst.Add(new DbSearchObject(
                "ItemId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , itemId
                ));
            lst.Add(new DbSearchObject(
                "BookingDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbConDate.Text
                ));
            lst.Add(new DbSearchObject(
                "IsCheck"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , (cbCompleted.Checked ? "1" : "0")
                ));
            lst.Add(new DbSearchObject(
                "Remark"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRemark.Text
                ));
            if (cbCompleted.Checked)
            {
                lst.Add(new DbSearchObject(
                "CheckTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            }
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "EmployeeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }

        private bool WriteBackData(MsSqlTable table, List<DbSearchObject> lst, string orderId, string itemId)
        {
            try
            {
                if (table == MsSqlTable.OrderInfo)
                {
                    return SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryUpdateConverter(lst)
                        , " Where Id='" + orderId + "'");
                }
                else
                {
                    SysProperty.GenDbCon.ModifyDataInToTable(
                        "Delete From ConferenceInfo"
                        + " Where OrderId = '" + orderId + "'"
                        + " And ItemId = '" + itemId + "'");
                    return SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
    }
}