// StudyGeneralSettingsPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 14, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Collections.Generic;
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
            }
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
            { Title = "Submit Phase." };
            dialog.Commands.Add(new UICommand("Yes") { Id = 0 });
            dialog.Commands.Add(new UICommand("No") { Id = 1 });

            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 1;

            var choice = await dialog.ShowAsync();

            if (choice.Id.Equals(0))
            {
                //Todo Submit method
            }
        }


        private void ConfirmSelectionBut_OnClick(object sender, RoutedEventArgs e)
        {
            var selections = MembersTable.SelectedItems.Cast<User>().ToList();
            _viewModel.AddSelectedUsers(selections);
        }
    }
}