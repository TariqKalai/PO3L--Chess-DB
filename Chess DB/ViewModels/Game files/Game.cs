using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public abstract partial class Game : ViewModelBase
{

    public int Match_id { get; set; }

    public Player Player1 { get; set; }
    public Player Player2 { get; set; }

    public GameResult Result { get; set; }

    private static int ID_incrementation = 0;

    public Game(Player Player1, Player Player2, GameResult Result)
    {

        ID_incrementation += 1;

        Match_id = ID_incrementation;
        this.Player1 = Player1;
        this.Player2 = Player2;
        this.Result = Result;

    }
}

public enum GameResult
{
    Player1Win,
    Player2Win,
    Draw
}
