using Avalonia.Controls;

namespace Chess_DB.Services;

public static class NavigationService
{
    public static ContentControl? PageHost;

    public static void Navigate(Control page)
    {
        if (PageHost != null)
            PageHost.Content = page;
    }
}
