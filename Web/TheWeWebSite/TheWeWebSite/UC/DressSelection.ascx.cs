using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.UC
{
    public partial class DressSelection : System.Web.UI.UserControl
    {
        public event EventHandler UserControlButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitialControls();
        }

        public void InitialControls()
        {
            DressTypeList();
            DressList();
        }

        public void DressTypeList()
        {
            ddlType.Items.Clear();
            string storeId = ((DataRow)Session["LocateStore"])["Id"].ToString();
            string sql = "Select * From DressCategory Where IsDelete = 0 And Type = 'Dress' Order by Sn";
            DataSet ds = GetDataSetFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ddlType.Items.Add(new ListItem(SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr), dr["Id"].ToString()));
            }
            ddlType.SelectedIndex = 0;
        }
        public void DressList()
        {
            cbDress.Items.Clear();
            if (string.IsNullOrEmpty(ddlType.SelectedValue)) return;
            string storeId = ((DataRow)Session["LocateStore"])["Id"].ToString();
            string sql = "Select * From Dress Where IsDelete = 0 And StoreId = '" + storeId + "' And Category = '" + ddlType.SelectedValue + "' Order by Sn";
            DataSet ds = GetDataSetFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                cbDress.Items.Add(new ListItem(dr["Sn"].ToString(), dr["Img"].ToString()));
            }
            cbDress.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(cbDress.SelectedValue))
            {
                tbFolderPath.Text = GetImageFolderPath(cbDress.SelectedItem.Text, cbDress.SelectedValue);
                RefreshImage(0, tbFolderPath.Text);
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                DressList();
            }
        }

        protected void cbDress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbDress.SelectedValue))
            {
                tbFolderPath.Text = GetImageFolderPath(cbDress.SelectedItem.Text, cbDress.SelectedValue);                
                RefreshImage(0, tbFolderPath.Text);
            }
        }

        private string GetImageFolderPath(string sn, string path)
        {
            string imgPath = path;
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"\Dress\" + sn;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            return imgPath;
        }


        #region Image Related
        private void RefreshImage(int type, string path)
        {
            switch (type)
            {
                case 1:
                    ImgFront.ImageUrl = "http:" + path + "\\" + cbDress.SelectedItem.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 2:
                    ImgBack.ImageUrl = "http:" + path + "\\" + cbDress.SelectedItem.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgSide.ImageUrl = "http:" + path + "\\" + cbDress.SelectedItem.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + "\\" + cbDress.SelectedItem.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + "\\" + cbDress.SelectedItem.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + "\\" + cbDress.SelectedItem.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
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
        #endregion

        private DataSet GetDataSetFromDb(string sql)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return null;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UserControlButtonClicked(sender, e);
        }
    }
}