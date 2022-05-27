using System;
using System.Collections.Generic;
using System.IO;

namespace ModEngine2_GUI.Steam
{
    public class AppManifest
    {
        public string AppId { get; }
        public string Universe { get; }
        public string LauncherPath { get; }
        public string Name { get; }
        public string StateFlags { get; }
        public string InstallDir { get; }
        public string LastUpdated { get; }
        public string SizeOnDisk { get; }
        public string StagingSize { get; }
        public string BuildId { get; }
        public string LastOwner { get; }
        public string UpdateResult { get; }
        public string BytesToDownload { get; }
        public string BytesDownloaded { get; }
        public string BytesToStage { get; }
        public string BytesStaged { get; }
        public string TargetBuildId { get; }
        public string AutoUpdateBehavior { get; }
        public string AllowOtherDownloadsWhileRunning { get; }
        public string ScheduledAutoUpdate { get; }
        public Dictionary<string, Depot> InstalledDepots => new Dictionary<string, Depot>();
        public Dictionary<string, string> InstallScripts => new Dictionary<string, string>();
        public Dictionary<string, string> SharedDepots => new Dictionary<string, string>();
        public UserConfigType UserConfig { get; }
        public MountedConfigType MountedConfig { get; }
        public AppManifest(string manifestPath)
        {
            IDictionary<string, dynamic> appManifestRootIdict = SteamUtils.DeserializeVdf_Acf(manifestPath);
            IDictionary<string, dynamic> appStateIdict = appManifestRootIdict["AppState"];
            foreach (var (key, value) in appStateIdict)
            {
                switch (key)
                {
                    case "appid":
                        AppId = value;
                        break;
                    case "Universe":
                        Universe = value;
                        break;
                    case "LauncherPath":
                        LauncherPath = Path.GetFullPath(value);
                        break;
                    case "name":
                        Name = value;
                        break;
                    case "StateFlags":
                        StateFlags = value;
                        break;
                    case "installdir":
                        InstallDir = value;
                        break;
                    case "LastUpdated":
                        LastUpdated = value;
                        break;
                    case "SizeOnDisk":
                        SizeOnDisk = value;
                        break;
                    case "StagingSize":
                        StagingSize = value;
                        break;
                    case "buildid":
                        BuildId = value;
                        break;
                    case "LastOwner":
                        LastOwner = value;
                        break;
                    case "UpdateResult":
                        UpdateResult = value;
                        break;
                    case "BytesToDownload":
                        BytesToDownload = value;
                        break;
                    case "BytesDownloaded":
                        BytesDownloaded = value;
                        break;
                    case "BytesToStage":
                        BytesToStage = value;
                        break;
                    case "BytesStaged":
                        BytesStaged = value;
                        break;
                    case "TargetBuildID":
                        TargetBuildId = value;
                        break;
                    case "AutoUpdateBehavior":
                        AutoUpdateBehavior = value;
                        break;
                    case "AllowOtherDownloadsWhileRunning":
                        AllowOtherDownloadsWhileRunning = value;
                        break;
                    case "ScheduledAutoUpdate":
                        ScheduledAutoUpdate = value;
                        break;
                    case "InstalledDepots":
                        FillInstalledDepotsDictionary(value);
                        break;
                    case "InstallScripts":
                        FillInstallScriptsDictionary(value);
                        break;
                    case "SharedDepots":
                        FillSharedDepotsDictionary(value);
                        break;
                    case "UserConfig":
                        UserConfig = new UserConfigType(value);
                        break;
                    case "MountedConfig":
                        MountedConfig = new MountedConfigType(value);
                        break;
                    default:
                        throw new Exception("NOT IMPLEMENTED");
                }
            }
        }

        public void FillInstalledDepotsDictionary(dynamic installedDepotsDynamic)
        {
            IDictionary<string, dynamic> installedDepotsIDictionary = installedDepotsDynamic;
            foreach (var (key, depotDynamic) in installedDepotsIDictionary)
            {
                InstalledDepots.Add(key, new Depot(depotDynamic));
            }
        }

        public void FillInstallScriptsDictionary(dynamic installScriptsDynamic)
        {
            IDictionary<string, dynamic> installScriptIdict = installScriptsDynamic;
            foreach (var (installScriptId, installScriptPath) in installScriptIdict)
            {
                InstallScripts.Add(installScriptId, installScriptPath);
            }
        }

        public void FillSharedDepotsDictionary(dynamic sharedDepotsDynamic)
        {
            IDictionary<string, dynamic> sharedDepotsIDictionary = sharedDepotsDynamic;
            foreach (var (sharedDepotDynamic0, sharedDepotDynamic1) in sharedDepotsIDictionary)
            {
                SharedDepots.Add(sharedDepotDynamic0, sharedDepotDynamic1);
            }
        }

        public class Depot
        {
            public string Manifest = "";
            public string Size = "";
            public string DlcAppId = "";
            public Depot(dynamic depotDynamic)
            {
                IDictionary<string, dynamic> depotIDict = depotDynamic;
                foreach (var (propertyName, propertyValue) in depotIDict)
                {
                    switch (propertyName)
                    {
                        case "manifest":
                            Manifest = propertyValue;
                            break;
                        case "size":
                            Size = propertyValue;
                            break;
                        case "dlcappid":
                            DlcAppId = propertyValue;
                            break;
                        default:
                            throw new Exception("NOT IMPLEMENTED");
                    }
                }
            }
        }
        public class UserConfigType
        {
            public string Language = "";
            public string BetaKey = "";
            public UserConfigType(dynamic userConfigDynamic)
            {
                IDictionary<string, dynamic> userConfigIDict = userConfigDynamic;
                foreach (var (configName, configValue) in userConfigIDict)
                {
                    switch (configName)
                    {
                        case "language":
                            Language = configValue;
                            break;
                        case "betakey":
                            BetaKey = configValue;
                            break;
                        default:
                            throw new Exception("NOT IMPLEMENTED");
                            break;
                    }
                }
            }
        }

        public class MountedConfigType
        {
            public string Language = "";
            public string BetaKey = "";
            public MountedConfigType(dynamic mountedConfigDynamic)
            {
                IDictionary<string, dynamic> mountedConfigIDict = mountedConfigDynamic;
                foreach (var (configName, configValue) in mountedConfigIDict)
                {
                    switch (configName)
                    {
                        case "language":
                            Language = configValue;
                            break;
                        case "betakey":
                            BetaKey = configValue;
                            break;
                        default:
                            throw new Exception("NOT IMPLEMENTED");
                            break;
                    }
                }
            }
        }
    }
}
