﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using MobileBlazorBindingsWeather.Pages;
using Xamarin.Forms;

namespace MobileBlazorBindingsWeather
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
                    services.AddSingleton<WeatherService>();
                })
                .Build();

            MainPage = new ContentPage();
            AppHost.AddComponent<MainPage>(parent: MainPage);
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
