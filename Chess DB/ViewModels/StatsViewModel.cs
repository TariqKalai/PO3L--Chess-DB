using System;
using System.Collections.ObjectModel;
using System.Linq;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Chess_DB.ViewModels;

public partial class StatsViewModel : ObservableObject
{
    public ObservableCollection<ChessTournament> Tournaments => AppServices.TournamentService.TournamentsList;


    public int TotalPlayers
        => AppServices.PlayerService.Players?.Count ?? 0;

    public double AverageElo
    {
        get
        {
            var players = AppServices.PlayerService.Players;
            if (players == null || players.Count == 0) return 0;

            return (int)Math.Round(players.Average(p => p.Elo));
        }
    }

    public void Refresh()
    {
        OnPropertyChanged(nameof(Tournaments));
        OnPropertyChanged(nameof(TotalPlayers));
        OnPropertyChanged(nameof(AverageElo));
    }
}
