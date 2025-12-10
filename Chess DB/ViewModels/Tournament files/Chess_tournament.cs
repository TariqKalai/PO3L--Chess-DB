
using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;


public partial class ChessTournament : Tournament
{

    public string CompetitionType { get; set; }
    public string TimeControl { get; set; }

    public ChessTournament(string TournamentName,
                           string Location,
                           string StartDate,
                           string EndDate,
                           string CompetitionType,
                           string TimeControl,
                           int MaxNumberPlayer,
                           string Description,
                           int EntryFee,
                           int PrizePool) :
    base(TournamentName, Location, StartDate, EndDate,
     MaxNumberPlayer, Description, EntryFee, PrizePool)
    {


        this.CompetitionType = CompetitionType;
        this.TimeControl = TimeControl;

    }

}