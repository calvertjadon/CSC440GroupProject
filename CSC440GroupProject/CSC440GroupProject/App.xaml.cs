﻿using CSC440GroupProject.Stores;
using CSC440GroupProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CSC440GroupProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // _navigationStore.CurrentViewModel = new LoginViewModel();
            _navigationStore.CurrentViewModel = new SearchViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}