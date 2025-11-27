
namespace Chess_DB.ViewModels;

using System.Collections.ObjectModel;

using Chess_DB.Services;

public partial class EditPlayerViewModel : ViewModelBase
{
    public ObservableCollection<Player> List_player => AppServices.PlayerService.Players;
    public EditPlayerViewModel()
    {
    }

}