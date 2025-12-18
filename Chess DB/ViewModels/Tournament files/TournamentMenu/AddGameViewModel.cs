using System;
using System.Collections.ObjectModel;
using Chess_DB.Controls;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chess_DB.ViewModels;

public partial class AddGameViewModel : ViewModelBase
{
    public ObservableCollection<ChessTournament> Tournaments
        => AppServices.TournamentService.TournamentsList;

    // ✅ Players = joueurs inscrits au tournoi sélectionné
    [ObservableProperty]
    private ObservableCollection<Player> _players = new();

    public Array Colors => Enum.GetValues(typeof(ChessColor));
    public Array Results => Enum.GetValues(typeof(GameResult));

    [ObservableProperty] private ChessTournament? _selectedTournament;
    [ObservableProperty] private Player? _selectedPlayer1;
    [ObservableProperty] private Player? _selectedPlayer2;

    [ObservableProperty] private ChessColor _player1Color = ChessColor.White;
    [ObservableProperty] private GameResult _result = GameResult.Draw;

    [ObservableProperty] private string _movesText = "";
    [ObservableProperty] private string _errorMessage = "";

    public AddGameViewModel()
    {
        if (Tournaments.Count > 0)
            SelectedTournament = Tournaments[0]; // déclenche le chargement des registrations
    }

    // ✅ Quand on change de tournoi, on recharge la liste des joueurs inscrits
    partial void OnSelectedTournamentChanged(ChessTournament? value)
    {
        ErrorMessage = "";

        SelectedPlayer1 = null;
        SelectedPlayer2 = null;

        if (value == null)
        {
            Players = new ObservableCollection<Player>();
        }
        else
        {
            // IMPORTANT: LoadRegistration doit retourner une ObservableCollection<Player>
            Players = AppServices.TournamentService.LoadRegistration(value)
                      ?? new ObservableCollection<Player>();
        }

        SubmitCommand.NotifyCanExecuteChanged();
    }

    partial void OnSelectedPlayer1Changed(Player? value) => SubmitCommand.NotifyCanExecuteChanged();
    partial void OnSelectedPlayer2Changed(Player? value) => SubmitCommand.NotifyCanExecuteChanged();

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
            ErrorMessage = "Choisis un tournoi et 2 joueurs différents.";
            return;
        }

        var moves = new ObservableCollection<string>(
            (MovesText ?? "")
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
        );

        var game = new ChessGame(
            SelectedPlayer1!,
            SelectedPlayer2!,
            Result,
            Player1Color,
            moves
        );

        // Si tu sauvegardes par tournoi:
        AppServices.GameFileService.SaveGame(game, SelectedTournament!);


        // Optionnel: navigation back
        NavigationService.Navigate(new ManageGames());
    }
}
