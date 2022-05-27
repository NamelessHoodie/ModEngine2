using SteamWebAPI2.Interfaces;
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
        public GameTypeUtils.GameType Type { get; set; }
        public string executableDirectoryPath { get; set; }
        public string ExecutableName
        {
            get
            {
                return GameTypeUtils.gameTypeUtils.GetExecutableNameByGameType(Type);
            }
        }

        public string ExecutablePath { get; }

        public GameViewModel(GameTypeUtils.GameType type, string executableDirectoryPath)
        {
            Name = GameTypeUtils.gameTypeUtils.GetStringGameName(type);
            ExecutablePath = System.IO.Path.Combine(this.executableDirectoryPath, ExecutableName);
            Type = type;
            this.executableDirectoryPath = executableDirectoryPath;
        }
    }
}

