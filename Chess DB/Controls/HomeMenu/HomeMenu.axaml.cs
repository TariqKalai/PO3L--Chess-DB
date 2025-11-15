
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Chess_DB.Controls
{
    public partial class HomeMenu : UserControl
    {
        public HomeMenu()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}