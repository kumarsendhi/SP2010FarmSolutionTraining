using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace Training_EventReceivers.ER_Registrations_ItemDeleted
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_Registrations_ItemDeleted : SPItemEventReceiver
    {
       /// <summary>
       /// An item is being deleted.
       /// </summary>
       public override void ItemDeleting(SPItemEventProperties properties)
       {
           if (properties.ListTitle == "Registrations")
           {
               string registrationID = properties.ListItem["RegistrationID"].ToString();
               int hyphenIndex = registrationID.IndexOf("-");
               string classId = registrationID.Substring(0, hyphenIndex);
               SPWeb currentWeb = properties.Web;
               SPList classesList = currentWeb.Lists["Classes"];
               SPListItem currentClass = classesList.GetItemById(Convert.ToInt32(classId));
               currentClass["Registrations"] = Convert.ToInt32(currentClass["Registrations"].ToString()) - 1;
               currentClass.Update();
           }
           base.ItemDeleting(properties);
       }


    }
}
