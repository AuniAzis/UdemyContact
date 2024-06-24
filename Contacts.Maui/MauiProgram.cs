using CommunityToolkit.Maui;
using Contacts.UseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;
using Contacts.Plugins.DataStore.InMemory;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases;
using Contacts.Maui.Views;

namespace Contacts.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IContactRepository, ContatactInMemoryRepository>();
            builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
            builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();

            builder.Services.AddSingleton<ContactPage>();
            builder.Services.AddSingleton<EditContactPage>();

            return builder.Build();
        }
    }
}
