using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountantKit
{
    static class WindowHelper
    {
        private static List<Window> oldWindowList = new List<Window>();

        public static void ShowNewWindow(Window oldWindow, Window newWindow)
        {
            oldWindow.Hide();
            oldWindowList.Add(oldWindow);
            newWindow.Show();
        }

        public static void BackToOldWindow(Window currentWindow)
        {
            currentWindow.Close();
            if(oldWindowList.Count > 0)
            {
                oldWindowList.ElementAt(oldWindowList.Count - 1).Show();
                oldWindowList.RemoveAt(oldWindowList.Count - 1);
            }
        }
    }
}
