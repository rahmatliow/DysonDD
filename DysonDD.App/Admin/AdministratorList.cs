using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace DysonDD2019.App
{
    [Serializable()]
    public class AdministratorList : Csla.ReadOnlyListBase<AdministratorList, Administrator>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in AdministratorList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AdministratorListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private AdministratorList()
        { /* require use of factory method */ }

        public static AdministratorList GetAdministratorList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a AdministratorList");
            return DataPortal.Fetch<AdministratorList>(new FilterCriteria());
        }
        public static AdministratorList GetAdministratorList(string loginId, string password)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a AdministratorList");
            return DataPortal.Fetch<AdministratorList>(new FilterCriteria(loginId, password));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public string _loginId = string.Empty;
            public string _password = string.Empty;
            public FilterCriteria()
            {

            }
            public FilterCriteria(string loginId, string password)
            {
                this._loginId = loginId;
                this._password = password;
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
                cm.CommandText = "GetAdministratorList";
                cm.Parameters.AddWithValue("@LoginId", criteria._loginId);
                cm.Parameters.AddWithValue("@Password", criteria._password);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(Administrator.GetAdministrator(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
