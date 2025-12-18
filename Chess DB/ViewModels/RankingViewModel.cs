using System.Collections.ObjectModel;
using System.Linq;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Chess_DB.ViewModels;

public partial class RankingViewModel : ViewModelBase
{
    public class RankingRow
    {
        public int Rank { get; set; }
        public Player Player { get; set; } = null!;
    }

    [ObservableProperty]
    private ObservableCollection<RankingRow> _rankedPlayers = new();

    public RankingViewModel()
    {
        LoadRanking();
    }

    private void LoadRanking()
    {
        var sorted = AppServices.PlayerService.Players
            .OrderByDescending(p => p.Elo)
            .ThenBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ToList();

        RankedPlayers = new ObservableCollection<RankingRow>(
            sorted.Select((p, i) => new RankingRow { Rank = i + 1, Player = p })
        );
    }
}
