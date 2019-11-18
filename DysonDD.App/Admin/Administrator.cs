using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace DysonDD2019.App
{
    [Serializable()]
    public class Administrator : Csla.BusinessBase<Administrator>
    {
        #region Business Properties and Methods

        //declare members
        private Guid _id = Guid.NewGuid();
        private string _name = string.Empty;
        private string _loginId = string.Empty;
        private string _password = string.Empty;
        private string _role = string.Empty;
        private string _applicationName = string.Empty;
        private SmartDate _dateCreated = new SmartDate(false);
        private SmartDate _dateModified = new SmartDate(false);
        private SmartDate _dateLastLogin = new SmartDate(false);

        [System.ComponentModel.DataObjectField(true, true)]
        public Guid Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string Name
        {
            get
            {
                CanReadProperty("Name", true);
                return _name;
            }
            set
            {
                CanWriteProperty("Name", true);
                if (value == null) value = string.Empty;
                if (!_name.Equals(value))
                {
                    _name = value;
                    PropertyHasChanged("Name");
                }
            }
        }

        public string LoginId
        {
            get
            {
                CanReadProperty("LoginId", true);
                return _loginId;
            }
            set
            {
                CanWriteProperty("LoginId", true);
                if (value == null) value = string.Empty;
                if (!_loginId.Equals(value))
                {
                    _loginId = value;
                    PropertyHasChanged("LoginId");
                }
            }
        }

        public string Password
        {
            get
            {
                CanReadProperty("Password", true);
                return _password;
            }
            set
            {
                CanWriteProperty("Password", true);
                if (value == null) value = string.Empty;
                if (!_password.Equals(value))
                {
                    _password = value;
                    PropertyHasChanged("Password");
                }
            }
        }

        public string Role
        {
            get
            {
                CanReadProperty("Role", true);
                return _role;
            }
            set
            {
                CanWriteProperty("Role", true);
                if (value == null) value = string.Empty;
                if (!_role.Equals(value))
                {
                    _role = value;
                    PropertyHasChanged("Role");
                }
            }
        }

        public string ApplicationName
        {
            get
            {
                CanReadProperty("ApplicationName", true);
                return _applicationName;
            }
            set
            {
                CanWriteProperty("ApplicationName", true);
                if (value == null) value = string.Empty;
                if (!_applicationName.Equals(value))
                {
                    _applicationName = value;
                    PropertyHasChanged("ApplicationName");
                }
            }
        }

        public DateTime DateCreated
        {
            get
            {
                CanReadProperty("DateCreated", true);
                return _dateCreated.Date;
            }
        }

        public string DateCreatedString
        {
            get
            {
                CanReadProperty("DateCreated", true);
                return _dateCreated.Text;
            }
            set
            {
                CanWriteProperty("DateCreated", true);
                if (value == null) value = string.Empty;
                if (!_dateCreated.Equals(value))
                {
                    _dateCreated.Text = value;
                    PropertyHasChanged("DateCreated");
                }
            }
        }

        public DateTime DateModified
        {
            get
            {
                CanReadProperty("DateModified", true);
                return _dateModified.Date;
            }
        }

        public string DateModifiedString
        {
            get
            {
                CanReadProperty("DateModified", true);
                return _dateModified.Text;
            }
            set
            {
                CanWriteProperty("DateModified", true);
                if (value == null) value = string.Empty;
                if (!_dateModified.Equals(value))
                {
                    _dateModified.Text = value;
                    PropertyHasChanged("DateModified");
                }
            }
        }

        public DateTime DateLastLogin
        {
            get
            {
                CanReadProperty("DateLastLogin", true);
                return _dateLastLogin.Date;
            }
        }

        public string DateLastLoginString
        {
            get
            {
                CanReadProperty("DateLastLogin", true);
                return _dateLastLogin.Text;
            }
            set
            {
                CanWriteProperty("DateLastLogin", true);
                if (value == null) value = string.Empty;
                if (!_dateLastLogin.Equals(value))
                {
                    _dateLastLogin.Text = value;
                    PropertyHasChanged("DateLastLogin");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _id;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // Name
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Name", 250));
            //
            // LoginId
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LoginId", 50));
            //
            // Password
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Password", 50));
            //
            // Role
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Role", 50));
            //
            // ApplicationName
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ApplicationName", 250));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in Administrator
            //AuthorizationRules.AllowRead("Id", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("Name", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("LoginId", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("Password", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("Role", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("ApplicationName", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("DateCreated", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("DateModified", "AdministratorReadGroup");
            //AuthorizationRules.AllowRead("DateLastLogin", "AdministratorReadGroup");

            //AuthorizationRules.AllowWrite("Name", "AdministratorWriteGroup");
            //AuthorizationRules.AllowWrite("LoginId", "AdministratorWriteGroup");
            //AuthorizationRules.AllowWrite("Password", "AdministratorWriteGroup");
            //AuthorizationRules.AllowWrite("Role", "AdministratorWriteGroup");
            //AuthorizationRules.AllowWrite("ApplicationName", "AdministratorWriteGroup");
            //AuthorizationRules.AllowWrite("DateCreated", "AdministratorWriteGroup");
            //AuthorizationRules.AllowWrite("DateModified", "AdministratorWriteGroup");
            //AuthorizationRules.AllowWrite("DateLastLogin", "AdministratorWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in Administrator
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AdministratorViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Administrator
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AdministratorAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Administrator
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AdministratorEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Administrator
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AdministratorDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private Administrator()
        { /* require use of factory method */ }
        private Administrator(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
        }

        public static Administrator NewAdministrator()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Administrator");
            return DataPortal.Create<Administrator>();
        }

        public static Administrator GetAdministrator(Guid id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Administrator");
            return DataPortal.Fetch<Administrator>(new Criteria(id));
        }
        public static Administrator GetAdministrator(SafeDataReader dr)
        {
            return new Administrator(dr);
        }

        public static void DeleteAdministrator(Guid id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Administrator");
            DataPortal.Delete(new Criteria(id));
        }

        public override Administrator Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Administrator");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Administrator");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a Administrator");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public Guid Id;

            public Criteria(Guid id)
            {
                this.Id = id;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create(object criteria)
        {
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.DB("DysonDD")))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetAdministrator";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            _id = dr.GetGuid("Id");
            _name = dr.GetString("Name");
            _loginId = dr.GetString("LoginId");
            _password = dr.GetString("Password");
            _role = dr.GetString("Role");
            _applicationName = dr.GetString("ApplicationName");
            _dateCreated = dr.GetSmartDate("DateCreated", _dateCreated.EmptyIsMin);
            _dateModified = dr.GetSmartDate("DateModified", _dateModified.EmptyIsMin);
            _dateLastLogin = dr.GetSmartDate("DateLastLogin", _dateLastLogin.EmptyIsMin);
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.DB("DysonDD")))
            {
                cn.Open();

                ExecuteInsert(cn);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "AddAdministrator";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();
                
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_name != string.Empty)
                cm.Parameters.AddWithValue("@Name", _name);
            else
                cm.Parameters.AddWithValue("@Name", DBNull.Value);
            if (_loginId != string.Empty)
                cm.Parameters.AddWithValue("@LoginId", _loginId);
            else
                cm.Parameters.AddWithValue("@LoginId", DBNull.Value);
            if (_password != string.Empty)
                cm.Parameters.AddWithValue("@Password", _password);
            else
                cm.Parameters.AddWithValue("@Password", DBNull.Value);
            if (_role != string.Empty)
                cm.Parameters.AddWithValue("@Role", _role);
            else
                cm.Parameters.AddWithValue("@Role", DBNull.Value);
            if (_applicationName != string.Empty)
                cm.Parameters.AddWithValue("@ApplicationName", _applicationName);
            else
                cm.Parameters.AddWithValue("@ApplicationName", DBNull.Value);
            cm.Parameters.AddWithValue("@DateCreated", _dateCreated.DBValue);
            cm.Parameters.AddWithValue("@DateModified", _dateModified.DBValue);
            cm.Parameters.AddWithValue("@DateLastLogin", _dateLastLogin.DBValue);
            cm.Parameters.AddWithValue("@Id", _id);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.DB("DysonDD")))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateAdministrator";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Id", _id);
            if (_name != string.Empty)
                cm.Parameters.AddWithValue("@Name", _name);
            else
                cm.Parameters.AddWithValue("@Name", DBNull.Value);
            if (_loginId != string.Empty)
                cm.Parameters.AddWithValue("@LoginId", _loginId);
            else
                cm.Parameters.AddWithValue("@LoginId", DBNull.Value);
            if (_password != string.Empty)
                cm.Parameters.AddWithValue("@Password", _password);
            else
                cm.Parameters.AddWithValue("@Password", DBNull.Value);
            if (_role != string.Empty)
                cm.Parameters.AddWithValue("@Role", _role);
            else
                cm.Parameters.AddWithValue("@Role", DBNull.Value);
            if (_applicationName != string.Empty)
                cm.Parameters.AddWithValue("@ApplicationName", _applicationName);
            else
                cm.Parameters.AddWithValue("@ApplicationName", DBNull.Value);
            cm.Parameters.AddWithValue("@DateCreated", _dateCreated.DBValue);
            cm.Parameters.AddWithValue("@DateModified", _dateModified.DBValue);
            cm.Parameters.AddWithValue("@DateLastLogin", _dateLastLogin.DBValue);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_id));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.DB("DysonDD")))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeleteAdministrator";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
