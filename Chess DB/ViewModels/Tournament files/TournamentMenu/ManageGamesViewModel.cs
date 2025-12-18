
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


public partial class ManageGamesViewModel : ViewModelBase
{


    // Creating New observable attributes so  that ater on we can put them inside the selected tournament






    // Just loadiing player in a variable to use it later in axaml
    public ObservableCollection<ChessTournament> List_tournament => AppServices.TournamentService.TournamentsList;

    [ObservableProperty]
    private ObservableCollection<ChessGame> _list_games = new();
    //Make it so it is grayed out if nothing is selected
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SelectTournamentCommand))]
    private ChessTournament? _selectedTournament;


    //READ bellow what happens
    [RelayCommand(CanExecute = nameof(CanAlterTournament))]
    public void SelectTournament()
    {
        //this to give current datacontext all variables;...
        NavigationService.Navigate(new ManageGamesPage(this));
    }




    // Methode created to Allow alteration only if all attributes are  not null, or it 'll initialize something wrong
    private bool CanAlterTournament()
    {
        if (SelectedTournament != null)
        {
            this.List_games = AppServices.GameFileService.LoadAllGames(SelectedTournament);
            return true;
        }

        return false;
    }






}