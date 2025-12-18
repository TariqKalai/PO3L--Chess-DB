using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.ViewModels;

namespace Chess_DB.Home_actions
{
    public partial class Stats : UserControl
    {
        public Stats()
        {
            InitializeComponent();
            DataContext = new StatsViewModel();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}