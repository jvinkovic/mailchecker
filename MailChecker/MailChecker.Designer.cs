namespace MailChecker
{
    partial class MailChecker
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
            System.Windows.Forms.ColumnHeader Email;
            System.Windows.Forms.ColumnHeader Validity;
            System.Windows.Forms.ColumnHeader Log;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailChecker));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invalidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disposableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMails = new System.Windows.Forms.ListView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblValid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInvalid = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDisposable = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblProcessed = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.btnAddMail = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbHostname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.cbYahoo = new System.Windows.Forms.CheckBox();
            Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Validity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Log = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Email
            // 
            Email.Text = "Email";
            Email.Width = 280;
            // 
            // Validity
            // 
            Validity.Text = "Validity";
            Validity.Width = 65;
            // 
            // Log
            // 
            Log.Text = "Log";
            Log.Width = 414;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(814, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validToolStripMenuItem,
            this.invalidToolStripMenuItem,
            this.disposableToolStripMenuItem,
            this.clearFilterToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // validToolStripMenuItem
            // 
            this.validToolStripMenuItem.Name = "validToolStripMenuItem";
            this.validToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.validToolStripMenuItem.Text = "Valid";
            this.validToolStripMenuItem.Click += new System.EventHandler(this.validToolStripMenuItem_Click);
            // 
            // invalidToolStripMenuItem
            // 
            this.invalidToolStripMenuItem.Name = "invalidToolStripMenuItem";
            this.invalidToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.invalidToolStripMenuItem.Text = "Invalid";
            this.invalidToolStripMenuItem.Click += new System.EventHandler(this.invalidToolStripMenuItem_Click);
            // 
            // disposableToolStripMenuItem
            // 
            this.disposableToolStripMenuItem.Name = "disposableToolStripMenuItem";
            this.disposableToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.disposableToolStripMenuItem.Text = "Disposable";
            this.disposableToolStripMenuItem.Click += new System.EventHandler(this.disposableToolStripMenuItem_Click);
            // 
            // clearFilterToolStripMenuItem
            // 
            this.clearFilterToolStripMenuItem.Name = "clearFilterToolStripMenuItem";
            this.clearFilterToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.clearFilterToolStripMenuItem.Text = "Clear filter";
            this.clearFilterToolStripMenuItem.Click += new System.EventHandler(this.clearFilterToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Emails";
            // 
            // lvMails
            // 
            this.lvMails.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvMails.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvMails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMails.CheckBoxes = true;
            this.lvMails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Email,
            Validity,
            Log});
            this.lvMails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvMails.FullRowSelect = true;
            this.lvMails.GridLines = true;
            this.lvMails.Location = new System.Drawing.Point(15, 168);
            this.lvMails.Name = "lvMails";
            this.lvMails.ShowItemToolTips = true;
            this.lvMails.Size = new System.Drawing.Size(790, 230);
            this.lvMails.TabIndex = 3;
            this.lvMails.UseCompatibleStateImageBehavior = false;
            this.lvMails.View = System.Windows.Forms.View.Details;
            this.lvMails.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvMails_ColumWithChanging);
            this.lvMails.SizeChanged += new System.EventHandler(this.AdjustColumnsSizes);
            this.lvMails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvMails_KeyDown);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 56);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(93, 56);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(174, 56);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 27);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(237, 23);
            this.progressBar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Elapsed time:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(88, 95);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LawnGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(171, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Valid:";
            // 
            // lblValid
            // 
            this.lblValid.AutoSize = true;
            this.lblValid.Location = new System.Drawing.Point(225, 95);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(13, 13);
            this.lblValid.TabIndex = 11;
            this.lblValid.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(171, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Invalid:";
            // 
            // lblInvalid
            // 
            this.lblInvalid.AutoSize = true;
            this.lblInvalid.Location = new System.Drawing.Point(225, 120);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(13, 13);
            this.lblInvalid.TabIndex = 13;
            this.lblInvalid.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Pink;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(171, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Disposable:";
            // 
            // lblDisposable
            // 
            this.lblDisposable.AutoSize = true;
            this.lblDisposable.Location = new System.Drawing.Point(239, 149);
            this.lblDisposable.Name = "lblDisposable";
            this.lblDisposable.Size = new System.Drawing.Size(13, 13);
            this.lblDisposable.TabIndex = 17;
            this.lblDisposable.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Processed:";
            // 
            // lblProcessed
            // 
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Location = new System.Drawing.Point(88, 117);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(24, 13);
            this.lblProcessed.TabIndex = 19;
            this.lblProcessed.Text = "0/0";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(715, 120);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 42);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tbMail
            // 
            this.tbMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMail.Location = new System.Drawing.Point(557, 30);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(245, 20);
            this.tbMail.TabIndex = 21;
            // 
            // btnAddMail
            // 
            this.btnAddMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMail.Location = new System.Drawing.Point(557, 56);
            this.btnAddMail.Name = "btnAddMail";
            this.btnAddMail.Size = new System.Drawing.Size(75, 23);
            this.btnAddMail.TabIndex = 22;
            this.btnAddMail.Text = "Add to list";
            this.btnAddMail.UseVisualStyleBackColor = true;
            this.btnAddMail.Click += new System.EventHandler(this.btnAddMail_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(516, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Email:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(710, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 23);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete checked";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Find:";
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(497, 142);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(212, 20);
            this.tbFind.TabIndex = 26;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(304, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Filter: ";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFilter.Location = new System.Drawing.Point(351, 148);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(31, 13);
            this.lblFilter.TabIndex = 28;
            this.lblFilter.Text = "none";
            // 
            // tbHostname
            // 
            this.tbHostname.Location = new System.Drawing.Point(360, 27);
            this.tbHostname.Name = "tbHostname";
            this.tbHostname.Size = new System.Drawing.Size(150, 20);
            this.tbHostname.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Custom hostname:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(256, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Custom from address:";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(360, 59);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(150, 20);
            this.tbFrom.TabIndex = 32;
            // 
            // cbYahoo
            // 
            this.cbYahoo.AutoSize = true;
            this.cbYahoo.Checked = true;
            this.cbYahoo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbYahoo.Location = new System.Drawing.Point(360, 95);
            this.cbYahoo.Name = "cbYahoo";
            this.cbYahoo.Size = new System.Drawing.Size(303, 17);
            this.cbYahoo.TabIndex = 33;
            this.cbYahoo.Text = "Send mails to yahoo accounts (accurate but slower check)";
            this.cbYahoo.UseVisualStyleBackColor = true;
            this.cbYahoo.CheckedChanged += new System.EventHandler(this.cbYahoo_CheckedChanged);
            // 
            // MailChecker
            // 
            this.AcceptButton = this.btnAddMail;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 411);
            this.Controls.Add(this.cbYahoo);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbHostname);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAddMail);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDisposable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblInvalid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblValid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lvMails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(830, 450);
            this.Name = "MailChecker";
            this.Text = "MailChecker";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMails;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInvalid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDisposable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblProcessed;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Button btnAddMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invalidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disposableToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.ToolStripMenuItem clearFilterToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbHostname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.CheckBox cbYahoo;
    }
}

