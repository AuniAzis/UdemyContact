using Contacts.Maui.Views;

namespace Contacts.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            //Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
            //Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            //Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
        }
    }
}
