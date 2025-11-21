
namespace Chess_DB.ViewModels;

using System;

using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;

public partial class AddPlayerViewModel : ViewModelBase
{
    public AddPlayerViewModel()
    {
    }

    public PlayerViewModel Form { get; } = new();


    [RelayCommand]
    public void Submit()
    {
        var player = Form.SubmitPlayer();

        AppServices.PlayerService.Players.Add(player);
        AppServices.PlayerService.Save();

        Console.WriteLine(Form.FirstName);
        Console.WriteLine(Form.LastName);
        Console.WriteLine(Form.DateOfBirth);
        Console.WriteLine(Form.Phone);
        Console.WriteLine(Form.Elo);
        Console.WriteLine(Form.Email);
    }
}