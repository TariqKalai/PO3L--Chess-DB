using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Chess_DB.Services;

public class GameFileService
{
    private string GetGamesDir(ChessTournament tournament)
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            "Data",
            "Tournaments",
            $"{tournament.Tournament_id} - {tournament.TournamentName}"
        );
    }

    // -----------------------------
    // Save
    // -----------------------------
    public void SaveGame(ChessGame game, ChessTournament tournament)
    {
        string GamesDir = GetGamesDir(tournament);
        if (game == null)
            throw new ArgumentNullException(nameof(game));

        if (game.Player1 == null || game.Player2 == null)
            throw new InvalidOperationException("Game must have two players.");



        string fileName = BuildFileName(game);
        string filePath = Path.Combine(GamesDir, fileName);

        string json = JsonSerializer.Serialize(game, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    // -----------------------------
    // Load one
    // -----------------------------
    public ChessGame? LoadGame(string fileName, ChessTournament tournament)
    {

        string GamesDir = GetGamesDir(tournament);
        string path = Path.Combine(GamesDir, fileName);
        if (!File.Exists(path))
            return null;

        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<ChessGame>(json, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (JsonException)
        {
            return null;
        }
    }

    // -----------------------------
    // Load all
    // -----------------------------
    public ObservableCollection<ChessGame> LoadAllGames(ChessTournament tournament)
    {

        string GamesDir = GetGamesDir(tournament);
        var games = new ObservableCollection<ChessGame>();

        foreach (var file in Directory.EnumerateFiles(GamesDir, "*.json"))
        {
            try
            {
                string json = File.ReadAllText(file);
                var game = JsonSerializer.Deserialize<ChessGame>(json, new JsonSerializerOptions { WriteIndented = true });
                if (game != null)
                    games.Add(game);
            }
            catch (JsonException)
            {
                // ignore corrupted file
            }
        }

        return games;
    }

    // -----------------------------
    // Delete
    // -----------------------------
    public bool DeleteGame(int gameId, ChessTournament tournament)
    {

        string GamesDir = GetGamesDir(tournament);
        var file = Directory
            .EnumerateFiles(GamesDir, $"{gameId}_*.json")
            .FirstOrDefault();

        if (file == null)
            return false;

        File.Delete(file);
        return true;
    }


    private static string BuildFileName(ChessGame game)
    {
        string p1 = game.Player1.FirstName;
        string p2 = game.Player2.FirstName;

        return $"{game.Match_id}_{p1}_{p2}.json";
    }

}
