using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace DysonDD2019.App
{
    [Serializable()]
    public class Registration : Csla.BusinessBase<Registration>
    {
        #region Business Properties and Methods

        //declare members
        private Guid _id = Guid.NewGuid();
        private string _name = string.Empty;
        private SmartDate _dateCreated = new SmartDate(false);
        private SmartDate _dateModified = new SmartDate(false);
        private bool _isAttend = false;
        private SmartDate _attendConfirmDate = new SmartDate(false);
        private string _serialNo = string.Empty;
        private int _drinksBalance = 4;

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

        public bool IsAttend
        {
            get
            {
                CanReadProperty("IsAttend", true);
                return _isAttend;
            }
            set
            {
                CanWriteProperty("IsAttend", true);
                if (!_isAttend.Equals(value))
                {
                    _isAttend = value;
                    PropertyHasChanged("IsAttend");
                }
            }
        }

        public DateTime AttendConfirmDate
        {
            get
            {
                CanReadProperty("AttendConfirmDate", true);
                return _attendConfirmDate.Date;
            }
        }

        public string AttendConfirmDateString
        {
            get
            {
                CanReadProperty("AttendConfirmDate", true);
                return _attendConfirmDate.Text;
            }
            set
            {
                CanWriteProperty("AttendConfirmDate", true);
                if (value == null) value = string.Empty;
                if (!_attendConfirmDate.Equals(value))
                {
                    _attendConfirmDate.Text = value;
                    PropertyHasChanged("AttendConfirmDate");
                }
            }
        }

        public string SerialNo
        {
            get
            {
                CanReadProperty("SerialNo", true);
                return _serialNo;
            }
            set
            {
                CanWriteProperty("SerialNo", true);
                if (value == null) value = string.Empty;
                if (!_serialNo.Equals(value))
                {
                    _serialNo = value;
                    PropertyHasChanged("SerialNo");
                }
            }
        }

        public int DrinksBalance
        {
            get
            {
                CanReadProperty("DrinksBalance", true);
                return _drinksBalance;
            }
            set
            {
                CanWriteProperty("DrinksBalance", true);
                if (!_drinksBalance.Equals(value))
                {
                    _drinksBalance = value;
                    PropertyHasChanged("DrinksBalance");
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
            // SerialNo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SerialNo", 50));
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
            //TODO: Define authorization rules in Registration
            //AuthorizationRules.AllowRead("Id", "RegistrationReadGroup");
            //AuthorizationRules.AllowRead("Name", "RegistrationReadGroup");
            //AuthorizationRules.AllowRead("DateCreated", "RegistrationReadGroup");
            //AuthorizationRules.AllowRead("DateModified", "RegistrationReadGroup");
            //AuthorizationRules.AllowRead("IsAttend", "RegistrationReadGroup");
            //AuthorizationRules.AllowRead("AttendConfirmDate", "RegistrationReadGroup");
            //AuthorizationRules.AllowRead("SerialNo", "RegistrationReadGroup");
            //AuthorizationRules.AllowRead("DrinksBalance", "RegistrationReadGroup");

            //AuthorizationRules.AllowWrite("Name", "RegistrationWriteGroup");
            //AuthorizationRules.AllowWrite("DateCreated", "RegistrationWriteGroup");
            //AuthorizationRules.AllowWrite("DateModified", "RegistrationWriteGroup");
            //AuthorizationRules.AllowWrite("IsAttend", "RegistrationWriteGroup");
            //AuthorizationRules.AllowWrite("AttendConfirmDate", "RegistrationWriteGroup");
            //AuthorizationRules.AllowWrite("SerialNo", "RegistrationWriteGroup");
            //AuthorizationRules.AllowWrite("DrinksBalance", "RegistrationWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in Registration
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("RegistrationViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Registration
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("RegistrationAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Registration
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("RegistrationEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Registration
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("RegistrationDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private Registration()
        { /* require use of factory method */ }

        private Registration(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
        }

        public static Registration NewRegistration()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Registration");
            return DataPortal.Create<Registration>();
        }

        public static Registration GetRegistration(Guid id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Registration");
            return DataPortal.Fetch<Registration>(new Criteria(id));
        }
        public static Registration GetRegistration(SafeDataReader dr)
        {
            return new Registration(dr);
        }

        public static void DeleteRegistration(Guid id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Registration");
            DataPortal.Delete(new Criteria(id));
        }

        public override Registration Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Registration");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Registration");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a Registration");

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
                cm.CommandText = "GetRegistration";

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
            _dateCreated = dr.GetSmartDate("DateCreated", _dateCreated.EmptyIsMin);
            _dateModified = dr.GetSmartDate("DateModified", _dateModified.EmptyIsMin);
            _isAttend = dr.GetBoolean("IsAttend");
            _attendConfirmDate = dr.GetSmartDate("AttendConfirmDate", _attendConfirmDate.EmptyIsMin);
            _serialNo = dr.GetString("SerialNo");
            _drinksBalance = dr.GetInt32("DrinksBalance");
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
                cm.CommandText = "AddRegistration";

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
            cm.Parameters.AddWithValue("@DateCreated", _dateCreated.DBValue);
            cm.Parameters.AddWithValue("@DateModified", _dateModified.DBValue);
            cm.Parameters.AddWithValue("@IsAttend", _isAttend);
            cm.Parameters.AddWithValue("@AttendConfirmDate", _attendConfirmDate.DBValue);
            if (_serialNo != string.Empty)
                cm.Parameters.AddWithValue("@SerialNo", _serialNo);
            else
                cm.Parameters.AddWithValue("@SerialNo", DBNull.Value);
            cm.Parameters.AddWithValue("@DrinksBalance", _drinksBalance);
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
                cm.CommandText = "UpdateRegistration";

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
            cm.Parameters.AddWithValue("@DateCreated", _dateCreated.DBValue);
            cm.Parameters.AddWithValue("@DateModified", _dateModified.DBValue);
            cm.Parameters.AddWithValue("@IsAttend", _isAttend);
            cm.Parameters.AddWithValue("@AttendConfirmDate", _attendConfirmDate.DBValue);
            if (_serialNo != string.Empty)
                cm.Parameters.AddWithValue("@SerialNo", _serialNo);
            else
                cm.Parameters.AddWithValue("@SerialNo", DBNull.Value);
            cm.Parameters.AddWithValue("@DrinksBalance", _drinksBalance);
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
                cm.CommandText = "DeleteRegistration";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
