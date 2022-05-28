using Avalonia.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ModEngine2_GUI.Steam;
using System.IO;

namespace ModEngine2_GUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //private static string _registrySoulsModsFullPath = @"SOFTWARE\soulsmods";
        //private static string _registryModEngine2PathName = @"ModEngine2";
        //private static string _registryModEngine2FullPath = System.IO.Path.Combine(_registrySoulsModsFullPath, _registryModEngine2PathName);
        //private static string _registryGamesPathName = @"Games";
        //private static string _registryGamesFullPath = System.IO.Path.Combine(_registryModEngine2FullPath, _registryGamesPathName);

        public ObservableCollection<TabItem> GameTabs { get; }
        public string Greeting => "Welcome to Avalonia!";

        public MainWindowViewModel()
        {
            GameTabs = new ObservableCollection<TabItem>();

            //help();
            help2();
            
            //new System.Threading.Tasks.Task(() => { Thread.Sleep(5000); help(); });
        }

        private void help2()
        {
            try
            {
                var steamInstalledLibrary = new SteamGameLibraries();
            }
            catch (System.Exception e)
            {
                new ModEngine2_GUI.Utilities.ExceptionUtils.ExceptionWindow("HELP I DONT EVEN KNOW!", e.Message, e.Source);
            }

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(steamInstalledLibrary, Newtonsoft.Json.Formatting.Indented);
            //Debug.WriteLine(json);
        }
        public void help()
        {
            for (int i = 0; i < 5; i++)
            {
                GameTabs.Add(new TabItem() { Header = $"meme{i}", Content = $"ContentMeme{i}" });
            }
            Debug.WriteLine("daThing");
        }
    }
}
