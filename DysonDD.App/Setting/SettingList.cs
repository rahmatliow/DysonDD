using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace DysonDD2019.App
{
    [Serializable()]
    public class SettingList : Csla.ReadOnlyListBase<SettingList, Setting>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SettingList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SettingListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SettingList()
        { /* require use of factory method */ }

        public static SettingList GetSettingList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SettingList");
            return DataPortal.Fetch<SettingList>(new FilterCriteria());
        }
        public static SettingList GetSettingList(string code)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SettingList");
            return DataPortal.Fetch<SettingList>(new FilterCriteria(code));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public string _code = string.Empty;
            public FilterCriteria()
            {

            }
            public FilterCriteria(string code)
            {
                this._code = code;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            using (SqlConnection cn = new SqlConnection(Database.DB("DysonDD")))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetSettingList";
                cm.Parameters.AddWithValue("@Code", criteria._code);


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(Setting.GetSetting(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
