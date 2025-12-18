using System.Collections.ObjectModel;
using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public abstract partial class ChessGame : Game
{

    public ChessColor Player1Color { get; set; }

    public ObservableCollection<string> Moves { get; set; } = new();
    public ChessGame(Player Player1, Player Player2, GameResult Result,
    ChessColor Player1color, ObservableCollection<string> Moves) :
    base(Player1, Player2, Result)
    {
        this.Player1Color = Player1Color;
        this.Moves = Moves;
    }

}

public enum ChessColor
{
    White,
    Black
}
