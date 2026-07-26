namespace DLLInjector
{
    partial class ProcessListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.txtSearch = new TextBox();
            this.lblSearch = new Label();
            this.btnRefresh = new Button();
            this.lvProcesses = new ListView();
            this.colName = new ColumnHeader();
            this.colPID = new ColumnHeader();
            this.colTitle = new ColumnHeader();
            this.colPath = new ColumnHeader();
            this.panelBottom = new Panel();
            this.btnSelect = new Button();
            this.btnCancel = new Button();
            this.panelHeader.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.txtSearch);
            this.panelHeader.Controls.Add(this.lblSearch);
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 90);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Text = "Select Target Application";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblSearch.Location = new System.Drawing.Point(20, 58);
            this.lblSearch.Text = "Search";

            // txtSearch
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.txtSearch.Location = new System.Drawing.Point(78, 55);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(380, 25);
            this.txtSearch.PlaceholderText = "  Filter by name...";
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);

            // btnRefresh
            this.btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(26, 26, 36);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnRefresh.Location = new System.Drawing.Point(580, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // lvProcesses
            this.lvProcesses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.lvProcesses.BackColor = System.Drawing.Color.FromArgb(14, 14, 20);
            this.lvProcesses.BorderStyle = BorderStyle.None;
            this.lvProcesses.Columns.AddRange(new ColumnHeader[] { this.colName, this.colPID, this.colTitle, this.colPath });
            this.lvProcesses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvProcesses.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.GridLines = false;
            this.lvProcesses.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.lvProcesses.Location = new System.Drawing.Point(0, 90);
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(700, 330);
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = View.Details;
            this.lvProcesses.DoubleClick += new EventHandler(this.lvProcesses_DoubleClick);

            // colName
            this.colName.Text = "Process Name";
            this.colName.Width = 190;

            // colPID
            this.colPID.Text = "PID";
            this.colPID.Width = 80;

            // colTitle
            this.colTitle.Text = "Window Title";
            this.colTitle.Width = 210;

            // colPath
            this.colPath.Text = "Path";
            this.colPath.Width = 220;

            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.panelBottom.Controls.Add(this.btnSelect);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 420);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(700, 56);

            // btnSelect
            this.btnSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(0, 180, 70);
            this.btnSelect.FlatStyle = FlatStyle.Flat;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(480, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 32);
            this.btnSelect.Text = "Select";
            this.btnSelect.Cursor = Cursors.Hand;
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);

            // btnCancel
            this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(26, 26, 36);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            this.btnCancel.Location = new System.Drawing.Point(590, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // ProcessListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.ClientSize = new System.Drawing.Size(700, 476);
            this.Controls.Add(this.lvProcesses);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Name = "ProcessListForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Select Application";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnRefresh;
        private ListView lvProcesses;
        private ColumnHeader colName;
        private ColumnHeader colPID;
        private ColumnHeader colTitle;
        private ColumnHeader colPath;
        private Panel panelBottom;
        private Button btnSelect;
        private Button btnCancel;
    }
}
