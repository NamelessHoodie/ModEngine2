using Avalonia.Controls;
using ModEngine2_GUI.ViewModels;

namespace ModEngine2_GUI.Views
{
    public partial class MainWindow : Window
    {
        
        MainWindowViewModel ViewModel {get { return this.DataContext as MainWindowViewModel; } }

        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("hitton").Click += (o,e) => { ViewModel.help(); };
        }
    }
}
