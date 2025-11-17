
using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public abstract partial class Person : ViewModelBase
{
    [ObservableProperty]
    private string? _first_name;

    [ObservableProperty]
    private string? _last_name;

    [ObservableProperty]
    private string? _dateOfBirth;


    [ObservableProperty]

    private string? _Email;

    [ObservableProperty]

    private string? _phone;


    public Person()
    {
    }



}