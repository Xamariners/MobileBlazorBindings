// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.MobileBlazorBindings;
using MobileBlazorBindingsTodo.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileBlazorBindingsTodo
{
    public class App : Application
    {
        public IHost AppHost { get; }

        public App(IServiceCollection additionalServices)
        {
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
