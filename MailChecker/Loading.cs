using System;
using System.Drawing;
using System.Windows.Forms;

namespace MailChecker
{
    public partial class Loading : Form
    {
        private MailChecker _mailChecker;

        public Loading(MailChecker mailChecker, int size)
        {
            _mailChecker = mailChecker;

            var x = _mailChecker.Location.X + (_mailChecker.Width - Width) / 2;
            var y = _mailChecker.Location.Y + (_mailChecker.Height - Height) / 2;
            Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

            InitializeComponent();

            progressBarLoad.Maximum = size;
        }

        internal void ProgressUpdate(int length)
        {
            if (progressBarLoad.Value < progressBarLoad.Maximum)
                progressBarLoad.Value++;
        }
    }
}