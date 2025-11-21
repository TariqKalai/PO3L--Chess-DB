using System;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class Player : Person
{
    public int Elo { get; set; }

    private static int ID_incrementation = 0;

    public int Player_id { get; set; }
    public Player(int elo, string firstName, string lastName, string dateOfBirth, string mail, string phone) :
     base(firstName, lastName, mail, phone, dateOfBirth)
    {
        ID_incrementation += 1;

        Player_id = ID_incrementation;
        Elo = elo;
        Console.WriteLine(String.Format("Player id {0} has been given", Player_id));
    }


    public void Change_elo(int new_elo)
    {
        Elo = new_elo;
    }

}