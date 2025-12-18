using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Chess_DB.Controls;
using Chess_DB.Services;

namespace Chess_DB.Home_actions
{
    public partial class QuickActions : UserControl
    {
        public QuickActions()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void GoAddPlayer(object? sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPlayer());
        }
        private void GoRegisterPlayer(object? sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageRegistration());
        }
        private void GoNewTournament(object? sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewTournament());
        }
    }
}