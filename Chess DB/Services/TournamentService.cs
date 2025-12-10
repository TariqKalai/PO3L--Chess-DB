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

    //just calls fileservice to save the current tournament list in the json file
    public void Save()
    {

        Console.WriteLine("I WAS HERE IN TOURNAMENT");

        _fileService.SaveTournaments(TournamentsList);
    }
}
