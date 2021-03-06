﻿// StudyCreationPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.View.Pages.StudyCreationPages;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages
{
    /// <summary>
    ///     This page represents the main frame of the program
    /// </summary>
    public sealed partial class StudyCreationPage : Page
    {
        public StudyCreationPage()
        {
            InitializeComponent();
            DataContext = App.StudyViewModel;
            StudyPageFrame.Navigate(typeof (StudyGeneralSettingsPage));
        }


        /// <summary>
        ///     Naviagte between pages in phase creation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GeneralBut.IsSelected)
            {
                StudyPageFrame.Navigate(typeof (StudyGeneralSettingsPage));
            }
            else if (DatafieldBut.IsSelected)
            {
                StudyPageFrame.Navigate(typeof (StudyDatafieldPage));
            }
            else if (CriteriasBut.IsSelected)
            {
                StudyPageFrame.Navigate(typeof (StudyCriteriaPage));
            }
            else if (PhaseBut.IsSelected)
            {
                StudyPageFrame.Navigate(typeof (StudyPhaseListPage));
            }
        }
    }
}