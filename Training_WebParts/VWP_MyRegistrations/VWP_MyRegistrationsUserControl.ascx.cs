using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.Office.Server;
using Microsoft.Office.Server.UserProfiles;

namespace Training_WebParts.VWP_MyRegistrations
{
    public partial class VWP_MyRegistrationsUserControl : UserControl
    {
        SPWeb currentWeb;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentWeb = SPContext.Current.Web;
            SPUser currentUser = currentWeb.CurrentUser;
            UserProfileManager upm = new UserProfileManager(SPServiceContext.Current);
            UserProfile currentProfile = upm.GetUserProfile(true);
            string eMail = currentProfile["WorkEmail"].ToString();
            SPList registrationsList = currentWeb.Lists["Registrations"];
            SPQuery getRegistrationsForUser = new SPQuery();
            getRegistrationsForUser.ViewFields = "<FieldRef Name = 'Title'/><FieldRef Name='ID'/>";
            getRegistrationsForUser.Query = "<Where><Eq><FieldRef Name='E_x002d_mail_x0020_Address' /><Value Type='Text'>" + eMail + "</Value></Eq></Where>";
            SPListItemCollection currentUserRegistrations = registrationsList.GetItems(getRegistrationsForUser);
            if (currentUserRegistrations.Count > 0)
            {
                foreach (SPListItem registration in currentUserRegistrations)
                {
                    string title = registration["Title"].ToString();
                    string classId = title.Substring(0, title.IndexOf('-'));

                    SPListItem theClass = GetClass(classId);
                    ListItem newItem = new ListItem(theClass["Course Title"].ToString().Remove(0,3) +"/"+theClass["Venue"].ToString()+"/"+theClass["Start Date"].ToString()+"/"+theClass["End Date"].ToString(),registration["ID"].ToString());
                    lbClasses.Items.Add(newItem);
                }
            }
            else{
                lbClasses.Items.Add("You are not registered for any classes.");
            }

        }

        private SPListItem GetClass(string classId)
        {
            SPList classesList = currentWeb.Lists["Classes"];
            SPListItem theClass = classesList.GetItemById(Convert.ToInt32(classId));
            return theClass;
        }
    }
}
