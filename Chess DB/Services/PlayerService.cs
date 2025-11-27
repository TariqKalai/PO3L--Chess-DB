using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;

using System.Collections.ObjectModel;
namespace Chess_DB.Services;

public class PlayerService
{
    private readonly FileService _fileService = new();
    public string loaded;


    public ObservableCollection<Player> Players;//{get;}

    public PlayerService()
    {   // LOAD Json file and loads all of it in the PLayers observable collection
        var loaded = _fileService.Jsonload();
        Players = new ObservableCollection<Player>(loaded);
    }

    //just calls fileservice to save the current player list in the json file
    public void Save()
    {

        Console.WriteLine("I WAS HERE");
        _fileService.SavePlayers(Players);
    }
}
