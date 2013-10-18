using System;
using System.Linq;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using PUVWeb_TEST.Module.DLCSecuritySystem;
using XAFSkelbimaiPrograma.Module.BusinessObjects.ORMDataModelCode.Objects;
//using DevExpress.ExpressApp.Reports;
//using DevExpress.ExpressApp.PivotChart;
//using DevExpress.ExpressApp.Security.Strategy;
//using XAFSkelbimaiPrograma.Module.BusinessObjects;
using XAFSkelbimaiPrograma.Module.SecurityModule;

namespace XAFSkelbimaiPrograma.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppUpdatingModuleUpdatertopic
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            CreateDefaultUsers();

            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}
        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }

        private void CreateDefaultUsers()
        {
            DLCEmployeeRole adminRole = ObjectSpace.FindObject<DLCEmployeeRole>(
      new BinaryOperator("Name", SecurityStrategy.AdministratorRoleName));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<DLCEmployeeRole>();
                adminRole.Name = SecurityStrategy.AdministratorRoleName;
                adminRole.IsAdministrative = true;
            }

            //    DLCEmployeeRole userRole = ObjectSpace.FindObject<DLCEmployeeRole>(
            //new BinaryOperator("Name", "User"));
            //    if (userRole == null)
            //    {
            //        userRole = ObjectSpace.CreateObject<DLCEmployeeRole>();
            //        userRole.Name = "User";
            //        SecuritySystemTypePermissionObject userTypePermission =
            //            ObjectSpace.CreateObject<SecuritySystemTypePermissionObject>();
            //        userTypePermission.TargetType = typeof(SecuritySystemUser);
            //        SecuritySystemObjectPermissionsObject currentUserObjectPermission =
            //            ObjectSpace.CreateObject<SecuritySystemObjectPermissionsObject>();
            //        currentUserObjectPermission.Criteria = "[Oid] = CurrentUserId()";
            //        currentUserObjectPermission.AllowNavigate = true;
            //        currentUserObjectPermission.AllowRead = true;
            //        userTypePermission.ObjectPermissions.Add(currentUserObjectPermission);
            //        userRole.TypePermissions.Add(userTypePermission);
            //    }


            DLCEmployee user1 = ObjectSpace.FindObject<DLCEmployee>(
                    new BinaryOperator("UserName", "Admin"));
            if (user1 == null)
            {
                user1 = ObjectSpace.CreateObject<DLCEmployee>();
                user1.UserName = "Admin";
                // Set a password if the standard authentication type is used 
                user1.SetPassword("masterkey");
            }
            // If a user named 'John' doesn't exist in the database, create this user 
            //DLCEmployee user2 = ObjectSpace.FindObject<DLCEmployee>(
            //     new BinaryOperator("UserName", "John"));
            //if (user2 == null)
            //{
            //    user2 = ObjectSpace.CreateObject<DLCEmployee>();
            //    user2.UserName = "John";
            //    // Set a password if the standard authentication type is used 
            //    user2.SetPassword("");


            //}
            adminRole.Employees.Add(user1);
            //adminRole.Employees.Add(user2);
        }
    }
}
