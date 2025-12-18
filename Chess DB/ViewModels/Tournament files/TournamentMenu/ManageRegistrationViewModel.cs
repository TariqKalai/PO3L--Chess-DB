
using Chess_DB.Services;

using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Chess_DB.Controls;

// TO use the excpet for remaining player list
using System.Linq;
using Avalonia.Rendering.Composition;


namespace Chess_DB.ViewModels;


public partial class ManageRegistrationViewModel : ViewModelBase
{


    // Creating New observable attributes so  that ater on we can put them inside the selected tournament
    [ObservableProperty] private string? _new_TournamentName;
    [ObservableProperty] private int _new_MaxNumberPlayer;
    [ObservableProperty] private string _new_CompetitionType;



    [ObservableProperty]
    private ObservableCollection<Player> _remaining_players = new();

    [ObservableProperty]
    private ObservableCollection<Player> _list_player = new();

    [ObservableProperty]
    //Make it so it is grayed out if nothing is sleected
    [NotifyCanExecuteChangedFor(nameof(DeletePlayerCommand))]
    private Player? _selectedPlayer;

    [RelayCommand(CanExecute = nameof(CanDeletePlayer))]

    public void DeletePlayer()
    {

        Console.WriteLine($"Removed player '{SelectedPlayer!.FirstName}'");
        List_player.Remove(SelectedPlayer);
        //need to save of course
        AppServices.TournamentService.ModifyRegistration(SelectedTournament!, List_player);
        AddPlayersCommand.NotifyCanExecuteChanged();


    }

    [RelayCommand(CanExecute = nameof(CanAddPlayers))]
    public void AddPlayers()
    {
        Remaining_players = new ObservableCollection<Player>(
        AppServices.PlayerService.Players.Except(List_player));


        NavigationService.Navigate(new ChoosePlayers(this));
    }



    // Just loadiing player in a variable to use it later in axaml
    public ObservableCollection<ChessTournament> List_tournament => AppServices.TournamentService.TournamentsList;

    [ObservableProperty]
    //Make it so it is grayed out if nothing is selected
    [NotifyCanExecuteChangedFor(nameof(SelectTournamentCommand))]
    [NotifyCanExecuteChangedFor(nameof(AddPlayersCommand))]
    private ChessTournament? _selectedTournament;


    [ObservableProperty]
    //Make it so it is grayed out if nothing is selected
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private Player? _selectedPlayers;
    public ManageRegistrationViewModel()
    {


    }



    //READ bellow what happens
    [RelayCommand(CanExecute = nameof(CanAlterTournament))]
    public void SelectTournament()
    {
        //this to give current datacontext all variables;...
        this.List_player = AppServices.TournamentService.LoadRegistration(SelectedTournament!);
        NavigationService.Navigate(new ManageRegistrationPage(this));
    }

    [RelayCommand(CanExecute = nameof(CanSubmitPlayers))]
    public void Submit()
    {
        List_player.Add(SelectedPlayers);

        AppServices.TournamentService.ModifyRegistration(SelectedTournament!, List_player!);

        NavigationService.Navigate(new ManageRegistrationPage(this));
    }




    // Methode created to Allow alteration only if all attributes are  not null, or it 'll initialize something wrong
    private bool CanAlterTournament()
    {
        return SelectedTournament != null;
    }
    private bool CanDeletePlayer()
    {
        return SelectedPlayer != null;
    }

    private bool CanSubmitPlayers()
    {
        return SelectedPlayers != null;
    }

    private bool CanAddPlayers()
    {

        return (SelectedTournament?.MaxNumberPlayer ?? 0) > List_player.Count;
    }





}