using System;
using Avalonia.Controls;
using Chess_DB.Controls;
using Avalonia.Interactivity;

namespace Chess_DB.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        PageHost.Content = new HomeMenu();
    }

    private void GoHome(object? sender, RoutedEventArgs e)
    {
        PageHost.Content = new HomeMenu();

    }
    private void GoPlayers(object? sender, RoutedEventArgs e)
    {
        PageHost.Content = new PlayerMenu();
    }
    private void GoTournament(object? sender, RoutedEventArgs e)
    {
        PageHost.Content = new TournamentMenu();
    }
    private void GoRanking(object? sender, RoutedEventArgs e)
    {
        PageHost.Content = new RankingMenu();
    }

}