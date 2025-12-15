using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;

using System.Collections.ObjectModel;
namespace Chess_DB.Services;

public class TournamentService
{
    private readonly FileService _fileService = new();


    public ObservableCollection<ChessTournament> TournamentsList;//{get;}

    public TournamentService()
    {   // LOAD Json file and loads all of it in the PLayers observable collection
        var loaded = _fileService.LoadTournaments();
        TournamentsList = new ObservableCollection<ChessTournament>(loaded);
    }

    public void Create(ChessTournament tournament)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "Tournaments", $"{tournament.Tournament_id} - {tournament.TournamentName}", "Tournament_players.json");
        string dir = Path.GetDirectoryName(filePath)!;
        Directory.CreateDirectory(dir);


        var empty = new ObservableCollection<Player>();
        string json = JsonSerializer.Serialize(empty, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
    //just calls fileservice to save the current tournament list in the json file
    public void Save()
    {

        Console.WriteLine("I WAS HERE IN TOURNAMENT");

        _fileService.SaveTournaments(TournamentsList);
    }

    public ObservableCollection<Player> LoadRegistration(ChessTournament tournament)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "Tournaments", $"{tournament.Tournament_id} - {tournament.TournamentName}", "Tournament_players.json");
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<ObservableCollection<Player>>(json) ?? new ObservableCollection<Player>();
    }

    public void ModifyRegistration(ChessTournament tournament, ObservableCollection<Player> PlayerList)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "Tournaments", $"{tournament.Tournament_id} - {tournament.TournamentName}", "Tournament_players.json");

        string json = JsonSerializer.Serialize(PlayerList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
