using System;
using Avalonia.Controls;
using Chess_DB.Controls;
using Avalonia.Interactivity;
using Chess_DB.Services;

namespace Chess_DB.Views;

public partial class MainWindow : Window
{
    // component inizialization + bind navigation to the pagehost how axaml so that
    //  we can change slides even in different Files folders, like in PlayerMenu.axaml.cs
    // 
    public MainWindow()
    {
        InitializeComponent();

        NavigationService.PageHost = PageHost;

        // INitial page is HomeMenu
        PageHost.Content = new HomeMenu();
    }


    // Button links for tabs
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