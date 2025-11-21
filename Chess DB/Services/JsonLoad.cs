using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;

using System.Collections.ObjectModel;
namespace Chess_DB.Services;


public class FileService
{
    public readonly string filePath =
    Path.Combine(AppContext.BaseDirectory, "Data", "players.json");




    public ObservableCollection<Player> Jsonload()
    {
        try
        {
            Console.WriteLine(filePath);
            // Ensure folder exists
            string dir = Path.GetDirectoryName(filePath)!;


            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);


            if (!File.Exists(filePath))
            {
                var empty = new ObservableCollection<Player>();
                SavePlayers(empty);
                return empty;
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<ObservableCollection<Player>>(json) ?? new ObservableCollection<Player>();
        }


        catch (JsonException)
        {
            var empty = new ObservableCollection<Player>();
            SavePlayers(empty);
            return empty;
        }
    }

    public void SavePlayers(ObservableCollection<Player> players)
    {
        string json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(filePath, json);
    }
}