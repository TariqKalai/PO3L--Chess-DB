
using Chess_DB.Services;

using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Chess_DB.Controls;


namespace Chess_DB.ViewModels;


public partial class EditPlayerViewModel : ViewModelBase
{


    // Creating New observable attributes so  that ater on we can put them inside the selected player
    [ObservableProperty] private string _new_FirstName;
    [ObservableProperty] private string _new_LastName;
    [ObservableProperty] private int _new_Elo;
    [ObservableProperty] private string _new_DateOfBirth;
    [ObservableProperty] private string _new_Phone;
    [ObservableProperty] private string _new_Email;



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

        New_FirstName = SelectedPlayer.FirstName;
        New_LastName = SelectedPlayer.LastName;
        New_Elo = SelectedPlayer.Elo;
        New_DateOfBirth = SelectedPlayer.DateOfBirth;
        New_Phone = SelectedPlayer.Phone;
        New_Email = SelectedPlayer.Mail;

        //this to give current datacontext all variables;...
        NavigationService.Navigate(new EditPlayerPage(this));
    }

    [RelayCommand] //Maybe add condition to grey out button
    public void Submit()
    {

        //simple enough just changing the vars
        SelectedPlayer.FirstName = New_FirstName;
        SelectedPlayer.LastName = New_LastName;
        SelectedPlayer.Elo = New_Elo;
        SelectedPlayer.DateOfBirth = New_DateOfBirth;
        SelectedPlayer.Phone = New_Phone;
        SelectedPlayer.Mail = New_Email;


        Console.WriteLine($"'NEW FirstName : {SelectedPlayer.FirstName}'",
                          $"'NEW LastName : {SelectedPlayer.LastName}'",
                          $"'NEW Elo : {SelectedPlayer.Elo}'",
                          $"'NEW DateOfBirth : {SelectedPlayer.DateOfBirth}'",
                          $"'NEW Phone : {SelectedPlayer.Phone}'",
                          $"'NEW Email : {SelectedPlayer.Mail}'");


        AppServices.PlayerService.Save();
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


    // Methode created to Allow alteration only if all attributes are  not null, or it 'll initialize something wrong
    private bool CanAlterPlayer()
    {
        return SelectedPlayer != null;
    }


}