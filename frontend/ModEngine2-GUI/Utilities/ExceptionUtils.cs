using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModEngine2_GUI.Utilities
{
    public class ExceptionUtils
    {
        public class SteamFieldUnimplementedException
        {

            public SteamFieldUnimplementedException(string sourceName, string key, object value)
            {
                if (key == null)
                    key = "NoKey";
                if (value == null)
                    value = "NoVal";
                System.Windows.Forms.MessageBox.Show($"Missing field: {key}, Value of missing field: {value.ToString()}\nPlease let me know personally or post an issue on the github Page.", $"Unimplemented Steam Library Field in : {sourceName}");
            }
        }

        public class ExceptionWindow
        {
            public ExceptionWindow(string exceptionTitle, string source, string message)
            {
                System.Windows.Forms.MessageBox.Show($"{message}\nat:\n\n{source}", exceptionTitle);
            }
        }
    }
}
