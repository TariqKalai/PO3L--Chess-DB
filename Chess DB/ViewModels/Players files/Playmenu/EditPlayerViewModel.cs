
namespace Chess_DB.ViewModels;

using System.Collections.ObjectModel;

using Chess_DB.Services;

public partial class EditPlayerViewModel : ViewModelBase
{
    // Just loadiing player in a variable to use it later in axaml
    public ObservableCollection<Player> List_player => AppServices.PlayerService.Players;
    public EditPlayerViewModel()
    {
    }

}