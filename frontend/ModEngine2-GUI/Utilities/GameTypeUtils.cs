using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;

namespace ModEngine2_GUI.Utilities
{
    public enum GameTypeAppId : uint
    {
        DarkSoulsPTDE = 211420,
        DarkSoulsRemastered = 570940,
        DarkSoulsII = 236430,
        DarkSoulsIISOTFS = 335300,
        DarkSoulsIII = 374320,
        Sekiro = 814380,
        EldenRing = 1245620
    }

    public static class GameTypeUtils
    {
        public class GameTypeDataContainer
        {

            public static GameTypeDataContainer gameTypeUtils = new GameTypeDataContainer();

            private GameTypeDataContainer()
            {
            }

            public string GetStringGameName(GameTypeAppId type)
            {
                if (gameTypeToGameStringName.TryGetValue(type, out var name))
                    return name;
                throw new Exception("Unimplemented GameType");
            }

            public string GetExecutableNameByGameType(GameTypeAppId type)
            {
                if (gameTypeToGameStringName.TryGetValue(type, out var exeName))
                    return exeName;
                throw new Exception("Unimplemented GameType");
            }


            private Dictionary<GameTypeAppId, string> gameTypeToGameStringName =
            new Dictionary<GameTypeAppId, string>
            {
            { GameTypeAppId.DarkSoulsPTDE, "Dark Souls - PTDE"},
            { GameTypeAppId.DarkSoulsRemastered,"Dark Souls - Remastered"},
            { GameTypeAppId.DarkSoulsII ,"Dark Souls II"},
            { GameTypeAppId.DarkSoulsIISOTFS ,"Dark Souls II - SOTFS"},
            { GameTypeAppId.DarkSoulsIII ,"Dark Souls III"},
            { GameTypeAppId.Sekiro, "Sekiro - Shadows Die Twice"},
            { GameTypeAppId.EldenRing, "Elden Ring"}
            };

            private Dictionary<GameTypeAppId, string> gameTypeToExecutableName =
            new Dictionary<GameTypeAppId, string>
            {
            { GameTypeAppId.DarkSoulsPTDE, "DARKSOULS.exe"},
            { GameTypeAppId.DarkSoulsRemastered,"DarkSoulsRemastered.exe"},
            { GameTypeAppId.DarkSoulsII ,"DarkSoulsII.exe"},
            { GameTypeAppId.DarkSoulsIISOTFS ,"DarkSoulsII.exe"},
            { GameTypeAppId.DarkSoulsIII ,"DarkSoulsIII.exe"},
            { GameTypeAppId.Sekiro, "Sekiro.exe"},
            { GameTypeAppId.EldenRing, "eldenring.exe"}
            };
        }

        public static string GetFancyNameUI(this GameTypeAppId type)
        {
            return GameTypeDataContainer.gameTypeUtils.GetStringGameName(type);
        }

        public static uint GetAppId(this GameTypeAppId type)
        {
            return (uint)type;
        }

        public static string GetExecutableName(this GameTypeAppId type)
        {
            return GameTypeDataContainer.gameTypeUtils.GetExecutableNameByGameType(type);
        }

        public static bool TryGetGameLocation(this GameTypeAppId type, out string gameDirectoryPath)
        {
            if (type.IsSteamGameInstalled())
            {
                gameDirectoryPath = System.IO.Path.Combine(SteamApps.AppInstallDir(type.GetAppId()), "Game");
                return true;
            }
            gameDirectoryPath = null;
            return false;
        }

        public static bool IsSteamGameInstalled(this GameTypeAppId type)
        {
            if(SteamClient.IsValid)
             return SteamApps.IsAppInstalled(type.GetAppId());
            throw new Exception("Steam Client is not valid");
        }


    }
}
