
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.Services;
using Avalonia.Interactivity;

namespace Chess_DB.Controls
{
    public partial class AddPlayer : UserControl
    {
        public AddPlayer()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


    }
}