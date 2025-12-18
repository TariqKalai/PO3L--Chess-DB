
using System.Security;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Chess_DB.ViewModels;
using Chess_DB.Services;
using CommunityToolkit.Mvvm.Input;
using System;



namespace Chess_DB.Controls
{
    public partial class ChoosePlayers : UserControl
    {// Oblige de mettre comme initialisateur sinon on pert toutes nos donné dont remaining players
        public ChoosePlayers(ManageRegistrationViewModel DATA)
        {
            InitializeComponent();
            DataContext = DATA;

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }





    }
}