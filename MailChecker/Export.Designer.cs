namespace MailChecker
{
    partial class Export
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
            this.cbValid = new System.Windows.Forms.CheckBox();
            this.cbInvalid = new System.Windows.Forms.CheckBox();
            this.cbDisposable = new System.Windows.Forms.CheckBox();
            this.rbCSV = new System.Windows.Forms.RadioButton();
            this.rbTXT = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbUncertain = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbValid
            // 
            this.cbValid.AutoSize = true;
            this.cbValid.Checked = true;
            this.cbValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbValid.Location = new System.Drawing.Point(12, 12);
            this.cbValid.Name = "cbValid";
            this.cbValid.Size = new System.Drawing.Size(49, 17);
            this.cbValid.TabIndex = 0;
            this.cbValid.Text = "Valid";
            this.cbValid.UseVisualStyleBackColor = true;
            // 
            // cbInvalid
            // 
            this.cbInvalid.AutoSize = true;
            this.cbInvalid.Location = new System.Drawing.Point(12, 35);
            this.cbInvalid.Name = "cbInvalid";
            this.cbInvalid.Size = new System.Drawing.Size(57, 17);
            this.cbInvalid.TabIndex = 1;
            this.cbInvalid.Text = "Invalid";
            this.cbInvalid.UseVisualStyleBackColor = true;
            // 
            // cbDisposable
            // 
            this.cbDisposable.AutoSize = true;
            this.cbDisposable.Location = new System.Drawing.Point(12, 58);
            this.cbDisposable.Name = "cbDisposable";
            this.cbDisposable.Size = new System.Drawing.Size(78, 17);
            this.cbDisposable.TabIndex = 2;
            this.cbDisposable.Text = "Disposable";
            this.cbDisposable.UseVisualStyleBackColor = true;
            // 
            // rbCSV
            // 
            this.rbCSV.AutoSize = true;
            this.rbCSV.Checked = true;
            this.rbCSV.Location = new System.Drawing.Point(142, 34);
            this.rbCSV.Name = "rbCSV";
            this.rbCSV.Size = new System.Drawing.Size(46, 17);
            this.rbCSV.TabIndex = 4;
            this.rbCSV.TabStop = true;
            this.rbCSV.Text = "CSV";
            this.rbCSV.UseVisualStyleBackColor = true;
            this.rbCSV.CheckedChanged += new System.EventHandler(this.rbCSV_CheckedChanged);
            // 
            // rbTXT
            // 
            this.rbTXT.AutoSize = true;
            this.rbTXT.Location = new System.Drawing.Point(142, 57);
            this.rbTXT.Name = "rbTXT";
            this.rbTXT.Size = new System.Drawing.Size(46, 17);
            this.rbTXT.TabIndex = 5;
            this.rbTXT.Text = "TXT";
            this.rbTXT.UseVisualStyleBackColor = true;
            this.rbTXT.CheckedChanged += new System.EventHandler(this.rbTXT_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Location = new System.Drawing.Point(12, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(110, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbUncertain
            // 
            this.cbUncertain.AutoSize = true;
            this.cbUncertain.Location = new System.Drawing.Point(12, 81);
            this.cbUncertain.Name = "cbUncertain";
            this.cbUncertain.Size = new System.Drawing.Size(72, 17);
            this.cbUncertain.TabIndex = 8;
            this.cbUncertain.Text = "Uncertain";
            this.cbUncertain.UseVisualStyleBackColor = true;
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(210, 150);
            this.Controls.Add(this.cbUncertain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbTXT);
            this.Controls.Add(this.rbCSV);
            this.Controls.Add(this.cbDisposable);
            this.Controls.Add(this.cbInvalid);
            this.Controls.Add(this.cbValid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(210, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(210, 150);
            this.Name = "Export";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Export";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbValid;
        private System.Windows.Forms.CheckBox cbInvalid;
        private System.Windows.Forms.CheckBox cbDisposable;
        private System.Windows.Forms.RadioButton rbCSV;
        private System.Windows.Forms.RadioButton rbTXT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbUncertain;
    }
}