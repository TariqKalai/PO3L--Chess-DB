namespace Chess_DB.ViewModels;

using System.Collections.ObjectModel;
using Chess_DB.Services;
using System;
using CommunityToolkit.Mvvm.ComponentModel;

//PlayerViewModel of the Player class
public partial class PlayerViewModel : ViewModelBase
{
    [ObservableProperty] private string? _firstName;
    [ObservableProperty] private string? _lastName;
    [ObservableProperty] private string? _dateOfBirth;
    [ObservableProperty] private string? _email;
    [ObservableProperty] private string? _phone;
    [ObservableProperty] private int _elo;

    public PlayerViewModel()
    {


    }

    public Player SubmitPlayer()
    {

        Console.WriteLine(String.Format("First Name is {0}", FirstName));
        Console.WriteLine(String.Format("Last Name is {0}", LastName));
        Console.WriteLine(String.Format("Elo is {0}", Elo));
        Console.WriteLine(String.Format("DateofBirth is {0}", DateOfBirth));
        Console.WriteLine(String.Format("mail  is {0}", Email));
        Console.WriteLine(String.Format("Phone is {0}", Phone));

        if (string.IsNullOrWhiteSpace(FirstName))
            throw new Exception("First name cannot be empty.");

        if (string.IsNullOrWhiteSpace(LastName))
            throw new Exception("Last name cannot be empty.");

        if (string.IsNullOrWhiteSpace(DateOfBirth))
            throw new Exception("Date of birth cannot be empty.");

        if (string.IsNullOrWhiteSpace(Email))
            throw new Exception("Email cannot be empty.");

        if (string.IsNullOrWhiteSpace(Phone))
            throw new Exception("Phone cannot be empty.");


        //inverts dateofbirth email and phone???
        return new Player(Elo, FirstName, LastName, DateOfBirth, Email, Phone);

    }

}
