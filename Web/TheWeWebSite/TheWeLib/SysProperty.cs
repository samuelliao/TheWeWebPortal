using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TheWeLib.DbControl;

namespace TheWeLib
{
    public static class SysProperty
    {
        public static string DbConcString;
        public static Logger Log;
        public static GeneralDbDAO GenDbCon = new GeneralDbDAO();
        public static Utility Util;        
        public static bool DataSetSortType;
        public static int HashTableUpdatePeriod = 60000;
        public static string ImgRootFolderpath;
        private static Hashtable CountryHashList;
        private static Hashtable AreaHashList;
        private static Hashtable ChurchHashList;
        private static Hashtable StoreHashList;
        private static DateTime AreaHashUpdateTime;
        private static DateTime StoreHashUpdateTime;
        private static DateTime CountryHashUpdateTime;
        private static DateTime ChurchHashUpdateTime;
        private static object AreaLocker = new object();
        private static object CountryLocker = new object();
        private static object ChurchLocker = new object();
        private static object StoreLocker = new object();

        #region System Hash map
        #region Area Hash map
        public static void UpdateAreas()
        {
            if(!string.IsNullOrEmpty(DbConcString)&& GenDbCon != null)
            {
                lock (AreaLocker)
                {
                    AreaHashList = new Hashtable();
                    AreaHashUpdateTime = DateTime.Now;
                    DataSet ds = GenDbCon.GetDataFromTable("Select * From Area Where IsDelete = 0");
                    if (Util.IsDataSetEmpty(ds)) return;
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        AreaHashList.Add(dr["Id"].ToString(), dr);
                    }
                }
            }
        }
        public static DataRow GetAreaById(string id)
        {
            lock (AreaLocker)
            {
                if (CheckKeyInAreas(id))
                    return (DataRow)AreaHashList[id];
                else
                    return null;
            }
        }
        public static bool CheckKeyInAreas(string id)
        {
            lock (AreaLocker)
            {
                bool result = AreaHashList.ContainsKey(id);
                if (!result && HashTableNeedUpdate(AreaHashUpdateTime))
                {
                    UpdateAreas();
                    result = AreaHashList.ContainsKey(id);
                }
                return result;
            }
        }
        #endregion

        #region Country Hash map
        public static void UpdateCountries()
        {
            if (!string.IsNullOrEmpty(DbConcString) && GenDbCon != null)
            {
                lock (CountryLocker)
                {
                    CountryHashList = new Hashtable();
                    CountryHashUpdateTime = DateTime.Now;
                    DataSet ds = GenDbCon.GetDataFromTable("Select * From Country Where IsDelete = 0");
                    if (Util.IsDataSetEmpty(ds)) return;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CountryHashList.Add(dr["Id"].ToString(), dr);
                    }
                }
            }
        }        
        public static bool CheckKeyInCountry(string id)
        {
            lock (CountryLocker)
            {
                bool result = CountryHashList.ContainsKey(id);
                if (!result && HashTableNeedUpdate(CountryHashUpdateTime))
                {
                    UpdateCountries();
                    result = CountryHashList.ContainsKey(id);
                }
                return result;
            }
        }        
        public static DataRow GetCountryById(string id)
        {
            lock (CountryLocker)
            {
                if (CheckKeyInCountry(id))
                    return (DataRow)CountryHashList[id];
                else
                    return null;
            }
        }
        #endregion

        #region Church Hash map
        public static void UpdateChurch()
        {
            if (!string.IsNullOrEmpty(DbConcString) && GenDbCon != null)
            {
                lock (ChurchLocker)
                {
                    ChurchHashList = new Hashtable();
                    ChurchHashUpdateTime = DateTime.Now;
                    DataSet ds = GenDbCon.GetDataFromTable("Select * From Church Where IsDelete = 0");
                    if (Util.IsDataSetEmpty(ds)) return;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ChurchHashList.Add(dr["Id"].ToString(), dr);
                    }
                }
            }
        }
        public static bool CheckKeyInChurch(string id)
        {
            lock (ChurchLocker)
            {
                bool result = ChurchHashList.ContainsKey(id);
                if (!result && HashTableNeedUpdate(ChurchHashUpdateTime))
                {
                    UpdateChurch();
                    result = ChurchHashList.ContainsKey(id);
                }
                return result;
            }
        }
        public static DataRow GetChurchById(string id)
        {
            lock (ChurchLocker)
            {
                if (CheckKeyInChurch(id))
                    return (DataRow)ChurchHashList[id];
                else
                    return null;
            }
        }
        #endregion

        #region Church Hash map
        public static void UpdateStore()
        {
            if (!string.IsNullOrEmpty(DbConcString) && GenDbCon != null)
            {
                lock (StoreLocker)
                {
                    StoreHashList = new Hashtable();
                    StoreHashUpdateTime = DateTime.Now;
                    DataSet ds = GenDbCon.GetDataFromTable("Select * From Store Where IsDelete = 0");
                    if (Util.IsDataSetEmpty(ds)) return;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        StoreHashList.Add(dr["Id"].ToString(), dr);
                    }
                }
            }
        }
        public static bool CheckKeyInStore(string id)
        {
            lock (StoreLocker)
            {
                bool result = StoreHashList.ContainsKey(id);
                if (!result && HashTableNeedUpdate(StoreHashUpdateTime))
                {
                    UpdateStore();
                    result = StoreHashList.ContainsKey(id);
                }
                return result;
            }
        }
        public static DataRow GetStoreById(string id)
        {
            lock (StoreLocker)
            {
                if (CheckKeyInStore(id))
                    return (DataRow)StoreHashList[id];
                else
                    return null;
            }
        }
        #endregion

        private static bool HashTableNeedUpdate(DateTime time)
        {
            TimeSpan ts = DateTime.Now - time;
            return ts.Ticks >= HashTableUpdatePeriod;
        }
        #endregion
    }
}
