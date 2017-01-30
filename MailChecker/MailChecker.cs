using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MailChecker
{
    public partial class MailChecker : Form
    {
        private ListView allItemsLv = new ListView();

        internal ListView.ListViewItemCollection lvMailsData;
        private FileStream file;
        private bool paused = false;

        private Thread checkerThread;
        private System.Windows.Forms.Timer timer;
        private Stopwatch stopwatch;
        private List<string> mails = new List<string>();

        private long processed = 0;
        private long mailsNum = 0;

        private long valid = 0;
        private long invalid = 0;
        private long disposable = 0;

        private int _maxLogWidth = 0;
        private bool _isEnd = false;

        public MailChecker()
        {
            InitializeComponent();

            lvMails.DoubleBuffered(true);
        }

        private void lvMails_ColumWithChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvMails.Columns[e.ColumnIndex].Width;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkerThread?.Abort();
            file?.Close();
            file?.Dispose();
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool again = false;

            do
            {
                // Displays an OpenFileDialog so the user can select a Cursor.
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text file|*.txt|Excel files|*.xlsx;*.xls|CSV file|*.csv";
                openFileDialog.Title = "Open a file with emails";

                // Show the Dialog.
                // If the user clicked OK in the dialog and
                // a file was selected, open it.
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    clearAll(true);

                    string filename = openFileDialog.SafeFileName;
                    string ext = filename.Substring(filename.LastIndexOf('.') + 1);

                    switch (ext)
                    {
                        case "txt":
                            ProcessTXTOrCSVFile(openFileDialog.FileName);
                            break;

                        case "xlsx":
                            ProcessXLSXFile(openFileDialog.FileName);
                            break;

                        case "xls":
                            ProcessXLSFile(openFileDialog.FileName);
                            break;

                        case "csv":
                            ProcessTXTOrCSVFile(openFileDialog.FileName);
                            break;

                        default:
                            MessageBox.Show("File is broken!");
                            again = true;
                            break;
                    }
                }

                openFileDialog.Dispose();
            } while (again);

            lblProcessed.Text = processed + "/" + mailsNum;
        }

        private void ProcessXLSXFile(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            // Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            List<string> lines = new List<string>();
            // Data Reader methods
            while (excelReader.Read())
            {
                string l = excelReader.GetString(0);
                lines.Add(l);
            }

            PutMailsToListView(lines);

            // Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
        }

        private void ProcessXLSFile(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            // Reading from a OpenXml Excel file (2007 format; *.xls)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            List<string> lines = new List<string>();
            // Data Reader methods
            while (excelReader.Read())
            {
                string l = excelReader.GetString(0);
                lines.Add(l);
            }

            PutMailsToListView(lines);

            // Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
        }

        private void ProcessTXTOrCSVFile(string fileName)
        {
            var filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var file = new StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

            List<string> lines = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            PutMailsToListView(lines);
        }

        private void PutMailsToListView(List<string> lines)
        {
            var items = new List<ListViewItem>();
            foreach (var l in lines)
            {
                string line = l?.Trim();
                if (line == string.Empty || line == null)
                {
                    continue;
                }
                ListViewItem item = new ListViewItem(line);
                item.SubItems.Add("?");
                item.SubItems.Add("");
                items.Add(item);
            }

            lvMails.BeginUpdate();
            lvMails.Items.AddRange(items.ToArray());
            lvMails.EndUpdate();

            mailsNum = lvMails.Items.Count;
            mails.AddRange(lines.Where(l => l != null && l?.Trim() != string.Empty));

            allItemsLv = lvMails.CopyListView();

            lvMails.TopItem = lvMails.Items.Cast<ListViewItem>().LastOrDefault();
        }

        private void clearAll(bool opening = false)
        {
            if (opening)
                return;

            DialogResult dialogResult = MessageBox.Show("Are you sure that you want to clear everything?", "Confirm clear all", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            _maxLogWidth = 0;

            tbFrom.Enabled = true;
            tbHostname.Enabled = true;
            tbHostname.Clear();
            lblFilter.Text = "none";
            tbFind.Clear();
            tbMail.Clear();
            lvMails.Items.Clear();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            tbFind.Enabled = true;
            btnPause.Enabled = false;
            btnPause.Text = "Pause";
            btnExport.Enabled = false;
            btnAddMail.Enabled = true;
            btnDelete.Enabled = true;

            lblDisposable.Text = "0";
            lblInvalid.Text = "0";
            lblProcessed.Text = "";
            lblTime.Text = "";
            lblValid.Text = "0";

            processed = 0;
            valid = 0;
            invalid = 0;
            disposable = 0;
            progressBar.Value = 0;

            mailsNum = 0;
            mails.Clear();

            paused = false;

            checkerThread?.Abort();
            checkerThread = null;

            file?.Close();
            file?.Dispose();
            file = null;

            timer?.Dispose();
            timer = null;

            stopwatch?.Stop();
            stopwatch = null;
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _isEnd = false;

            _maxLogWidth = 0;

            tbFrom.Enabled = false;
            tbHostname.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;

            tbFind.Enabled = false;
            btnStart.Enabled = false;
            btnAddMail.Enabled = false;
            btnDelete.Enabled = false;

            tbMail.Enabled = false;
            menuStrip.Enabled = false;

            mailsNum = mails.Count;

            progressBar.Maximum = mailsNum > int.MaxValue ? int.MaxValue : (int)mailsNum;
            progressBar.Value = 0;
            lblProcessed.Text = "0/" + mailsNum;

            valid = 0;
            invalid = 0;
            disposable = 0;
            processed = 0;

            lblDisposable.Text = disposable.ToString();
            lblInvalid.Text = invalid.ToString();
            lblValid.Text = valid.ToString();
            lblTime.Text = "";

            stopwatch = new Stopwatch();

            var checker = new Checker(mails.ToArray(), this, tbHostname.Text.Trim(), tbFrom.Text.Trim());
            checkerThread = new Thread(new ThreadStart(checker.Check));
            checkerThread.IsBackground = true;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += timer_Tick;

            // start it all
            checkerThread.Start();
            timer.Enabled = true;
            stopwatch.Start();
        }

        private void timer_Tick(object o, EventArgs e)
        {
            var time = stopwatch.Elapsed;
            lblTime.Text = time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
        }

        internal void UpdateLog(int id, string log)
        {
            lvMails.Items[id].SubItems[2].Text = log;
        }

        internal void UpdateProgress(Validity validity, int mailID, string mail, string status)
        {
            if (_isEnd)
                return;

            switch (validity)
            {
                case Validity.Valid:
                    lvMails.Items[mailID].SubItems[1].Text = "YES";
                    lvMails.Items[mailID].BackColor = Color.LawnGreen;
                    valid++;
                    lblValid.Text = valid.ToString();
                    break;

                case Validity.Invalid:
                    lvMails.Items[mailID].SubItems[1].Text = "NO";
                    lvMails.Items[mailID].BackColor = Color.Red;
                    invalid++;
                    lblInvalid.Text = invalid.ToString();
                    break;

                case Validity.Disposable:
                    lvMails.Items[mailID].SubItems[1].Text = "Disposable";
                    lvMails.Items[mailID].BackColor = Color.Pink;
                    disposable++;
                    lblDisposable.Text = disposable.ToString();
                    break;

                case Validity.Unknown:
                    lvMails.Items[mailID].SubItems[1].Text = "?";
                    lvMails.Items[mailID].BackColor = Color.Yellow;
                    break;
            }

            lvMails.Items[mailID].SubItems[2].Text = status;
            if (status.Length * 10 > _maxLogWidth)
            {
                _maxLogWidth = status.Length * 10;
                lvMails.Columns[2].Width = _maxLogWidth;
            }

            if (progressBar.Value < progressBar.Maximum)
                progressBar.Value++;

            processed++;
            lblProcessed.Text = processed + "/" + mailsNum;
        }

        internal void FinishCheck()
        {
            allItemsLv = lvMails.CopyListView();

            lblProcessed.Text = mailsNum + "/" + mailsNum;
            progressBar.Value = progressBar.Maximum;

            btnStop_Click(null, null);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                btnPause.Text = "Pause";
                paused = false;

                stopwatch.Start();
                checkerThread?.Resume();
            }
            else
            {
                btnPause.Text = "Resume";
                paused = true;

                stopwatch.Stop();
                checkerThread?.Suspend();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _isEnd = true;

            progressBar.MarqueeAnimationSpeed = 0;

            btnStop.Enabled = false;
            btnPause.Enabled = false;

            checkerThread?.Abort();

            btnStop.Text = "Stopping...";
            stopwatch.Stop();
            timer.Stop();
            timer.Enabled = false;

            checkerThread?.Join();

            btnStart.Enabled = true;
            btnAddMail.Enabled = true;
            btnDelete.Enabled = true;
            tbMail.Enabled = true;
            menuStrip.Enabled = true;

            btnStop.Text = "Stop";

            if (mails.Count > 0)
            {
                btnExport.Enabled = true;
            }

            tbFind.Enabled = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            lvMailsData = lvMails.Items;

            var export = new Export(this);
            export.Show();
        }

        private void btnAddMail_Click(object sender, EventArgs e)
        {
            if (tbMail.Text.Trim() == string.Empty)
            {
                tbMail.Clear();
                tbMail.Focus();
                return;
            }

            PutMailsToListView(new List<string> { tbMail.Text });

            tbMail.Clear();

            tbMail.Focus();
        }

        private void AddMail(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddMail_Click(null, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvMails.CheckedItems.Count;)
            {
                mails.Remove(lvMails.CheckedItems[i].SubItems[0].Text);

                lvMails.CheckedItems[i].Remove();
            }
        }

        private void AdjustColumnsSizes(object sender, EventArgs e)
        {
            if (lvMails.Width - lvMails.Columns[0].Width - lvMails.Columns[1].Width - 31 <= _maxLogWidth)
            {
                lvMails.Columns[2].Width = _maxLogWidth;
            }
            else
            {
                lvMails.Columns[2].Width = lvMails.Width - lvMails.Columns[0].Width - lvMails.Columns[1].Width - 31;
            }
        }

        private void validToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblFilter.Text = "Valid";
            lvMails.Items.Clear();
            var lvItems = allItemsLv.Items.Cast<ListViewItem>().Where(x => x.SubItems[0].Text == "YES").ToArray().CopyListViewItems();

            lvMails.Items.AddRange(lvItems);
        }

        private void invalidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblFilter.Text = "Invalid";
            lvMails.Items.Clear();
            var lvItems = allItemsLv.Items.Cast<ListViewItem>().Where(x => x.SubItems[0].Text == "NO").ToArray().CopyListViewItems();
        }

        private void disposableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblFilter.Text = "Disposable";
            lvMails.Items.Clear();
            var lvItems = allItemsLv.Items.Cast<ListViewItem>().Where(x => x.SubItems[0].Text == "Disposable").ToArray().CopyListViewItems();

            lvMails.Items.AddRange(lvItems);
        }

        private void clearFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblFilter.Text = "none";
            lvMails.Items.Clear();

            lvMails.Items.AddRange(allItemsLv.Items);
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            lvMails.Items.Clear();
            var lvItems = allItemsLv.Items.Cast<ListViewItem>().Where(x => x.SubItems[0].Text.Contains(tbFind.Text)).ToArray().CopyListViewItems();

            lvMails.Items.AddRange(lvItems);
        }

        private void lvMails_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != lvMails) return;

            if (e.Control && e.KeyCode == Keys.C)
                CopySelectedValuesToClipboard();
        }

        private void CopySelectedValuesToClipboard()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in lvMails.SelectedItems)
            {
                builder.AppendLine(item.SubItems[0].Text);
            }

            Clipboard.SetText(builder.ToString());
        }
    }
}