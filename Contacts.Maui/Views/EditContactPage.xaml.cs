using Contacts.Maui.Models;
using Contacts.UseCases.Interfaces;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
	private CoreBusiness.Contact contact;
    private readonly IViewContactUseCase viewContactUseCase;

    public EditContactPage(IViewContactUseCase viewContactUseCase)
	{
		InitializeComponent();
        this.viewContactUseCase = viewContactUseCase;
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

	public string ContactId
	{
		set
		{
			//contact = ContactRepository.GetContactById(int.Parse(value));
            contact = viewContactUseCase.ExecuteAsync(int.Parse(value)).GetAwaiter().GetResult();
            
            //lblName.Text = contact.Name;

            if (contact != null)
            {
                contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;
                contactCtrl.Phone = contact.Phone;
                contactCtrl.Address = contact.Address;
            }
                        
        }
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        //if(nameValidator.IsNotValid)
        //{ 
        //    DisplayAlert("Error", "Name is required.", "OK");
        //    return;
        //}

        //if(emailValidator.IsNotValid)
        //{
        //    foreach(var error in emailValidator.Errors)
        //    {
        //        DisplayAlert("Error", error.ToString(), "OK");
        //    }
        //    return;
        //}

        contact.Name = contactCtrl.Name;
        contact.Email = contactCtrl.Email;
        contact.Phone = contactCtrl.Phone;
        contact.Address = contactCtrl.Address;

        //ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");

    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}