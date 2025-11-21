
using System.Security;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.ViewModels;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;
using System;



namespace Chess_DB.Controls
{
    public partial class AddPlayer : UserControl
    {
        public AddPlayer()
        {
            InitializeComponent();
            DataContext = new AddPlayerViewModel();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }




    }
}