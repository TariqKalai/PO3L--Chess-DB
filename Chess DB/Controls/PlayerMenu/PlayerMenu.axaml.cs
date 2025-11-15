
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Chess_DB.Controls
{
    public partial class PlayerMenu : UserControl
    {
        public PlayerMenu()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}