using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ModEngine2_GUI.Views
{
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
