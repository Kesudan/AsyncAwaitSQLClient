using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ASyncAwaitTest
{
    public partial class frmTestForm : System.Windows.Forms.Form
    {
        #region Form Initialize Code
        //Event handlers and form initialization code
        private int m_QueryNumber = 0;
        public frmTestForm()
        {
            InitializeComponent();

            //Add event handlers
            DoEventHandlers(true);
        }
        private void DoEventHandlers(bool bAdd)
        {
            if (bAdd)
            {
                //Add event handlers
                txtSQLServerName.TextChanged += BuildConnectionString;
                txtSQLDatabase.TextChanged += BuildConnectionString;
                txtSQLLogin.TextChanged += BuildConnectionString;
                txtSQLPassword.TextChanged += BuildConnectionString;
                txtConnectionString.TextChanged += BuildConnectionString;
                btnExecute.Click += btnExecute_Click;
                timer.Tick += timer_Tick;
            }
            else
            {
                //Remove event handlers
                txtSQLServerName.TextChanged -= BuildConnectionString;
                txtSQLDatabase.TextChanged -= BuildConnectionString;
                txtSQLLogin.TextChanged -= BuildConnectionString;
                txtSQLPassword.TextChanged -= BuildConnectionString;
                txtConnectionString.TextChanged -= BuildConnectionString;
                btnExecute.Click -= btnExecute_Click;
                timer.Tick -= timer_Tick;
            }
        }

        private void BuildConnectionString(object sender, EventArgs e)
        {
            try
            {
                var csb = new SqlConnectionStringBuilder(txtConnectionString.Text);

                if (sender == txtConnectionString)
                {
                    //Fill fields from connection string
                    txtSQLServerName.Text = csb.DataSource;
                    txtSQLDatabase.Text = csb.InitialCatalog;
                    txtSQLLogin.Text = csb.UserID;
                    txtSQLPassword.Text = csb.Password;
                }
                else
                {
                    //Build connection string from fields
                    csb.DataSource = txtSQLServerName.Text;
                    csb.InitialCatalog = txtSQLDatabase.Text;
                    csb.UserID = txtSQLLogin.Text;
                    csb.Password = txtSQLPassword.Text;

                    txtConnectionString.Text = csb.ToString();
                }
            }
            catch (System.ArgumentException argex)
            {
                lstResults.Items.Add(argex.Message);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (progress.Value < progress.Maximum)
                progress.Increment(5);
            else
                progress.Value = progress.Minimum;
        }

        #endregion
        
        //Main procedure which demonstrates the async/await operations
        private void Execute()
        {
            //Start
            m_QueryNumber += 1; var iQueryNumber = m_QueryNumber; 
            timer.Start(); //progress bar for basic visual feedback.
            AddLogItem("Started query " + iQueryNumber + " at " + DateTime.Now.ToString());
                           
            //Results to table:
            if (rdResultsTable.Checked) {
                ResultsToGrid(iQueryNumber);
            }
            //Results to text:  
            else if (rdResultsText.Checked)
            {
                ResultsToText(iQueryNumber);
            }
            //Execute only:
            else if (rdExecuteOnly.Checked)
            {
                ExecuteOnly(iQueryNumber);
            }

            //Finished
            timer.Stop(); progress.Value = progress.Minimum; //progress bar for basic visual feedback.
            AddLogItem("Finished query " + iQueryNumber + " at " + DateTime.Now.ToString()); 
        }

        //Results to grid
        private async void ResultsToGrid(int iQuery)
        {
            CDatabase database = new CDatabase();
            try
            {
                //Using task function to get dataset asynchronously.
                DataSet results = await database.GetDataSetAsync(txtConnectionString.Text, txtSQLQuery.Text);
                //Now that we have our data populate to new tab.
                PopulateGridResults(iQuery, results.Tables[0]);
            }
            catch (SqlException sqlError)
            {
                //In this case our task function is set to pass the error through to the caller, log error to list.
                AddLogItem("ResultsToTable Error: " + sqlError.Message);
            }
        }

        
        //Results to text
        private async void ResultsToText(int iQuery)
        {
            CDatabase database = new CDatabase();

            //Using task function to get results to custom class and pass through to separate method using "ContinueWith"
            //Sidenote 1: I use "this.Invoke" as the PopulateTextResults needs to add controls to form. 
            //Sidenote 2: The error is caught by the function and passed via the custom class object.
            await database.GetTextDataToCustomClassAsync(txtConnectionString.Text, txtSQLQuery.Text).ContinueWith(t => this.Invoke((Action)(() => { PopulateTextResults(iQuery, t.Result); })));
        }

        //Execute only
        private async void ExecuteOnly(int iQuery)
        {
            CDatabase database = new CDatabase();
            try
            {
                //Using task function to run the command asynchronously and get the number of rows affected.
                int iResults = await database.ExecuteAsync(txtConnectionString.Text, txtSQLQuery.Text);
                //Log the rows affected.
                if (iResults < 0) { AddLogItem("No Rows Updated"); } else { AddLogItem(String.Format("{0} Row(s) Updated", iResults)); }
            }
            catch (Exception ex)
            {
                //In this case our task function is set to pass the error through to the caller, log error to list.
                AddLogItem("Execute Only Error: " + ex.Message);
            }
        }

        //Chaining tasks
        private async void ChainExecuteOnly(int iQuery, List<string> lstQueries)
        {
            //Build tasks based on the list of queries passed in and execute all async.

            CDatabase database = new CDatabase();

            //Build task list
            List<Task<int>> lstTasks = new List<Task<int>>();
            lstQueries.ForEach(delegate (string sQuery)
            {
                Task<int> ExecuteTask = database.ExecuteAsync(txtConnectionString.Text, sQuery);
                lstTasks.Add(ExecuteTask); 
            });
            //Convert to array and run
            Task<int>[] arrTasks = lstTasks.ToArray();
            await Task.WhenAll(arrTasks);

            //Get results
            int iRowsAffected = 0;
            lstTasks.ForEach(delegate (Task<int> tTask)
            {
                iRowsAffected += tTask.Result; 
            });

            //Log results
            AddLogItem(String.Format("{0} Row(s) Updated", iRowsAffected));
        }



        #region Result Population Code
        //Add item to log.
        private void AddLogItem(string sItem)
        {
            lstResults.Items.Add(sItem);
            lstResults.SelectedIndex = lstResults.Items.Count - 1;
        }

        //Add new tab with DataGrid and populate with results from data table.
        private void PopulateGridResults(int iQueryId, DataTable dtResult)
        {
            //Add as new tab
            string sPageId = "Page" + iQueryId;
            string sPage = "Result Page " + iQueryId;

            tabby.TabPages.Add(sPageId, sPage);
            DataGridView results = new DataGridView()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Name = "grd" + sPageId,
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };
            tabby.TabPages[sPageId].Controls.Add(results);
            results.DataSource = dtResult;
            tabby.SelectedTab = tabby.TabPages[sPageId];

        }

        //Add new tab with TextBox and populate with results from custom class object.
        private void PopulateTextResults(int iQueryId, CDatabase.CDatabaseResult dbResult)
        {
            //Do something with results
            if (dbResult.Success)
            {
                //Add as new tab
                string sPageId = "Page" + iQueryId;
                string sPage = "Result Page " + iQueryId;

                tabby.TabPages.Add(sPageId, sPage);
                TextBox results = new TextBox()
                {
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    Name = "txt" + sPageId,
                    Multiline = true,
                    WordWrap = false
                };
                tabby.TabPages[sPageId].Controls.Add(results);
                results.Text = dbResult.Data.ToString();
                tabby.SelectedTab = tabby.TabPages[sPageId];
            }
            else
            {
                //Write error to form.
                AddLogItem("PopulateTextResults Error:" + dbResult.Result);
            }
        }
        #endregion

    }
}
