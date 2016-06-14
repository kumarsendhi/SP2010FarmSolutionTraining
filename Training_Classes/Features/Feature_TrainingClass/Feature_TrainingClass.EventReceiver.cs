using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace Training_Classes.Features.Feature_TrainingClass
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("35b294ef-2a0f-46ec-b411-911f5dbfcaec")]
    public class Feature_TrainingClassEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb currentWeb = properties.Feature.Parent as SPWeb;
            SPList classesList = currentWeb.Lists["Classes"];

            SPField titleField = classesList.Fields["Title"];
            titleField.Required = false;
            titleField.ShowInNewForm = false;
            titleField.ShowInEditForm = false;
            titleField.Title = "Class ID";
            titleField.Update();

            SPField registrationsField = classesList.Fields["Registrations"];
            registrationsField.DefaultValue = "0";
            registrationsField.ShowInNewForm = false;
            registrationsField.Update();

            SPFieldDateTime startDate = currentWeb.Fields["Start Date"] as SPFieldDateTime;
            startDate.DisplayFormat = SPDateTimeFieldFormatType.DateTime;
            SPFieldDateTime endDate = currentWeb.Fields["End Date"] as SPFieldDateTime;
            endDate.DisplayFormat = SPDateTimeFieldFormatType.DateTime;
            classesList.Fields.Add(startDate);
            classesList.Fields.Add(endDate);
            SPView defaultView = classesList.DefaultView;
            defaultView.ViewFields.Add(startDate);
            defaultView.ViewFields.Add(endDate);
            defaultView.Update();
            classesList.Update();
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
