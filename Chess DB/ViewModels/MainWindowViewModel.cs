namespace Chess_DB.ViewModels;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;


public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Player> Players { get; } = new ObservableCollection<Player>();

    [ObservableProperty]
    // This attribute tells the MVVM Toolkit to re-run CanAddPlayer() 
    // every time the value of _newPlayerName changes.
    [NotifyCanExecuteChangedFor(nameof(AddPlayerCommand))]
    private string? _newPlayerName;

    [RelayCommand(CanExecute = nameof(CanAddPlayer))]
    private void AddPlayer()
    {
        // Add a new item to the list
        Players.Add(new Player()
        {
            First_name = NewPlayerName,
            Last_name = NewPlayerName,
            DateOfBirth = NewPlayerName
        });
        // reset the NewItemContent
        NewPlayerName = null;
    }
    private bool CanAddPlayer() => !string.IsNullOrWhiteSpace(NewPlayerName);


    


}
