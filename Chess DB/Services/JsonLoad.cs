using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;

using System.Collections.ObjectModel;
namespace Chess_DB.Services;


public class FileService
{

    //FILEPATH 
    public readonly string filePath =
    Path.Combine(AppContext.BaseDirectory, "Data", "players.json");




    public ObservableCollection<Player> Jsonload()
    {
        try
        {
            // Ensure folder exists

            string dir = Path.GetDirectoryName(filePath)!;

            //creates folder if it does not exist
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {

                Console.WriteLine("dir not existant");
                Directory.CreateDirectory(dir);
            }

            //creates file if it does not exist
            if (!File.Exists(filePath))
            {
                var empty = new ObservableCollection<Player>();
                Console.WriteLine("file not existant");
                SavePlayers(empty);
                return empty;
            }

            //gets the raw text of the filepath
            string json = File.ReadAllText(filePath);

            //returns it in form of an Observable collection
            return JsonSerializer.Deserialize<ObservableCollection<Player>>(json) ?? new ObservableCollection<Player>();
        }


        //If json error then juste create a new json
        catch (JsonException)
        {
            var empty = new ObservableCollection<Player>();
            SavePlayers(empty);
            return empty;
        }
    }


    //SAVE PLAYERs inside the json (serialize and write)
    public void SavePlayers(ObservableCollection<Player> players)

    {

        string json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}