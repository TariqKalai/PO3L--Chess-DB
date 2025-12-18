
using System.Security;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.ViewModels;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;
using System;



namespace Chess_DB.Controls
{
    public partial class ManageGamesPage : UserControl
    {

        //or create a page but get the same datacontext to shares variable
        public ManageGamesPage(ManageGamesViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        //eitehr create a NEw page with this one

        public ManageGamesPage()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }




    }
}