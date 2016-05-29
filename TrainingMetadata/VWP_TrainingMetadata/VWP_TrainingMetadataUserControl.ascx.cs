using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

namespace TrainingMetadata.VWP_TrainingMetadata
{
    public partial class VWP_TrainingMetadataUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TaxonomySession session = new TaxonomySession(SPContext.Current.Site);
            TermStore termStore = session.TermStores[0];
            Group myGroup = termStore.CreateGroup("Training");
            TermSet topicTermSet = myGroup.CreateTermSet("Topics");
            string[] topics = new string[] { "CRM", "SharePoint", "End User", "Developer", "IT Administrator", "Introduction", "Advanced" };
            foreach (string topic in topics)
            {
                Term newTerm = topicTermSet.CreateTerm(topic, 1033);

            }
            termStore.CommitAll();
        }
    }
}
