namespace Chess_DB.ViewModels;

using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;
using System.IO;


public partial class MainWindowViewModel : ViewModelBase
{
    public PlayerService PlayerService { get; }

    public ObservableCollection<Player> Players => PlayerService.Players;


    public MainWindowViewModel(PlayerService playerService)
    {

        PlayerService = playerService;

    }


}
