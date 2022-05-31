using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModEngine2_GUI.Utilities;
using ModEngine2_GUI.ViewModels;

namespace ModEngine2_GUI.Models
{

    public class GameModel
    {
        public GameTypeAppId Type { get; }
        public string Name { get; }
        public string ExecutableDirectoryPath { get; }
        public string ExecutablePath { get; }

        public GameModel(GameTypeAppId type)
        {
            Type = type;
            Name = Type.GetFancyNameUI();
            ExecutableDirectoryPath = Type.GetGameExecutableDirectoryPath();
            ExecutablePath = Type.GetGameExecutablePath();
        }
    }
}

