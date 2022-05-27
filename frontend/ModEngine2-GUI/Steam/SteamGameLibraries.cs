using System;
using System.Collections.Generic;
using System.IO;
using ModEngine2_GUI.Utilities;

namespace ModEngine2_GUI.Steam
{
    public class SteamGameLibraries
    {
        public List<SteamLibrary> Libraries;

        public SteamGameLibraries()
        {
            string steamConfigVdfAbsolutePath = SteamUtils.GetMainLibraryFolderVdf();
            var steamLibrariesRootDynamic = SteamUtils.DeserializeVdf_Acf(steamConfigVdfAbsolutePath);
            Libraries = FillListSteamLibraryFromDynamic(steamLibrariesRootDynamic);
        }

        private static List<SteamLibrary> FillListSteamLibraryFromDynamic(dynamic steamLibrariesRoot)
        {
            List<SteamLibrary> steamLibraries = new List<SteamLibrary>();
            IDictionary<string, dynamic> librariesRootIdict = steamLibrariesRoot;
            IDictionary<string, dynamic> librariesIdict = librariesRootIdict["libraryfolders"];
            foreach (var (libraryIndex, libraryDynamic) in librariesIdict)
            {
                steamLibraries.Add(new SteamLibrary(libraryDynamic));
            }
            return steamLibraries;
        }

        public class SteamLibrary
        {
            public List<SteamGame> Apps { get;}
            public string ContentId { get;}
            public string Label { get;}
            public string LibraryPath { get;}
            public string TimeLastUpdateCorruption { get;}
            public string TotalSize { get;}
            public string UpdateCleanBytesTally { get; }
            public SteamLibrary(dynamic steamLibraryDynamic)
            {
                IDictionary<string, dynamic> steamLibraryIdict = steamLibraryDynamic;
                LibraryPath = System.IO.Path.GetFullPath(steamLibraryIdict["path"]);
                foreach (var (key, dynamic) in steamLibraryIdict)
                {
                    switch (key)
                    {
                        case "path":
                            break;
                        case "apps":
                            Apps = SteamGamesListFromDynamic(dynamic);
                            break;
                        case "contentid":
                            ContentId = dynamic;
                            break;
                        case "label":
                            Label = dynamic;
                            break;
                        case "time_last_update_corruption":
                            TimeLastUpdateCorruption = dynamic;
                            break;
                        case "totalsize":
                            TotalSize = dynamic;
                            break;
                        case "update_clean_bytes_tally":
                            UpdateCleanBytesTally = dynamic;
                            break;
                        default:
                            new ExceptionUtils.SteamFieldUnimplementedException(nameof(SteamLibrary), key, dynamic);
                            break;
                    }
                }
            }
            private List<SteamGame> SteamGamesListFromDynamic(dynamic steamGamesDynamic)
            {
                List<SteamGame> gameList = new List<SteamGame>();
                IDictionary<string, dynamic> steamGamesIdict = steamGamesDynamic;
                foreach (var (key, dynamic) in steamGamesIdict)
                {
                    string manifestPath = Path.Combine(SteamUtils.GetLibrarySteamAppsDirectoryPath(LibraryPath), 
                                                       SteamUtils.AppManifestNameFromAppId(key));
                    var appManifest = new AppManifest(manifestPath);
                    var steamGameDirectory = Path.Combine(SteamUtils.GetLibrarySteamCommonDirectoryPath(LibraryPath), appManifest.InstallDir);
                    gameList.Add(new SteamGame(key, dynamic, steamGameDirectory, appManifest));
                }
                return gameList;
            }
        }

        public class SteamGame
        {
            public string AppId { get; }
            public string PathAppDirectory { get; }
            public AppManifest Manifest { get; }
            public string Unk1 { get; }
            public SteamGame(string appId, string contentId, string pathAppDirectory, AppManifest manifest)
            {
                AppId = appId;
                Unk1 = contentId;
                PathAppDirectory = pathAppDirectory;
                Manifest = manifest;
            }
        }
    }

}
