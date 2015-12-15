// StudyGeneralSettingsPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 14, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.StudyCreationPages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyGeneralSettingsPage : Page
    {
        public StudyGeneralSettingsPage()
        {
            InitializeComponent();
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

        private void SubmitFile_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}