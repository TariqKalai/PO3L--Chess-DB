using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;
namespace Chess_DB.Services;

public class FileService
{
    public readonly string filePath =
    Path.Combine(AppContext.BaseDirectory, "Data", "players.json");




    public List<Player> Jsonload()
    {
        try
        {
            Console.WriteLine(filePath);
            // Ensure folder exists
            string dir = Path.GetDirectoryName(filePath);


            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);


            if (!File.Exists(filePath))
            {
                var empty = new List<Player>();
                SavePlayers(empty);
                return empty;
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
        }


        catch (JsonException)
        {
            var empty = new List<Player>();
            SavePlayers(empty);
            return empty;
        }
    }

    public void SavePlayers(List<Player> players)
    {
        string json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(filePath, json);
    }
}