using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace Trainers_Registrations.Features.Feature_TrainingList
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("26e3d09a-7c0a-46fa-a86d-80378100d74c")]
    public class Feature_TrainingListEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb currentWeb = properties.Feature.Parent as SPWeb;

            SPList rlist = currentWeb.Lists["Registrations"];
            SPList tlist = currentWeb.Lists["Trainers"];

            SPFieldCollection rFields = rlist.Fields;
            SPFieldCollection tFields = tlist.Fields;

            SPField fullNameField = tFields["Full Name"];
            fullNameField.Required = true;
            fullNameField.Update();

            SPField emailField = tFields["E-mail Address"];
            emailField.Required = true;
            emailField.Update();

            SPField titleField = rFields["Title"];
            titleField.Title = "RegistrationID";
            titleField.Update();

            rFields.Add("First Name", SPFieldType.Text, true);
            rFields.Add("Last Name", SPFieldType.Text, true);
            rFields.Add("E-mail Address", SPFieldType.Text, true);
            rFields.Add("Phone Number", SPFieldType.Text, false);
            rFields.Add("ClassID", SPFieldType.Text, false);
            rlist.Update();

            SPField classIDField = rFields["ClassID"];
            classIDField.ReadOnlyField = true;
            classIDField.Update();


            SPView tDefaultView = tlist.DefaultView;
            tDefaultView.ViewFields.Delete("Attachments");
            tDefaultView.Update();

            SPView rDefaultView = rlist.DefaultView;
            rDefaultView.ViewFields.Delete("Attachments");
            rDefaultView.ViewFields.Add("First Name");
            rDefaultView.ViewFields.Add("Last Name");
            rDefaultView.ViewFields.Add("E-mail Address");
            rDefaultView.ViewFields.Add("Phone Number");
            rDefaultView.Update();


        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


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
