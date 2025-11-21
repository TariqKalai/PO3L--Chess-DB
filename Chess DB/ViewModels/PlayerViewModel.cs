namespace Chess_DB.ViewModels;

using System.Collections.ObjectModel;
using Chess_DB.Services;
using System;
using CommunityToolkit.Mvvm.ComponentModel;

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

        return new Player(
            Elo,
            FirstName!,
            LastName!,
            DateOfBirth!,
            Email!,
            Phone!
        );

    }

}
