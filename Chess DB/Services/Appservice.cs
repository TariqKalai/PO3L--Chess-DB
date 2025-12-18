

namespace Chess_DB.Services;

//APPService creates static instance for all my service files so i can use them in other files
public static class AppServices
{
    public static PlayerService PlayerService { get; } = new PlayerService();
    public static TournamentService TournamentService { get; } = new TournamentService();

    public static GameFileService GameFileService { get; } = new GameFileService();

    public static EloCalculator EloCalculator { get; } = new EloCalculator();
}