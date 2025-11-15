
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Chess_DB.Controls
{
    public partial class RankingMenu : UserControl
    {
        public RankingMenu()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}