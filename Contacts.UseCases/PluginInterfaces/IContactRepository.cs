using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases.PluginInterfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactAsync(string filterText);
        Task<Contact> GetContactByIdAsync(int contactId);
    }
}
