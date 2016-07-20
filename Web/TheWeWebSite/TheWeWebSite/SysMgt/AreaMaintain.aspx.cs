﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.SysMgt
{
    public partial class AreaMaintain : System.Web.UI.Page
    {
        DataSet AreaDataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.AreaString;
                    InitialLangList();
                    InitialCountryList();
                    BindData();
                }
            }   
        }

        private void GetAreaList(string sortString)
        {
            try
            {
                string sqlTxt = "SELECT a.[Id],a.[Name],a.[EngName],a.JpName,a.CnName"
                    + ",a.IsDelete,a.UpdateAccId as EmployeeId,a.UpdateTime,a.CountryId"
                    + ",c." + new ResourceUtil().OutputLangNameToAttrName(SysProperty.CultureCode)
                    + " as CountryName,e.Name as EmployeeName"
                    + " FROM[TheWe].[dbo].[Area] as a"
                    + " left join Country as c on c.Id = a.CountryId"
                    + " left join Employee as e on e.Id = a.UpdateAccId"
                    + " where a.IsDelete = 0 " + sortString;
                AreaDataSet = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                AreaDataSet = null;
            }
        }

        private void InitialLangList()
        {
            ddlLang.Items.Clear();
            ddlLang.Items.Add(new ListItem(Resources.Resource.TraditionalChineseString, "zh-TW"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.SimplifiedChineseString, "zh-CN"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.EnglishString, "en"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.JapaneseString, "ja-JP"));
            ddlLang.SelectedIndex = new ResourceUtil().OutputLangNameNumber(SysProperty.CultureCode);
        }
        private void InitialCountryList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty));
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Country where IsDelete = 0");
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ddlCountry.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(dr)
                            , dr["Id"].ToString()));
                    }
                }
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)
                || string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                return;
            }
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbName.Text)
                );
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                );
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , SysProperty.AccountInfo["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCountry.SelectedValue)
                );

            if (SysProperty.GenDbCon.InsertDataInToTable(
                SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                ))
            {
                BindData();
                tbName.Text = string.Empty;
                ddlCountry.SelectedIndex = 0;
            }
        }

        private void BindData()
        {
            GetAreaList(string.Empty);
            dgArea.DataSource = AreaDataSet;
            dgArea.AllowPaging = !SysProperty.Util.IsDataSetEmpty(AreaDataSet);
            dgArea.DataBind();
        }

        protected void dgArea_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgArea.EditItemIndex = -1;
            BindData();
        }

        protected void dgArea_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgArea.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void dgArea_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dgArea.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE [dbo].[Area] SET IsDelete = 1"
                + ", UpdateAccId=N'" + SysProperty.AccountInfo["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
            {
                BindData();
            }
        }

        protected void dgArea_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgArea.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dgArea_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                DropDownList ddl1 = (DropDownList)dgArea.Items[dgArea.EditItemIndex].FindControl("ddlDgCountry");
                List<DbSearchObject> updateLst = new List<DbSearchObject>();
                updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[3].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[4].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl1.SelectedValue));
                updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, SysProperty.AccountInfo["Id"].ToString()));
                updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgArea.DataKeys[dgArea.EditItemIndex].ToString() + "'"))
                {
                    dgArea.EditItemIndex = -1;
                    BindData();
                }
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgArea_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlDgCountry");
                    dropDownList1.Items.Clear();
                    try
                    {
                        DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                            , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country)
                            , " Where IsDelete = 0");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dropDownList1.Items.Add(new ListItem(
                                SysProperty.Util.OutputRelatedLangName(dr)
                                , dr["Id"].ToString()));
                        }
                        dropDownList1.SelectedValue = dataItem1["CountryId"].ToString();
                    }catch(Exception ex)
                    {
                        SysProperty.Log.Error(ex.Message);
                    }
                }
                else
                {
                    Label label = (Label)e.Item.FindControl("labelDgCountry");
                    label.Text = dataItem1["CountryName"].ToString();
                }
            }
        }

        protected void dgArea_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if(AreaDataSet==null)
            {
                GetAreaList("Order by "+ e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if(AreaDataSet != null)
            {                
                dgArea.DataSource = AreaDataSet;
                dgArea.DataBind();
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }
    }
}