
using System.Security;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.ViewModels;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;
using System;



namespace Chess_DB.Controls
{
    public partial class EditTournamentPage : UserControl
    {

        //or create a page but get the same datacontext to shares variable
        public EditTournamentPage(EditTournamentViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        //eitehr create a NEw page with this one

        public EditTournamentPage()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }




    }
}