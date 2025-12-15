
using Chess_DB.Services;

using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Chess_DB.Controls;


namespace Chess_DB.ViewModels;


public partial class ManageRegistrationViewModel : ViewModelBase
{


    // Creating New observable attributes so  that ater on we can put them inside the selected tournament
    [ObservableProperty] private string? _new_TournamentName;
    [ObservableProperty] private int _new_MaxNumberPlayer;
    [ObservableProperty] private string _new_CompetitionType;



    // Just loadiing player in a variable to use it later in axaml
    public ObservableCollection<ChessTournament> List_tournament => AppServices.TournamentService.TournamentsList;

    [ObservableProperty]
    //Make it so it is grayed out if nothing is selected
    [NotifyCanExecuteChangedFor(nameof(SelectTournamentCommand))]
    private ChessTournament? _selectedTournament;
    public ManageRegistrationViewModel()
    {


    }



    //READ bellow what happens
    [RelayCommand(CanExecute = nameof(CanAlterTournament))]
    public void SelectTournament()
    {
        //this to give current datacontext all variables;...
        NavigationService.Navigate(new ManageRegistrationPage(this));
    }




    // Methode created to Allow alteration only if all attributes are  not null, or it 'll initialize something wrong
    private bool CanAlterTournament()
    {
        return SelectedTournament != null;
    }


}