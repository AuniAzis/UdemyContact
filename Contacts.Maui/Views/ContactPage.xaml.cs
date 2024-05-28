using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();

        //List<string> contacts = new List<string>()
        //{
        //    "John Doe",
        //    "Jane Doe",
        //    "Tom Hanks",
        //    "Frank Liu"
        //};

        List<Contact> contacts = ContactRepository.GetContacts();
        listContacts.ItemsSource = contacts;

    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        
        if(listContacts.SelectedItem != null)
        {
            //logic
            //DisplayAlert("Test", "Test", "ok");

            await Shell.Current.GoToAsync(nameof(EditContactPage));
        }
        
        
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
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