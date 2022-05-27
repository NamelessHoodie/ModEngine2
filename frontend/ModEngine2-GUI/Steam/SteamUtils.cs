using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VdfParser;

namespace ModEngine2_GUI.Steam
{
    public class SteamUtils
    {
        public static dynamic DeserializeVdf_Acf(string steamConfigVdfAbsolutePath)
        {
            VdfDeserializer vdfDeserializer = new VdfDeserializer();
            using (FileStream testFile = File.OpenRead(steamConfigVdfAbsolutePath))
            {
                dynamic result = vdfDeserializer.Deserialize(testFile);
                return result;
            }
        }

        public static string GetLibraryFolderVdf(string libraryPath)
        {
            string libraryFolderVdfRelativePath = @"libraryfolders.vdf";
            string libraryConfigVdfAbsolutePath = Path.Combine(GetLibrarySteamAppsDirectoryPath(libraryPath),
                                                        libraryFolderVdfRelativePath);
            return libraryConfigVdfAbsolutePath;
        }

        public static string GetLibrarySteamCommonDirectoryPath(string libraryPath)
        {
            return Path.Combine(GetLibrarySteamAppsDirectoryPath(libraryPath), "common");
        }

        public static string GetLibrarySteamAppsDirectoryPath(string libraryPath)
        {
            return Path.Combine(libraryPath, "steamapps");
        }

        public static string GetMainLibraryFolderVdf()
        {
            return GetLibraryFolderVdf(GetSteamDirectoryPath());
        }

        public static string GetMainSteamAppsDirectoryPath()
        {
            return GetLibrarySteamAppsDirectoryPath(GetSteamDirectoryPath());
        }

        public static string GetMainSteamCommonDirectoryPath()
        {
            return GetLibrarySteamCommonDirectoryPath(GetSteamDirectoryPath());
        }

        public static string AppManifestNameFromAppId(string steamAppId)
        {
            return $"appmanifest_{steamAppId}.acf";
        }

        public static string GetSteamDirectoryPath()
        {
            string steamRegistryPath = @"Software\Valve\Steam";
            string steamDirectoryPathKey = @"SteamPath";
            using (Microsoft.Win32.RegistryKey key = Registry.CurrentUser.OpenSubKey(steamRegistryPath))
            {
                var steamDirectoryPath = key.GetValue(steamDirectoryPathKey).ToString();
                return Path.GetFullPath(steamDirectoryPath);
            }
        }
    }
}
