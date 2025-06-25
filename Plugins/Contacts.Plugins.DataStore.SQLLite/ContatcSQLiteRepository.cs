using Android.Provider;
using Contacts.UseCases.PluginInterfaces;
using SQLite;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Plugins.DataStore.SQLLite
{
    // All the code in this file is included in all platforms.
    public class ContatcSQLiteRepository : IContactRepository
    {
        private SQLiteAsyncConnection database;

        public ContatcSQLiteRepository()
        {
            this.database = new SQLiteAsyncConnection(Constants.DatabasePath);
            this.database.CreateTableAsync<Contact>();
        }
        public async Task AddContactAsync(Contacts.CoreBusiness.Contact contact)
        {
            await this.database.InsertAsync(contact);
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = await GetContactByIdAsync(contactId);
            if (contact != null && contact.ContactId == contactId)
                await this.database.DeleteAsync(contact);
        }

        public async Task<List<Contacts.CoreBusiness.Contact>> GetContactAsync(string filterText)
        {
            if (string.IsNullOrEmpty(filterText))
                return await this.database.Table<Contact>().ToListAsync();

            return await this.database.QueryAsync<Contact>(@"
                SELECT *
                FORM Contact
                WHERE 
                    Name LIKE ? OR
                    Email LIKE ? OR
                    Phone LIKE  ? OR
                    Address LIKE ?",
                    $"{filterText}%",
                    $"{filterText}%",
                    $"{filterText}%",
                    $"{filterText}%");
        }

        public async Task<CoreBusiness.Contact> GetContactByIdAsync(int contactId)
        {
            return await this.database.Table<Contact>().Where(x => x.ContactId == contactId).FirstOrDefaultAsync();
        }

        public async Task UpdateContactAsync(int contactId, CoreBusiness.Contact contact)
        {
            if (contactId == contact.ContactId)
                await this.database.UpdateAsync(contact);
        }
    }
}
