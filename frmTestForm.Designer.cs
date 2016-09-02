namespace ASyncAwaitTest
{
    partial class frmTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestForm));
            this.grpConnectionDetails = new System.Windows.Forms.GroupBox();
            this.txtSQLServerName = new System.Windows.Forms.TextBox();
            this.lblSQLServerName = new System.Windows.Forms.Label();
            this.lblSQLDatabase = new System.Windows.Forms.Label();
            this.txtSQLPassword = new System.Windows.Forms.TextBox();
            this.lblSQLLogin = new System.Windows.Forms.Label();
            this.txtSQLDatabase = new System.Windows.Forms.TextBox();
            this.lblSQLPassword = new System.Windows.Forms.Label();
            this.txtSQLLogin = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.grpConnectionString = new System.Windows.Forms.GroupBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.txtSQLQuery = new System.Windows.Forms.TextBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.rdExecuteOnly = new System.Windows.Forms.RadioButton();
            this.btnExecute = new System.Windows.Forms.Button();
            this.rdResultsText = new System.Windows.Forms.RadioButton();
            this.rdResultsTable = new System.Windows.Forms.RadioButton();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.tabby = new System.Windows.Forms.TabControl();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.grpConnectionDetails.SuspendLayout();
            this.grpConnectionString.SuspendLayout();
            this.grpQuery.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnectionDetails
            // 
            this.grpConnectionDetails.Controls.Add(this.txtSQLServerName);
            this.grpConnectionDetails.Controls.Add(this.lblSQLServerName);
            this.grpConnectionDetails.Controls.Add(this.lblSQLDatabase);
            this.grpConnectionDetails.Controls.Add(this.txtSQLPassword);
            this.grpConnectionDetails.Controls.Add(this.lblSQLLogin);
            this.grpConnectionDetails.Controls.Add(this.txtSQLDatabase);
            this.grpConnectionDetails.Controls.Add(this.lblSQLPassword);
            this.grpConnectionDetails.Controls.Add(this.txtSQLLogin);
            this.grpConnectionDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConnectionDetails.Location = new System.Drawing.Point(0, 0);
            this.grpConnectionDetails.Name = "grpConnectionDetails";
            this.grpConnectionDetails.Size = new System.Drawing.Size(632, 129);
            this.grpConnectionDetails.TabIndex = 12;
            this.grpConnectionDetails.TabStop = false;
            this.grpConnectionDetails.Text = "Connection String";
            // 
            // txtSQLServerName
            // 
            this.txtSQLServerName.Location = new System.Drawing.Point(79, 20);
            this.txtSQLServerName.Name = "txtSQLServerName";
            this.txtSQLServerName.Size = new System.Drawing.Size(237, 20);
            this.txtSQLServerName.TabIndex = 0;
            this.txtSQLServerName.Text = "MyServer\\Instance";
            // 
            // lblSQLServerName
            // 
            this.lblSQLServerName.AutoSize = true;
            this.lblSQLServerName.Location = new System.Drawing.Point(12, 23);
            this.lblSQLServerName.Name = "lblSQLServerName";
            this.lblSQLServerName.Size = new System.Drawing.Size(62, 13);
            this.lblSQLServerName.TabIndex = 0;
            this.lblSQLServerName.Text = "SQL Server";
            // 
            // lblSQLDatabase
            // 
            this.lblSQLDatabase.AutoSize = true;
            this.lblSQLDatabase.Location = new System.Drawing.Point(12, 49);
            this.lblSQLDatabase.Name = "lblSQLDatabase";
            this.lblSQLDatabase.Size = new System.Drawing.Size(53, 13);
            this.lblSQLDatabase.TabIndex = 0;
            this.lblSQLDatabase.Text = "Database";
            // 
            // txtSQLPassword
            // 
            this.txtSQLPassword.Location = new System.Drawing.Point(79, 98);
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.Size = new System.Drawing.Size(237, 20);
            this.txtSQLPassword.TabIndex = 3;
            this.txtSQLPassword.Text = "MyPassword";
            // 
            // lblSQLLogin
            // 
            this.lblSQLLogin.AutoSize = true;
            this.lblSQLLogin.Location = new System.Drawing.Point(12, 75);
            this.lblSQLLogin.Name = "lblSQLLogin";
            this.lblSQLLogin.Size = new System.Drawing.Size(33, 13);
            this.lblSQLLogin.TabIndex = 0;
            this.lblSQLLogin.Text = "Login";
            // 
            // txtSQLDatabase
            // 
            this.txtSQLDatabase.Location = new System.Drawing.Point(79, 46);
            this.txtSQLDatabase.Name = "txtSQLDatabase";
            this.txtSQLDatabase.Size = new System.Drawing.Size(237, 20);
            this.txtSQLDatabase.TabIndex = 1;
            this.txtSQLDatabase.Text = "MyDatabase";
            // 
            // lblSQLPassword
            // 
            this.lblSQLPassword.AutoSize = true;
            this.lblSQLPassword.Location = new System.Drawing.Point(12, 101);
            this.lblSQLPassword.Name = "lblSQLPassword";
            this.lblSQLPassword.Size = new System.Drawing.Size(53, 13);
            this.lblSQLPassword.TabIndex = 0;
            this.lblSQLPassword.Text = "Password";
            // 
            // txtSQLLogin
            // 
            this.txtSQLLogin.Location = new System.Drawing.Point(79, 72);
            this.txtSQLLogin.Name = "txtSQLLogin";
            this.txtSQLLogin.Size = new System.Drawing.Size(237, 20);
            this.txtSQLLogin.TabIndex = 2;
            this.txtSQLLogin.Text = "SA";
            // 
            // grpConnectionString
            // 
            this.grpConnectionString.Controls.Add(this.txtConnectionString);
            this.grpConnectionString.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConnectionString.Location = new System.Drawing.Point(0, 129);
            this.grpConnectionString.Name = "grpConnectionString";
            this.grpConnectionString.Size = new System.Drawing.Size(632, 46);
            this.grpConnectionString.TabIndex = 13;
            this.grpConnectionString.TabStop = false;
            this.grpConnectionString.Text = "Connection String";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionString.Location = new System.Drawing.Point(3, 16);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(626, 20);
            this.txtConnectionString.TabIndex = 5;
            this.txtConnectionString.Text = "Data Source=MyServer\\Instance;Initial Catalog=MyDatabase;User ID=SA;Password=MyPa" +
    "ssword";
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.txtSQLQuery);
            this.grpQuery.Controls.Add(this.pnlSearch);
            this.grpQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpQuery.Location = new System.Drawing.Point(0, 175);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(632, 155);
            this.grpQuery.TabIndex = 14;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "Query";
            // 
            // txtSQLQuery
            // 
            this.txtSQLQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQLQuery.Location = new System.Drawing.Point(3, 48);
            this.txtSQLQuery.Multiline = true;
            this.txtSQLQuery.Name = "txtSQLQuery";
            this.txtSQLQuery.Size = new System.Drawing.Size(626, 104);
            this.txtSQLQuery.TabIndex = 6;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.rdExecuteOnly);
            this.pnlSearch.Controls.Add(this.btnExecute);
            this.pnlSearch.Controls.Add(this.rdResultsText);
            this.pnlSearch.Controls.Add(this.rdResultsTable);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(3, 16);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(626, 32);
            this.pnlSearch.TabIndex = 0;
            // 
            // rdExecuteOnly
            // 
            this.rdExecuteOnly.AutoSize = true;
            this.rdExecuteOnly.Location = new System.Drawing.Point(206, 8);
            this.rdExecuteOnly.Name = "rdExecuteOnly";
            this.rdExecuteOnly.Size = new System.Drawing.Size(88, 17);
            this.rdExecuteOnly.TabIndex = 0;
            this.rdExecuteOnly.Text = "Execute Only";
            this.rdExecuteOnly.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(549, 5);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.TabStop = false;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // rdResultsText
            // 
            this.rdResultsText.AutoSize = true;
            this.rdResultsText.Location = new System.Drawing.Point(108, 8);
            this.rdResultsText.Name = "rdResultsText";
            this.rdResultsText.Size = new System.Drawing.Size(92, 17);
            this.rdResultsText.TabIndex = 0;
            this.rdResultsText.Text = "Results to text";
            this.rdResultsText.UseVisualStyleBackColor = true;
            // 
            // rdResultsTable
            // 
            this.rdResultsTable.AutoSize = true;
            this.rdResultsTable.Checked = true;
            this.rdResultsTable.Location = new System.Drawing.Point(4, 8);
            this.rdResultsTable.Name = "rdResultsTable";
            this.rdResultsTable.Size = new System.Drawing.Size(98, 17);
            this.rdResultsTable.TabIndex = 0;
            this.rdResultsTable.TabStop = true;
            this.rdResultsTable.Text = "Results to table";
            this.rdResultsTable.UseVisualStyleBackColor = true;
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.tabby);
            this.grpResults.Controls.Add(this.progress);
            this.grpResults.Controls.Add(this.lstResults);
            this.grpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResults.Location = new System.Drawing.Point(0, 330);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(632, 194);
            this.grpResults.TabIndex = 15;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // tabby
            // 
            this.tabby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabby.Location = new System.Drawing.Point(3, 16);
            this.tabby.Name = "tabby";
            this.tabby.SelectedIndex = 0;
            this.tabby.Size = new System.Drawing.Size(626, 96);
            this.tabby.TabIndex = 17;
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progress.Location = new System.Drawing.Point(3, 112);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(626, 23);
            this.progress.TabIndex = 15;
            // 
            // lstResults
            // 
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(3, 135);
            this.lstResults.Name = "lstResults";
            this.lstResults.ScrollAlwaysVisible = true;
            this.lstResults.Size = new System.Drawing.Size(626, 56);
            this.lstResults.TabIndex = 14;
            // 
            // frmTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 524);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpQuery);
            this.Controls.Add(this.grpConnectionString);
            this.Controls.Add(this.grpConnectionDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Async/Await SQL Client Test Harness";
            this.grpConnectionDetails.ResumeLayout(false);
            this.grpConnectionDetails.PerformLayout();
            this.grpConnectionString.ResumeLayout(false);
            this.grpConnectionString.PerformLayout();
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnectionDetails;
        private System.Windows.Forms.TextBox txtSQLServerName;
        private System.Windows.Forms.Label lblSQLServerName;
        private System.Windows.Forms.Label lblSQLDatabase;
        private System.Windows.Forms.TextBox txtSQLPassword;
        private System.Windows.Forms.Label lblSQLLogin;
        private System.Windows.Forms.TextBox txtSQLDatabase;
        private System.Windows.Forms.Label lblSQLPassword;
        private System.Windows.Forms.TextBox txtSQLLogin;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox grpConnectionString;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.TextBox txtSQLQuery;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.RadioButton rdExecuteOnly;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.RadioButton rdResultsText;
        private System.Windows.Forms.RadioButton rdResultsTable;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.TabControl tabby;


    }
}

