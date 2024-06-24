using Contacts.Maui.Models;
using Contacts.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactPage : ContentPage
{
    private readonly IViewContactsUseCase viewContactsUseCase;

    public ContactPage(IViewContactsUseCase viewContactsUseCase)
	{
		InitializeComponent();
        this.viewContactsUseCase = viewContactsUseCase;

        //List<string> contacts = new List<string>()
        //{
        //    "John Doe",
        //    "Jane Doe",
        //    "Tom Hanks",
        //    "Frank Liu"
        //};
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SearchBar.Text = string.Empty;
        LoadContacts();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(listContacts.SelectedItem != null)
        {
            //logic
            //DisplayAlert("Test", "Test", "ok");

            //await Shell.Current.GoToAsync(nameof(EditContactPage));
            //await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((CoreBusiness.Contact)listContacts.SelectedItem).ContactId}");
        }        
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();
    }

    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<CoreBusiness.Contact>(await this.viewContactsUseCase.ExecuteAsync(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        //var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        var contacts = new ObservableCollection<CoreBusiness.Contact>(await this.viewContactsUseCase.ExecuteAsync(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }



    //private void btnEditContact_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync(nameof(EditContactPage));
    //}

    //private void btnNameContact_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync(nameof(AddContactPage));
    //}
}