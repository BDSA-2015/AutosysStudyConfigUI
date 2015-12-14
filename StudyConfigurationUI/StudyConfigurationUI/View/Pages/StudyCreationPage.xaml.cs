// StudyCreationPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 10, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.View.Pages.StudyCreationPages;
using StudyConfigurationUI.ViewModel;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyCreationPage : Page
    {
        private StudyCreationPageViewModel _viewModel;

        public StudyCreationPage()
        {
            InitializeComponent();
            _viewModel = new StudyCreationPageViewModel();
            DataContext = _viewModel;
            StudyPageFrame.Navigate(typeof (StudyGeneralSettingsPage));
        }

        private async void SubmitBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_viewModel.ValidateStudy())
            {
                var errorMsg =
                    new MessageDialog("Study has not been configured correctly. Please validate your settings again")
                    {
                        Title = "Error"
                    };
                return;
            }


            var dialog = new MessageDialog(
                "Are you sure you want to submit the Study?")
            {Title = "Submit Phase."};
            dialog.Commands.Add(new UICommand("Yes") {Id = 0});
            dialog.Commands.Add(new UICommand("No") {Id = 1});

            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 1;

            var choice = await dialog.ShowAsync();

            if (choice.Id.Equals(0))
            {
                //Todo Submit method
            }
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