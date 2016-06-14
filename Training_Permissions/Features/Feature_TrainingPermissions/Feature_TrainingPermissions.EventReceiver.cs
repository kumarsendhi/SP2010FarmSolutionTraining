using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace Training_Permissions.Features.Feature_TrainingPermissions
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("7a9f4224-684f-4865-990b-bc02b11670e7")]
    public class Feature_TrainingPermissionsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite currentSite = properties.Feature.Parent as SPSite;
            SPWeb rootWeb = currentSite.RootWeb;

            SPUser currentUser = rootWeb.CurrentUser;

            SPGroupCollection groups = rootWeb.SiteGroups;

            groups.Add("Training Administrators", currentUser, currentUser, "All Globomantics Training Administrators are in this group");

            SPGroup trainingAdmins = groups["Training Administrators"];

            groups.Add("Trainers", trainingAdmins, currentUser, "All Globomantics Trainers are in this group");
            groups.Add("Students", trainingAdmins, currentUser, "All Globomantics students are in this group");

            SPRoleDefinition fullControl = rootWeb.RoleDefinitions["Full Control"];

            SPRoleDefinition contribute = rootWeb.RoleDefinitions["Contribute"];
            SPRoleDefinition read = rootWeb.RoleDefinitions["Read"];

            SPRoleAssignment trainersRoleAssignment = new SPRoleAssignment(groups["Trainers"]);
            trainersRoleAssignment.RoleDefinitionBindings.Add(contribute);
            rootWeb.RoleAssignments.Add(trainersRoleAssignment);

            SPRoleAssignment studentsRoleAssignment = new SPRoleAssignment(groups["Students"]);
            studentsRoleAssignment.RoleDefinitionBindings.Add(read);
            rootWeb.RoleAssignments.Add(studentsRoleAssignment);

            SPList registrationsList = rootWeb.Lists["Registrations"];
            registrationsList.BreakRoleInheritance(true);
            SPRoleAssignment registrationsRoleAssignment = new SPRoleAssignment(groups["Students"]);
            registrationsRoleAssignment.RoleDefinitionBindings.Add(contribute);
            registrationsList.RoleAssignments.Add(registrationsRoleAssignment);

            SPRoleAssignment trainingAdminsRoleAssignment = new SPRoleAssignment(trainingAdmins);
            trainingAdminsRoleAssignment.RoleDefinitionBindings.Add(fullControl);
            rootWeb.RoleAssignments.Add(trainingAdminsRoleAssignment);




        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite currentSite = properties.Feature.Parent as SPSite;
            SPWeb rootWeb = currentSite.RootWeb;

            SPUser currentUser = rootWeb.CurrentUser;

            SPGroupCollection groups = rootWeb.SiteGroups;

            groups.Remove("Trainers");
            groups.Remove("Training Administrators");
            groups.Remove("Students");

            SPList registrationsList = rootWeb.Lists["Registrations"];
            registrationsList.ResetRoleInheritance();
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
