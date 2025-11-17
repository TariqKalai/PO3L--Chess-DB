using System;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class Player : Person
{
    [ObservableProperty]
    private int? _elo;

    private static int ID_incrementation = 0;

    [ObservableProperty]
    private int _player_id;
    public Player()
    {
        ID_incrementation += 1;

        Player_id = ID_incrementation;

        Console.WriteLine(String.Format("Player id {0} has been given", Player_id));
    }


    public void Change_elo(int new_elo)
    {
        Elo = new_elo;
    }

}