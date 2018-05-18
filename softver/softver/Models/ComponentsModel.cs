
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softver.Models
{
    public static class ComponentsModel
    {


        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        //public static void WindowsState(Form form)
        //{

        //    if (form.WindowState == FormWindowState.Normal)
        //        form.WindowState = FormWindowState.Maximized;
        //    else
        //        form.WindowState = FormWindowState.Normal;

        //}

        public static void Remove_Special_Characters(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            String key = e.KeyChar.ToString();
            if (regex.IsMatch(key) && key != "\b")
            {
                e.Handled = true;
            }

        }



    }
}
