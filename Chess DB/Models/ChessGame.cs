using System.Collections.ObjectModel;
using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class ChessGame : Game
{

    public ChessColor Player1Color { get; set; }

    public ObservableCollection<string> Moves { get; set; } = new();
    public ChessGame(Player player1, Player player2, GameResult result,
                 ChessColor player1Color, ObservableCollection<string> moves)
    : base(player1, player2, result)
    {
        Player1Color = player1Color;
        Moves = moves ?? new ObservableCollection<string>();
    }


}

public enum ChessColor
{
    White,
    Black
}
