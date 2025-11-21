using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;

using System.Collections.ObjectModel;
namespace Chess_DB.Services;

public class PlayerService
{
    private readonly FileService _fileService = new();

    public ObservableCollection<Player> Players { get; }

    public PlayerService()
    {
        var loaded = _fileService.Jsonload();
        Players = new ObservableCollection<Player>(loaded);
    }

    public void Save()
    {
        _fileService.SavePlayers(Players);
    }
}
