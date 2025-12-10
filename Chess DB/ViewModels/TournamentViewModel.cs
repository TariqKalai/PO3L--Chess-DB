namespace Chess_DB.ViewModels;

using System.Collections.ObjectModel;
using Chess_DB.Services;
using System;
using CommunityToolkit.Mvvm.ComponentModel;

//PlayerViewModel of the Player class
public partial class TournamentViewModel : ViewModelBase
{
    [ObservableProperty] private string? _tournamentName;
    [ObservableProperty] private string? _location;
    [ObservableProperty] private string? _startDate;
    [ObservableProperty] private string? _endDate;
    [ObservableProperty] private int _maxNumberPlayer;
    [ObservableProperty] private string _competitionType;

    [ObservableProperty] private string _timeControl;

    [ObservableProperty] private string? _description;
    [ObservableProperty] private int _entryFee;
    [ObservableProperty] private int _prizePool;

    public TournamentViewModel()
    {


    }

    public ChessTournament SubmitTournament()
    {

        if (string.IsNullOrWhiteSpace(TournamentName))
            throw new Exception("TournamentName cannot be empty.");

        if (string.IsNullOrWhiteSpace(Location))
            throw new Exception("Location name cannot be empty.");

        if (string.IsNullOrWhiteSpace(StartDate))
            throw new Exception("Start Date cannot be empty.");

        if (string.IsNullOrWhiteSpace(CompetitionType))
            throw new Exception("Competition type cannot be empty.");

        if (string.IsNullOrWhiteSpace(EndDate))
            throw new Exception("End Date cannot be empty.");

        if (string.IsNullOrWhiteSpace(Description))
            throw new Exception("Description cannot be empty.");


        return new ChessTournament(TournamentName, Location, StartDate, EndDate,
        CompetitionType, TimeControl, MaxNumberPlayer, Description, EntryFee, PrizePool);

    }

}
