using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using PUVWeb_TEST.Module.DLCSecuritySystem;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;

namespace XAFSkelbimaiPrograma.Module.SecurityModule
{
    [DefaultClassOptions]
    public class DLCEmployee : Person, ISecurityUser, IAuthenticationStandardUser,
        IAuthenticationActiveDirectoryUser, ISecurityUserWithRoles, IOperationPermissionProvider    
    {
        public DLCEmployee(Session session)
            : base(session) { }

        [Association("Employee-Task")]
        public XPCollection<DLCEmployeeTask> OwnTasks
        {
            get { return GetCollection<DLCEmployeeTask>("OwnTasks"); }
        }

        [Association("Employee-License")]
        public XPCollection<SKUserLicense> Licenses
        {
            get { return GetCollection<SKUserLicense>("Licenses"); }
        }

        #region ISecurityUser Members
        private bool isActive = true;
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }
        private string userName = String.Empty;
        [RuleRequiredField("EmployeeUserNameRequired", DefaultContexts.Save)]
        [RuleUniqueValue("EmployeeUserNameIsUnique", DefaultContexts.Save,
            "The login with the entered user name was already registered within the system.")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }
        #endregion

        #region IAuthenticationStandardUser Members
        private bool changePasswordOnFirstLogon;
        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set
            {
                SetPropertyValue("ChangePasswordOnFirstLogon", ref changePasswordOnFirstLogon, value);
            }
        }
        private string storedPassword;
        [Browsable(false), Size(SizeAttribute.Unlimited), Persistent, SecurityBrowsable]
        protected string StoredPassword
        {
            get { return storedPassword; }
            set { storedPassword = value; }
        }
        public bool ComparePassword(string password)
        {
            return SecurityUserBase.ComparePassword(this.storedPassword, password);
        }
        public void SetPassword(string password)
        {
            this.storedPassword = new PasswordCryptographer().GenerateSaltedPassword(password);
            OnChanged("StoredPassword");
        }
        #endregion

        #region ISecurityUserWithRoles Members
        IList<ISecurityRole> ISecurityUserWithRoles.Roles
        {
            get
            {
                IList<ISecurityRole> result = new List<ISecurityRole>();
                foreach (DLCEmployeeRole role in EmployeeRoles)
                {
                    result.Add(role);
                }
                return result;
            }
        }
        #endregion
        [Association("Employees-EmployeeRoles")]
        [RuleRequiredField("EmployeeRoleIsRequired", DefaultContexts.Save,
            TargetCriteria = "IsActive",
            CustomMessageTemplate = "An active employee must have at least one role assigned")]
        public XPCollection<DLCEmployeeRole> EmployeeRoles
        {
            get
            {
                return GetCollection<DLCEmployeeRole>("EmployeeRoles");
            }
        }

        #region IOperationPermissionProvider Members
        IEnumerable<IOperationPermission> IOperationPermissionProvider.GetPermissions()
        {
            return new IOperationPermission[0];
        }
        IEnumerable<IOperationPermissionProvider> IOperationPermissionProvider.GetChildren()
        {
            return new EnumerableConverter<IOperationPermissionProvider, DLCEmployeeRole>(EmployeeRoles);
        }
        #endregion
    }
}
