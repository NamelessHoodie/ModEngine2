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

            public SteamFieldUnimplementedException(string sourceName, string key, string value)
            {
                System.Windows.Forms.MessageBox.Show($"Missing field: {key}, Value of missing field: {value}\nPlease let me know personally or post an issue on the github Page.", $"Unimplemented Steam Library Field in : {sourceName}");
            }
        }
    }
}
