using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace TrainingSearch.VWP_Training_CAMLQuery
{
    public partial class VWP_Training_CAMLQueryUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            lbClasses.Items.Clear();
            SPWeb currentWeb = SPContext.Current.Web;
            SPList classesList = currentWeb.Lists["Classes"];
            SPQuery classesQuery = new SPQuery();
            classesQuery.ViewFields = "<FieldRef Name='CourseTitle'/><FieldRef Name='Trainer'/><FieldRef Name='Venue'/><FieldRef Name='StartDate'/><FieldRef Name='_EndDate'/>";
            classesQuery.Query = "<Where><Contains><FieldRef Name='CourseTitle'/><Value Type='Text'>" + tbQuery.Text + "</Value></Contains></Where>";
            SPListItemCollection introClasses =   classesList.GetItems(classesQuery);
            foreach (SPListItem introClass in introClasses)
            {
                lbClasses.Items.Add(introClass["Course Title"].ToString());
                lbClasses.Items.Add("...in "+introClass["Venue"].ToString()+", starting on "+introClass["Start Date"].ToString()+", ending on "+introClass["End Date"].ToString());
            }
            lResultCount.Text = "Found " + introClasses.Count.ToString() + " classes.";
        }
    }
}
