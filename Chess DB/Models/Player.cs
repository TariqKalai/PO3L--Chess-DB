using System;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class Player : Person
{
    public int Elo { get; set; }

    private static int ID_incrementation = 0;

    public int Player_id { get; set; }
    public Player(int elo, string firstName, string lastName, string dateOfBirth, string mail, string phone) :
     base(firstName, lastName, dateOfBirth, mail, phone)
    {
        ID_incrementation += 1;

        Player_id = ID_incrementation;
        Elo = elo;
        Console.WriteLine(String.Format("Player id {0} has been given", Player_id));
    }
    [JsonConstructor]
    public Player(int Player_id, int elo, string firstName, string lastName, string dateOfBirth, string mail, string phone) :
     base(firstName, lastName, dateOfBirth, mail, phone)
    {
        if (Player_id > ID_incrementation)
        {

            ID_incrementation = Player_id;
        }
        this.Player_id = Player_id;

        Elo = elo;
        Console.WriteLine(String.Format("Player id {0} has been given", Player_id));
    }



    public override string ToString()
    {
        return $"Player ID {Player_id}: {FirstName} {LastName} (ELO {Elo})";
    }

}