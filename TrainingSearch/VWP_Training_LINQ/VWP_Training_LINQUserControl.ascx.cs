using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Linq;
using Training;

namespace TrainingSearch.VWP_Training_LINQ
{
    public partial class VWP_Training_LINQUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            lbClasses.Items.Clear();
            TrainingDataContext tdc = new TrainingDataContext("http://win-v7htu8u302g/sites/Training");
            var classesList = tdc.Classes;
            var classes = from c in classesList where c.CourseTitleTitle.Contains(tbQuery.Text) select c;
            foreach (ClassesClass aClass in classes)
            {
                lbClasses.Items.Add(aClass.CourseTitleTitle);
                lbClasses.Items.Add("...in " + aClass.Venue.ToString() + ", starting on " + aClass.StartDate.ToString() + ", ending on " + aClass.EndDate.ToString());
            }
            lResultCount.Text = "Found " + classes.Count.ToString() + " classes.";
        }
    }
}
