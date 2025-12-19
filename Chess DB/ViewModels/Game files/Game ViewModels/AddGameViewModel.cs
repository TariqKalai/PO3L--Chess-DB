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

    [ObservableProperty]
    private ObservableCollection<Player> _players = new();

    public Array Colors => Enum.GetValues(typeof(ChessColor));
    public Array Results => Enum.GetValues(typeof(GameResult));

    [ObservableProperty] private ChessTournament? _selectedTournament;

    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    [ObservableProperty] private Player? _selectedPlayer1;


    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    [ObservableProperty] private Player? _selectedPlayer2;

    [ObservableProperty] private ChessColor _player1Color = ChessColor.White;
    [ObservableProperty] private GameResult _result = GameResult.Draw;

    [ObservableProperty] private string _movesText = "";
    [ObservableProperty] private string _errorMessage = "";

    public AddGameViewModel()
    { //on initialise SelectedTournament pour qu il ne soit pas null 
        if (Tournaments.Count > 0)
            SelectedTournament = Tournaments[0];
    }

    // lorsqu'on change de tournoi, on remet les player selected a null, parfois on n a pas les meme joueur dans 
    // tournoi
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

    //notify Submit qu'on peut ou pas appuyer dessus
    private bool CanSubmit()
    {
        if (SelectedTournament == null) return false;
        if (SelectedPlayer1 == null || SelectedPlayer2 == null) return false;
        if (SelectedPlayer1 == SelectedPlayer2) return false;
        return true;
    }

    [RelayCommand(CanExecute = nameof(CanSubmit))]
    private void Submit()
    {
        Console.WriteLine("=== SUBMIT GAME ===");

        ErrorMessage = "";

        if (!CanSubmit())
        {
            ErrorMessage = "Choisis un tournoi et 2 joueurs différents.";
            Console.WriteLine("Submit aborted: CanSubmit() == false");
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

        Console.WriteLine(
            $"Game created: {SelectedPlayer1!.FirstName} ({SelectedPlayer1.Elo}) vs " +
            $"{SelectedPlayer2!.FirstName} ({SelectedPlayer2.Elo}) | Result: {Result}"
        );

        AppServices.GameFileService.SaveGame(game, SelectedTournament!);
        Console.WriteLine("Game saved.");

        Console.WriteLine("Applying Elo...");
        AppServices.EloCalculator.Apply(game);

        AppServices.PlayerService.Save();
        Console.WriteLine("Players saved.");

        Console.WriteLine(
            $"Elo AFTER: {SelectedPlayer1.FirstName} = {SelectedPlayer1.Elo}, " +
            $"{SelectedPlayer2.FirstName} = {SelectedPlayer2.Elo}"
        );

        Console.WriteLine("=== END SUBMIT ===\n");

        NavigationService.Navigate(new ManageGames());
    }

}
