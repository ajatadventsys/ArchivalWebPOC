using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using System.Configuration;
using System.Diagnostics;

namespace ArchivalWebPOC
{
    public partial class GetData : System.Web.UI.Page
    {
        // Three selections Projectcode, FromDate and ToDate and a button to add
        // the data into Archival_Schedule table and display in a view
        // Cronjob will execute
        // Create a view to see the records from secondary table which have moved from primary table
        protected void Page_Load(object sender, EventArgs e)
        {

        }


    }
}