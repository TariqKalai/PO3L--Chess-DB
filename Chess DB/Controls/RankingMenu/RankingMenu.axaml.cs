using Avalonia.Controls;
using Chess_DB.ViewModels;

namespace Chess_DB.Controls;

public partial class RankingMenu : UserControl
{
    public RankingMenu()
    {
        InitializeComponent();
        DataContext = new RankingViewModel();
    }
}
