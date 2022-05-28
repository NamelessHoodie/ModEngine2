using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModEngine2_GUI.Utilities;

namespace ModEngine2_GUI.ViewModels
{

    public class GameViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public GameTypeAppId Type { get; set; }
        public string executableDirectoryPath { get; set; }
        public string ExecutableName
        {
            get
            {
                return Type.GetExecutableName();
            }
        }

        public string ExecutablePath { get; }

        public GameViewModel(GameTypeAppId type, string executableDirectoryPath)
        {
            Name = type.GetFancyNameUI();
            ExecutablePath = System.IO.Path.Combine(this.executableDirectoryPath, ExecutableName);
            Type = type;
            this.executableDirectoryPath = executableDirectoryPath;
        }
    }
}

