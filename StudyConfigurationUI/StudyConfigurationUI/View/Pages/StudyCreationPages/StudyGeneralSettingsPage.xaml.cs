// StudyGeneralSettingsPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Linq;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.ViewModel;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.StudyCreationPages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyGeneralSettingsPage : Page
    {
        private StudyCreationPageViewModel _viewModel;

        public StudyGeneralSettingsPage()
        {
            InitializeComponent();
            _viewModel = App.StudyViewModel;
            DataContext = _viewModel;
        }

        private async void SelectFile_OnClick(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker
            {
                CommitButtonText = "Select",
                SuggestedStartLocation = PickerLocationId.Downloads,
                ViewMode = PickerViewMode.List,
                FileTypeFilter = {".bib"}
            };

            var file = await filePicker.PickSingleFileAsync();
            if (file != null)
            {
                SelectedFileLabel.Text = file.Path;

                var isSucces = await _viewModel.AddResourceFile(file);
                if (!isSucces)
                {
                    var dialog = new MessageDialog("Something went wrong while loading file.") {Title = "Error"};
                    await dialog.ShowAsync();
                    SelectedFileLabel.Text = "";
                }
            }
        }

        private async void SubmitBut_OnClick(object sender, RoutedEventArgs e)
        {
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
                var isSuccess = _viewModel.SubmitStudy();
                if (!isSuccess)
                {
                    var errorMsg =
                        new MessageDialog(
                            "Something went wrong with the submission. Please check your study configuration.")
                        {
                            Title = "Error"
                        };
                    await errorMsg.ShowAsync();
                }
                else
                {
                    var msg = new MessageDialog("Submitted.") {Title = "Notice"};
                    await msg.ShowAsync();
                    _viewModel.ResetConfiguration();
                    Frame.Navigate(typeof (HomePage));
                }
            }
        }


        /// <summary>
        ///     Confirming user selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ConfirmSelectionBut_OnClick(object sender, RoutedEventArgs e)
        {
            var selections = MembersTable.SelectedItems.Cast<User>().ToList();
            _viewModel.AddSelectedUsers(selections);
            var dialog = new MessageDialog("Selection confirmed") {Title = "Notice"};
            await dialog.ShowAsync();
        }


        private async void ResetStudyBut_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog(
                "Are you sure you want to reset the study configuration? THIS CAN NOT BE UNDONE.")
            {Title = "Warning - Reset of study"};
            dialog.Commands.Add(new UICommand("Yes") {Id = 0});
            dialog.Commands.Add(new UICommand("No") {Id = 1});

            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 1;

            var choice = await dialog.ShowAsync();

            if (choice.Id.Equals(0))
            {
                _viewModel.ResetConfiguration();
            }
        }
    }
}