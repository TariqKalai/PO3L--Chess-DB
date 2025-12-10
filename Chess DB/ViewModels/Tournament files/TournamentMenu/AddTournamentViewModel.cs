
namespace Chess_DB.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using Chess_DB.Controls;

public partial class AddTournamentViewModel : ViewModelBase
{
    public ObservableCollection<string> TimeControls { get; } = new()
    {
        "Classical",
        "Rapid",
        "Blitz",
        "Bullet",
        "Armageddon"
    };

    // The Source Generator creates the public 'SelectedTimeControl' property for you
    [ObservableProperty]
    private string _selectedTimeControl = "Rapid";

    public ObservableCollection<string> CompetitionType { get; } = new()
    {
        "Swiss",
        "Round Robbin",
        "Knockout",
        "Bullet",
        "Arenas"
    };

    // The Source Generator creates the public 'SelectedTimeControl' property for you
    [ObservableProperty]
    private string _selectedCompetitionType = "Swiss";

    public AddTournamentViewModel()
    {

    }

    public TournamentViewModel Form { get; } = new();


    [RelayCommand]
    public void Submit()
    {
        Form.CompetitionType = SelectedCompetitionType;
        Form.TimeControl = SelectedTimeControl;
        var tournament = Form.SubmitTournament();

        AppServices.TournamentService.TournamentsList.Add(tournament);
        AppServices.TournamentService.Save();
        NavigationService.Navigate(new TournamentMenu());


    }
}