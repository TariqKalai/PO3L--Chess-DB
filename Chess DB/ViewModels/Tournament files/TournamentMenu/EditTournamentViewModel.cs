
using Chess_DB.Services;

using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Chess_DB.Controls;


namespace Chess_DB.ViewModels;


public partial class EditTournamentViewModel : ViewModelBase
{
    public ObservableCollection<string> TimeControls { get; } = new()
    {
        "Classical",
        "Rapid",
        "Blitz",
        "Bullet",
        "Armageddon"
    };

    public ObservableCollection<string> CompetitionType { get; } = new()
    {
        "Swiss",
        "Round Robbin",
        "Knockout",
        "Bullet",
        "Arenas"
    };


    // Creating New observable attributes so  that ater on we can put them inside the selected tournament
    [ObservableProperty] private string? _new_TournamentName;
    [ObservableProperty] private string? _new_Location;
    [ObservableProperty] private string? _new_StartDate;
    [ObservableProperty] private string? _new_EndDate;
    [ObservableProperty] private int _new_MaxNumberPlayer;
    [ObservableProperty] private string _new_CompetitionType = string.Empty;
    [ObservableProperty] private string _new_TimeControl = string.Empty;
    [ObservableProperty] private string? _new_Description;
    [ObservableProperty] private int _new_EntryFee;
    [ObservableProperty] private int _new_PrizePool;



    // Just loadiing player in a variable to use it later in axaml
    public ObservableCollection<ChessTournament> List_tournament => AppServices.TournamentService.TournamentsList;

    [ObservableProperty]
    //Make it so it is grayed out if nothing is sleected
    [NotifyCanExecuteChangedFor(nameof(DeleteTournamentCommand))]
    [NotifyCanExecuteChangedFor(nameof(ModifyTournamentCommand))]
    private ChessTournament? _selectedTournament;


    //READ bellow what happens
    [RelayCommand(CanExecute = nameof(CanAlterTournament))]
    public void ModifyTournament()
    {
        if (SelectedTournament is null) return;

        New_TournamentName = SelectedTournament.TournamentName;
        New_Location = SelectedTournament.Location;
        New_StartDate = SelectedTournament.StartDate;
        New_EndDate = SelectedTournament.EndDate;
        New_CompetitionType = SelectedTournament.CompetitionType;
        New_TimeControl = SelectedTournament.TimeControl;
        New_MaxNumberPlayer = SelectedTournament.MaxNumberPlayer;
        New_Description = SelectedTournament.Description;
        New_EntryFee = SelectedTournament.EntryFee;
        New_PrizePool = SelectedTournament.PrizePool;

        //this to give current datacontext all variables;...
        NavigationService.Navigate(new EditTournamentPage(this));
    }

    [RelayCommand] //Maybe add condition to grey out button
    public void Submit()
    {
        if (SelectedTournament is null) return;

        //simple enough just changing the vars
        SelectedTournament.TournamentName = New_TournamentName!;
        SelectedTournament.Location = New_Location!;
        SelectedTournament.StartDate = New_StartDate!;
        SelectedTournament.EndDate = New_EndDate!;
        SelectedTournament.CompetitionType = New_CompetitionType;
        SelectedTournament.TimeControl = New_TimeControl;
        SelectedTournament.MaxNumberPlayer = New_MaxNumberPlayer;
        SelectedTournament.Description = New_Description!;
        SelectedTournament.EntryFee = New_EntryFee;
        SelectedTournament.PrizePool = New_PrizePool;


        AppServices.TournamentService.Save();
        NavigationService.Navigate(new EditTournament());
    }


    //READ bellow what happens
    [RelayCommand(CanExecute = nameof(CanAlterTournament))]
    public void DeleteTournament()
    {
        if (SelectedTournament is null) return;

        Console.WriteLine($"Removed tournament '{SelectedTournament.TournamentName}'");
        List_tournament.Remove(SelectedTournament);
        //need to save of course
        AppServices.TournamentService.Save();


    }


    // Methode created to Allow alteration only if all attributes are  not null, or it 'll initialize something wrong
    private bool CanAlterTournament()
    {
        return SelectedTournament != null;
    }


}