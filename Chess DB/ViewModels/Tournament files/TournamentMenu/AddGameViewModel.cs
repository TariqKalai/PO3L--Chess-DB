using System;
using System.Collections.ObjectModel;
using System.Linq;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chess_DB.ViewModels;

public partial class AddGameViewModel : ViewModelBase
{
    // Lists for ComboBoxes
    public ObservableCollection<Player> Players => AppServices.PlayerService.PlayersList;
    public ObservableCollection<ChessTournament> Tournaments => AppServices.TournamentService.TournamentsList;

    public Array Colors => Enum.GetValues(typeof(ChessColor));
    public Array Results => Enum.GetValues(typeof(GameResult));

    // Selections / form fields
    [ObservableProperty] private ChessTournament? _selectedTournament;
    [ObservableProperty] private Player? _selectedPlayer1;
    [ObservableProperty] private Player? _selectedPlayer2;

    [ObservableProperty] private ChessColor _player1Color = ChessColor.White;
    [ObservableProperty] private GameResult _result = GameResult.Draw;

    // Moves as a multi-line text (easy UX)
    [ObservableProperty] private string _movesText = "";

    [ObservableProperty] private string _errorMessage = "";

    public AddGameViewModel()
    {
        // Optional defaults
        if (Tournaments.Count > 0) SelectedTournament = Tournaments[0];
    }

    private bool CanSubmit()
    {
        if (SelectedTournament == null) return false;
        if (SelectedPlayer1 == null || SelectedPlayer2 == null) return false;
        if (ReferenceEquals(SelectedPlayer1, SelectedPlayer2)) return false;
        return true;
    }

    [RelayCommand(CanExecute = nameof(CanSubmit))]
    private void Submit()
    {
        ErrorMessage = "";

        if (!CanSubmit())
        {
            ErrorMessage = "Please select a tournament and two different players.";
            return;
        }

        // Split moves: 1 move per line, ignore empty lines
        var moves = new ObservableCollection<string>(
            (MovesText ?? "")
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(m => m.Trim())
            .Where(m => !string.IsNullOrWhiteSpace(m))
        );

        // Create game (needs ChessGame NOT abstract + should have settable Id in base)
        var game = new ChessGame(
            SelectedPlayer1!,
            SelectedPlayer2!,
            Result,
            Player1Color,
            moves
        );

        // Save in tournament folder (your GameFileService should have this overload)
        AppServices.GameFileService.SaveGame(game, SelectedTournament!);

        // Optional: navigate back
        // NavigationService.GoBack();
    }

    // When any important field changes, update CanExecute
    partial void OnSelectedTournamentChanged(ChessTournament? value) => SubmitCommand.NotifyCanExecuteChanged();
    partial void OnSelectedPlayer1Changed(Player? value) => SubmitCommand.NotifyCanExecuteChanged();
    partial void OnSelectedPlayer2Changed(Player? value) => SubmitCommand.NotifyCanExecuteChanged();
}
