
namespace Chess_DB.ViewModels;

using System;

using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
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


    }
}