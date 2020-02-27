// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.MobileBlazorBindings;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileBlazorBindingsTodo
{
    public class App : Application
    {
        public IHost AppHost { get; }

        public App(IServiceCollection additionalServices)
        {
            //var a = Assembly.GetExecutingAssembly();
            //using var stream = a.GetManifestResourceStream($"{a.FullName}.appsettings.json");

            AppHost = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    if (additionalServices != null)
                    {
                        services.AddAdditionalServices(additionalServices);
                    }

                    // Register app-specific services
                    services.AddSingleton<AppState>();
                })
                .Build();

            MainPage = new TabbedPage();
            AppHost.AddComponent<TodoApp>(parent: MainPage);
        }

        private void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection serviceCollection,
            IServiceCollection additionalServices)
        {
            //Register backend-specific services(e.g.iOS, Android)
                    if (additionalServices != null)
            {
                serviceCollection.AddAdditionalServices(additionalServices);
            }

            // Register app-specific services
            serviceCollection.AddSingleton<AppState>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
