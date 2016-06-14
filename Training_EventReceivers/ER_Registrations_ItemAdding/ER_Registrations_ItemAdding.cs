using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Web;

namespace Training_EventReceivers.ER_Registrations_ItemAdding
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ER_Registrations_ItemAdding : SPItemEventReceiver
    {
        HttpContext httpContext = null;
        public ER_Registrations_ItemAdding()
        {
            httpContext = HttpContext.Current;
        }
       /// <summary>
       /// An item is being added.
       /// </summary>
       public override void ItemAdding(SPItemEventProperties properties)
       {
           if (properties.ListTitle == "Registrations")
           {
               Uri currentUri = httpContext.Request.Url;
               string queryString = currentUri.Query;
               string classId = queryString.Remove(0, 9);
               properties.AfterProperties["Title"] = classId;
               

           }
           base.ItemAdding(properties);
       }


    }
}
