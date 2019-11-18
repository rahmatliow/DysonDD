using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace DysonDD2019.App
{
    [Serializable()]
    public class Setting : Csla.BusinessBase<Setting>
    {
        #region Business Properties and Methods

        //declare members
        private Guid _id = Guid.NewGuid();
        private string _code = string.Empty;
        private string _description = string.Empty;
        private string _runningNo = string.Empty;
        private SmartDate _dateCreated = new SmartDate(false);
        private SmartDate _dateModified = new SmartDate(false);

        [System.ComponentModel.DataObjectField(true, true)]
        public Guid Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string Code
        {
            get
            {
                CanReadProperty("Code", true);
                return _code;
            }
            set
            {
                CanWriteProperty("Code", true);
                if (value == null) value = string.Empty;
                if (!_code.Equals(value))
                {
                    _code = value;
                    PropertyHasChanged("Code");
                }
            }
        }

        public string Description
        {
            get
            {
                CanReadProperty("Description", true);
                return _description;
            }
            set
            {
                CanWriteProperty("Description", true);
                if (value == null) value = string.Empty;
                if (!_description.Equals(value))
                {
                    _description = value;
                    PropertyHasChanged("Description");
                }
            }
        }

        public string RunningNo
        {
            get
            {
                CanReadProperty("RunningNo", true);
                return _runningNo;
            }
            set
            {
                CanWriteProperty("RunningNo", true);
                if (value == null) value = string.Empty;
                if (!_runningNo.Equals(value))
                {
                    _runningNo = value;
                    PropertyHasChanged("RunningNo");
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
            // Code
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Code", 150));
            //
            // Description
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Description", 300));
            //
            // RunningNo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("RunningNo", 50));
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
            //TODO: Define authorization rules in Setting
            //AuthorizationRules.AllowRead("Id", "SettingReadGroup");
            //AuthorizationRules.AllowRead("Code", "SettingReadGroup");
            //AuthorizationRules.AllowRead("Description", "SettingReadGroup");
            //AuthorizationRules.AllowRead("RunningNo", "SettingReadGroup");
            //AuthorizationRules.AllowRead("DateCreated", "SettingReadGroup");
            //AuthorizationRules.AllowRead("DateModified", "SettingReadGroup");

            //AuthorizationRules.AllowWrite("Code", "SettingWriteGroup");
            //AuthorizationRules.AllowWrite("Description", "SettingWriteGroup");
            //AuthorizationRules.AllowWrite("RunningNo", "SettingWriteGroup");
            //AuthorizationRules.AllowWrite("DateCreated", "SettingWriteGroup");
            //AuthorizationRules.AllowWrite("DateModified", "SettingWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in Setting
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SettingViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Setting
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SettingAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Setting
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SettingEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Setting
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SettingDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private Setting()
        { /* require use of factory method */ }
        private Setting(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
        }

        public static Setting NewSetting()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Setting");
            return DataPortal.Create<Setting>();
        }

        public static Setting GetSetting(Guid id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Setting");
            return DataPortal.Fetch<Setting>(new Criteria(id));
        }
        public static Setting GetSetting(SafeDataReader dr)
        {
            return new Setting(dr);
        }

        public static void DeleteSetting(Guid id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Setting");
            DataPortal.Delete(new Criteria(id));
        }

        public override Setting Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Setting");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Setting");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a Setting");

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
                cm.CommandText = "GetSetting";

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
            _code = dr.GetString("Code");
            _description = dr.GetString("Description");
            _runningNo = dr.GetString("RunningNo");
            _dateCreated = dr.GetSmartDate("DateCreated", _dateCreated.EmptyIsMin);
            _dateModified = dr.GetSmartDate("DateModified", _dateModified.EmptyIsMin);
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
                cm.CommandText = "AddSetting";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();
                
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_code != string.Empty)
                cm.Parameters.AddWithValue("@Code", _code);
            else
                cm.Parameters.AddWithValue("@Code", DBNull.Value);
            if (_description != string.Empty)
                cm.Parameters.AddWithValue("@Description", _description);
            else
                cm.Parameters.AddWithValue("@Description", DBNull.Value);
            if (_runningNo != string.Empty)
                cm.Parameters.AddWithValue("@RunningNo", _runningNo);
            else
                cm.Parameters.AddWithValue("@RunningNo", DBNull.Value);
            cm.Parameters.AddWithValue("@DateCreated", _dateCreated.DBValue);
            cm.Parameters.AddWithValue("@DateModified", _dateModified.DBValue);
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
                cm.CommandText = "UpdateSetting";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Id", _id);
            if (_code != string.Empty)
                cm.Parameters.AddWithValue("@Code", _code);
            else
                cm.Parameters.AddWithValue("@Code", DBNull.Value);
            if (_description != string.Empty)
                cm.Parameters.AddWithValue("@Description", _description);
            else
                cm.Parameters.AddWithValue("@Description", DBNull.Value);
            if (_runningNo != string.Empty)
                cm.Parameters.AddWithValue("@RunningNo", _runningNo);
            else
                cm.Parameters.AddWithValue("@RunningNo", DBNull.Value);
            cm.Parameters.AddWithValue("@DateCreated", _dateCreated.DBValue);
            cm.Parameters.AddWithValue("@DateModified", _dateModified.DBValue);
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
                cm.CommandText = "DeleteSetting";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
