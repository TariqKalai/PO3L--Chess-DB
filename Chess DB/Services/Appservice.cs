

namespace Chess_DB.Services;

//APPService juste creates the same Playerservice that every file will use
public static class AppServices
{
    public static PlayerService PlayerService { get; } = new PlayerService();
    public static TournamentService TournamentService { get; } = new TournamentService();
}