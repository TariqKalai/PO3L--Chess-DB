using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Chess_DB.Services;
//GamefileService manages files for games, so creation, loading, deleting,...

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
            //ignorer corrupt files
            catch (JsonException)
            {
            }
        }

        return games;
    }
    public void DeleteGame(int gameId, ChessTournament tournament)
    {

        string GamesDir = GetGamesDir(tournament);
        var file = Directory
            .EnumerateFiles(GamesDir, $"{gameId}_*.json")
            .FirstOrDefault();

        if (file == null)
            return;

        File.Delete(file);
    }


    private static string BuildFileName(ChessGame game)
    {
        string p1 = game.Player1.FirstName;
        string p2 = game.Player2.FirstName;

        return $"{game.Match_id}_{p1}_{p2}.json";
    }

}
