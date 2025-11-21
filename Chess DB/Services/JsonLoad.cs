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
            // Ensure folder exists
            string dir = Path.GetDirectoryName(filePath)!;
            Console.WriteLine(dir);


            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))

                Console.WriteLine("dir not existant");
            Directory.CreateDirectory(dir);


            if (!File.Exists(filePath))
            {
                var empty = new ObservableCollection<Player>();
                Console.WriteLine("file not existant");
                SavePlayers(empty);
                return empty;
            }

            string json = File.ReadAllText(filePath);
            Console.WriteLine("HEREEEEE first", json);
            Console.WriteLine("MAYBE HEREE", JsonSerializer.Deserialize<ObservableCollection<Player>>(json));

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

        foreach (var playegr in players)
        {
            Console.WriteLine(playegr);
        }

        string json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(filePath, json);
        Console.WriteLine(json);
        Console.WriteLine(filePath);
    }
}