using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace Training_AddTrainers.Features.Feature_AddTrainers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("96ab80eb-d940-427b-9cc2-adda135198ca")]
    public class Feature_AddTrainersEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = null;
            try
            {
                site = new SPSite("http://win-v7htu8u302g/sites/Training");
                SPWeb web = site.RootWeb;
                SPList trainersList = web.Lists["Trainers"];

                SPListItem newTrainerAlan = trainersList.Items.Add();
                newTrainerAlan["First Name"] = "Alan";
                newTrainerAlan["Last Name"] = "Franklin";
                newTrainerAlan["Full Name"] = "Alan Franklin";
                newTrainerAlan["Company"] = "Globomantics";
                newTrainerAlan["Business Phone"] = "800-555-1234";
                newTrainerAlan["Home Phone"] = "800-555-4321";
                newTrainerAlan["E-mail Address"] = "afranklin@globomantics.com";
                newTrainerAlan.Update();


            }

            catch (Exception e)
            {

            }
            finally
            {
                if (site != null)
                {
                    site.Dispose();
                }
                Console.WriteLine("***************************DONE******************");
                Console.WriteLine("Press any key to continue...");
            }

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
