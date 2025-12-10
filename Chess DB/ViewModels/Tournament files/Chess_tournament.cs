
using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;


public abstract partial class ChessTournament : Tournament
{

    public string CompetitionType { get; set; }

    public ChessTournament(string TournamentName,
                           string Location,
                           string StartDate,
                           string EndDate,
                           string CompetitionType,
                           int MaxNumberPlayer,
                           string Description,
                           int EntryFee,
                           int PrizePool) :
    base(TournamentName, Location, StartDate, EndDate,
     MaxNumberPlayer, Description, EntryFee, PrizePool)
    {


        this.CompetitionType = CompetitionType;

    }

}