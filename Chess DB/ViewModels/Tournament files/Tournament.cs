
using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public abstract partial class Tournament : ViewModelBase
{
    public string TournamentName { get; set; }
    public string Location { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public int MaxNumberPlayer { get; set; }
    public string Description { get; set; }
    public int EntryFee { get; set; }
    public int PrizePool { get; set; }



    public Tournament(string TournamentName,
                      string Location,
                      string StartDate,
                      string EndDate,
                      int MaxNumberPlayer,
                      string Description,
                      int EntryFee,
                      int PrizePool)
    {

        this.TournamentName = TournamentName;
        this.Location = Location;
        this.StartDate = StartDate;
        this.EndDate = EndDate;
        this.MaxNumberPlayer = MaxNumberPlayer;
        this.Description = Description;
        this.EntryFee = EntryFee;
        this.PrizePool = PrizePool;
    }




}