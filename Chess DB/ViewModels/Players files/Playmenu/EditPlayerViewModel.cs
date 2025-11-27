
using Chess_DB.Services;

using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Chess_DB.ViewModels;


public partial class EditPlayerViewModel : ViewModelBase
{
    // Just loadiing player in a variable to use it later in axaml
    public ObservableCollection<Player> List_player => AppServices.PlayerService.Players;

    [ObservableProperty]
    //Make it so it is grayed out if nothing is sleected
    [NotifyCanExecuteChangedFor(nameof(DeletePlayerCommand))]
    [NotifyCanExecuteChangedFor(nameof(ModifyPlayerCommand))]
    private Player? _selectedPlayer;
    public EditPlayerViewModel()
    {
    }



    //READ bellow what happens
    [RelayCommand(CanExecute = nameof(CanAlterPlayer))]
    public void ModifyPlayer()
    {
        if (SelectedPlayer is null) return;

        Console.WriteLine($"Name: {SelectedPlayer.FirstName}");
        Console.WriteLine($"Elo: {SelectedPlayer.Elo}");
        Console.WriteLine($"ID: {SelectedPlayer.Player_id}");
        Console.WriteLine($"Mail: {SelectedPlayer.Mail}");


    }


    //READ bellow what happens
    [RelayCommand(CanExecute = nameof(CanAlterPlayer))]
    public void DeletePlayer()
    {

        Console.WriteLine($"Removed player '{SelectedPlayer.FirstName}'");
        List_player.Remove(SelectedPlayer);
        //need to save of course
        AppServices.PlayerService.Save();


    }


    // Methode created to Allow alteration only if SelectedPlayer is not null, or it ll crash
    private bool CanAlterPlayer()
    {
        return SelectedPlayer != null;
    }

}