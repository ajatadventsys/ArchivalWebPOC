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

        //Try to insert the a row in Archival_Schedule table
        //Then try to display the records dynamically based on the table name 
        //because each one will be having different columns
        //dynamically there is feature in devexpress to view table dynamically

        string connectionString = ConfigurationManager.ConnectionStrings["LIMSDevConnectionString"].ConnectionString;
        private DataTable ArchivalTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FromDateAdd.Date = DateTime.Now;
                ToDateAdd.Date = FromDateAdd.Date;
                LoadProjectCodes();
                LoadTaskView();
            }
            //ViewState - as we move to different pages need not to click view again
            else
            {
                // Retrieve data from ViewState and bind to grid
                if (ViewState["StorageTable"] != null)
                {
                    ArchivalTable = (DataTable)ViewState["ArchivalTable"];
                    BindDataToGridView();
                }
                //this is for refresh
                else
                {
                    TaskDetails.DataSource = null;
                    TaskDetails.DataBind();
                }
            }
        }

        //Get ProjectCodes
        private void LoadProjectCodes()
        {
            using (var context = new LIMSDevConnectionString())
            {
                var projectCodes = from p in context.PS_LISProjects
                                   where p.IsActive == true
                                   select new
                                   { p.SystemId, p.ProjectCode };
                ProjectSelectAdd.DataSource = projectCodes.ToList();
                ProjectSelectAdd.DataValueField = "SystemId";
                ProjectSelectAdd.DataValueField = "ProjectCode";
                ProjectSelectAdd.DataBind();
            }
        }

        //Bind
        private void BindDataToGridView()
        {
            try
            {
                if (ArchivalTable != null && ArchivalTable.Rows.Count > 0)
                {
                    TaskDetails.DataSource = ArchivalTable;
                    TaskDetails.DataBind();
                }
                //this is for refresh
                else
                {
                    TaskDetails.DataSource = null;
                    TaskDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.ToString());
            }
        }

        //Insert the details to ArchivalSchedule
        protected void AddTask_Click(object sender, EventArgs e)
        {
            try
            {
                string projectCode = ProjectSelectAdd != null ? ProjectSelectAdd.SelectedItem.Text : ProjectSelectAdd.Items[0].Text;
                DateTime? fromDate = FromDateAdd.Date;
                DateTime? toDate = ToDateAdd.Date;
                string openStatus = "Open";
                DateTime? createdOn = DateTime.Now;
                string createdBy = "Ajay";
                string openRemarks = "To be Executed";
                DateTime? lastUpdate = DateTime.Now;

                using (var context = new LIMSDevConnectionString())
                {
                    var newTask = new ArchivalSchedule
                    {
                        ProjectCode = projectCode,
                        FromDate = fromDate,
                        ToDate = toDate,
                        Status = openStatus,
                        CreatedOn = createdOn,
                        CreatedBy = createdBy,
                        Remarks = openRemarks,
                        LastUpdate = lastUpdate
                    };
                    context.ArchivalSchedules.Add(newTask);
                    int result1 = context.SaveChanges();
                    if(result1 > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("result1");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("else");
                    }
                }
                LoadTaskView();
                //BindDataToGridView();
                clearInputFields();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex}");
            }
        }

        //load the data for Task view
        protected void LoadTaskView()
        {
            try
            {
                using (var context = new LIMSDevConnectionString())
                {
                    var taskView = from tv in context.ArchivalSchedules select tv;
                    TaskDetails.DataSource = taskView.ToList();
                    TaskDetails.DataBind();
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex}");
            }
        }

        //clear input fields
        protected void clearInputFields()
        {
            ProjectSelectAdd.SelectedIndex = -1;
            FromDateAdd.Date = DateTime.Now;
            ToDateAdd.Date = DateTime.Now;
        }
    }
}