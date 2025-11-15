
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.Services;
using Avalonia.Interactivity;

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

        private void GoHome1(object? sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomeMenu());
        }

    }
}