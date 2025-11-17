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
    public ObservableCollection<Player> Players { get; set; } = new ObservableCollection<Player>();


    private readonly FileService _fileService;

    public MainWindowViewModel()
    {

        _fileService = new FileService();

        var loadedPlayers = _fileService.Jsonload();
        Players = new ObservableCollection<Player>(loadedPlayers);

    }


}
