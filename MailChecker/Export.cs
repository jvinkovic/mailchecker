using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MailChecker
{
    public partial class Export : Form
    {
        private MailChecker _mailChecker;

        public Export(MailChecker mailChecker)
        {
            _mailChecker = mailChecker;

            var x = _mailChecker.Location.X + (_mailChecker.Width - Width) / 2;
            var y = _mailChecker.Location.Y + (_mailChecker.Height - Height) / 2;
            Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

            _mailChecker.Enabled = false;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>();

            List<string> what = new List<string>();
            if (cbDisposable.Checked)
            {
                what.Add("Disposable");
            }
            if (cbInvalid.Checked)
            {
                what.Add("NO");
            }
            if (cbValid.Checked)
            {
                what.Add("YES");
            }
            if (cbUncertain.Checked)
            {
                what.Add("?");
            }

            if (what.Count == 0)
            {
                MessageBox.Show("Please check at least one group.");
                return;
            }

            for (int i = 0; i < _mailChecker.lvMailsData.Count; i++)
            {
                if (what.Contains(_mailChecker.lvMailsData[i].SubItems[1].Text))
                {
                    data.Add(_mailChecker.lvMailsData[i].SubItems[0].Text);
                }
            }

            string fileType;
            if (rbCSV.Checked)
            {
                fileType = "csv file|*.csv";
            }
            else
            {
                fileType = "txt file|*.txt";
            }

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Filter = fileType;
            sfDialog.Title = "Save file";
            var result = sfDialog.ShowDialog();

            if (sfDialog.FileName != "" && result == DialogResult.OK)
            {
                if (sfDialog.FileName.ToLowerInvariant().EndsWith(fileType.Substring(9, 4)))
                {
                    sfDialog.FileName += fileType.Substring(9, 4);
                }

                using (StreamWriter sw = new StreamWriter(sfDialog.FileName))
                {
                    foreach (var l in data)
                        sw.WriteLine(l);

                    sw.Flush();
                }
            }

            _mailChecker.Enabled = true;
            Close();
        }

        private void rbCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCSV.Checked)
            {
                rbTXT.Checked = false;
            }
            else
            {
                rbTXT.Checked = true;
            }
        }

        private void rbTXT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTXT.Checked)
            {
                rbCSV.Checked = false;
            }
            else
            {
                rbCSV.Checked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _mailChecker.Enabled = true;
            Close();
        }
    }
}