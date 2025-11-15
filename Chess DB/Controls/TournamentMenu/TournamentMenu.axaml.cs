using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Chess_DB.Controls;

public partial class TournamentMenu : UserControl
{
    public TournamentMenu()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

}