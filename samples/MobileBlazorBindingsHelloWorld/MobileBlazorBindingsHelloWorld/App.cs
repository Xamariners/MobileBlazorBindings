﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using MobileBlazorBindingsHelloWorld.Pages;
using Xamarin.Forms;

namespace MobileBlazorBindingsHelloWorld
{
    public class App : Application
    {
        public IHost AppHost { get; }

        public App()
        {
            AppHost = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Register app-specific services
                    //services.AddSingleton<AppState>();
                })
                .Build();

            MainPage = new ContentPage();
            AppHost.AddComponent<HelloWorld>(parent: MainPage);
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
