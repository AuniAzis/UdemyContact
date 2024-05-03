namespace Contacts.Maui.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
	}

    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

    private void btnNameContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}