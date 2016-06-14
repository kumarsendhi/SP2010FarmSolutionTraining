using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace Training_EventReceivers.ER_Classes_ItemAdded
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_Classes_ItemAdded : SPItemEventReceiver
    {
       /// <summary>
       /// An item was added.
       /// </summary>
       public override void ItemAdded(SPItemEventProperties properties)
       {
           string courseTitle = properties.ListItem["Course Title"].ToString();
           string trimmedCourseID = courseTitle.Remove(0, 3);
           string classID = trimmedCourseID + "-" + properties.ListItem["ID"].ToString();
           properties.ListItem["Class ID"] = classID;
           properties.ListItem.Update();
           base.ItemAdded(properties);

       }


    }
}
