using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace Training_EventReceivers.ER_Registrations_ItemAdded
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_Registrations_ItemAdded : SPItemEventReceiver
    {
       /// <summary>
       /// An item was added.
       /// </summary>
       public override void ItemAdded(SPItemEventProperties properties)
       {
           if (properties.ListTitle == "Registrations")
           {
               string classId = properties.ListItem["RegistrationID"].ToString();
               string id = properties.ListItem["ID"].ToString();
               properties.ListItem["RegistrationID"] = classId + "-" + id;
               properties.ListItem.Update();

               SPWeb currentWeb = properties.Web;
               SPList classesList = currentWeb.Lists["Classes"];
               SPListItem currentClass = classesList.GetItemById(Convert.ToInt32(classId));
               currentClass["Registrations"] = Convert.ToInt32(currentClass["Registrations"].ToString()) + 1;
               currentClass.Update();
           }
           base.ItemAdded(properties);
       }


    }
}
