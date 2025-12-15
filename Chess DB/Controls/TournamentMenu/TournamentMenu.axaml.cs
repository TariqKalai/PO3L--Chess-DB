using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Chess_DB.Services;

namespace Chess_DB.Controls;

public partial class TournamentMenu : UserControl
{
    public TournamentMenu()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void GoNewTournament(object? sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new NewTournament());
    }

    private void GoEditTournament(object? sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new EditTournament());
    }

}