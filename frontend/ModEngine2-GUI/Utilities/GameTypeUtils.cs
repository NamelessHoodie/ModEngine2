using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamWebAPI2.Interfaces;

namespace ModEngine2_GUI.Utilities
{
    public class GameTypeUtils
    {

        public static GameTypeUtils gameTypeUtils = new GameTypeUtils();

        public enum GameType
        {
            DarkSoulsPTDE,
            DarkSoulsRemastered,
            DarkSoulsII,
            DarkSoulsIISOTFS,
            DarkSoulsIII,
            Sekiro,
            EldenRing
        }

        private GameTypeUtils()
        { 
        }

        public string GetStringGameName(GameType type)
        {
            if (gameTypeToGameStringName.TryGetValue(type, out var name))
                return name;
            throw new Exception("Unimplemented GameType");
        }

        public AppId GetAppIdByGameType(GameType type)
        {
            if (gameTypeToAppId.TryGetValue(type, out var appId))
                return appId;
            throw new Exception("Unimplemented GameType");
        }

        public string GetExecutableNameByGameType(GameType type)
        {
            if (gameTypeToGameStringName.TryGetValue(type, out var exeName))
                return exeName;
            throw new Exception("Unimplemented GameType");
        }

        private static Dictionary<GameType, AppId> gameTypeToAppId =
        new Dictionary<GameType, AppId>
        {
            { GameType.DarkSoulsPTDE ,(AppId)211420},
            { GameType.DarkSoulsRemastered ,(AppId)570940},
            { GameType.DarkSoulsII ,(AppId)236430},
            { GameType.DarkSoulsIISOTFS ,(AppId)335300},
            { GameType.DarkSoulsIII ,(AppId)374320},
            { GameType.Sekiro ,(AppId)814380},
            { GameType.EldenRing ,(AppId)1245620}
        };

        private static Dictionary<GameType, string> gameTypeToGameStringName =
        new Dictionary<GameType, string>
        {
            { GameType.DarkSoulsPTDE, "Dark Souls - PTDE"},
            { GameType.DarkSoulsRemastered,"Dark Souls - Remastered"},
            { GameType.DarkSoulsII ,"Dark Souls II"},
            { GameType.DarkSoulsIISOTFS ,"Dark Souls II - SOTFS"},
            { GameType.DarkSoulsIII ,"Dark Souls III"},
            { GameType.Sekiro, "Sekiro - Shadows Die Twice"},
            { GameType.EldenRing, "Elden Ring"}
        };

        private static Dictionary<GameType, string> gameTypeToExecutableName =
        new Dictionary<GameType, string>
        {
            { GameType.DarkSoulsPTDE, "DARKSOULS.exe"},
            { GameType.DarkSoulsRemastered,"DarkSoulsRemastered.exe"},
            { GameType.DarkSoulsII ,"DarkSoulsII.exe"},
            { GameType.DarkSoulsIISOTFS ,"DarkSoulsII.exe"},
            { GameType.DarkSoulsIII ,"DarkSoulsIII.exe"},
            { GameType.Sekiro, "Sekiro.exe"},
            { GameType.EldenRing, "eldenring.exe"}
        };
    }
}
