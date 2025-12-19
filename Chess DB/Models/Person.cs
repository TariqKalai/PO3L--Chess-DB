
using Chess_DB.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public abstract partial class Person : ViewModelBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }


    public Person(string firstName, string lastName, string dateOfBirth, string mail, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Mail = mail;
        Phone = phone;
    }




}