using System.Reflection;
using System.Windows.Forms;

namespace MailChecker
{
    public static class Extensions
    {
        public static ListViewItem[] CopyListViewItems(this ListViewItem[] list)
        {
            var result = new ListViewItem[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                result[i] = (ListViewItem)list[i].Clone();
            }

            return result;
        }

        public static ListView CopyListView(this ListView source)
        {
            ListView destination = new ListView();
            foreach (ListViewItem item in source.Items)
            {
                destination.Items.Add((ListViewItem)item.Clone());
            }

            return destination;
        }

        public static void DoubleBuffered(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }
}