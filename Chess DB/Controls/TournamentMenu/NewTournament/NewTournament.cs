
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.Services;
using Avalonia.Interactivity;

namespace Chess_DB.Controls
{
    public partial class NewTournament : UserControl
    {
        public NewTournament()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


    }
}