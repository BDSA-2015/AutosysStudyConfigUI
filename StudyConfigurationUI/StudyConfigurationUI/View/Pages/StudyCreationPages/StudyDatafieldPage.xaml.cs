// StudyDatafieldPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 14, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.ViewModel;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.StudyCreationPages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyDatafieldPage : Page
    {
        private StudyCreationPageViewModel _viewModel;
        public StudyDatafieldPage()
        {
            InitializeComponent();
            _viewModel = App.StudyViewModel;
            DataContext = _viewModel;
        }

        private async void DataFieldCreationWindow_OnPrimaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
            var isSucces = _viewModel.AddDatafield(
                DatafieldNameBox.Text,
                DatafieldDescriptionBox.Text,
                TypeComboBox.SelectionBoxItem.ToString().Trim().ToLower(),
                DatafieldValueBox.Text.Trim().ToLower());
            if (!isSucces)
            {
                var dialog = new MessageDialog("Entered data is invalid") { Title = "Error"};
                await dialog.ShowAsync();
            }
            ResetFields();
        }

        /// <summary>
        /// Resets every fields in popup window
        /// </summar
        private void ResetFields()
        {
            DatafieldNameBox.Text = "";
            DatafieldDescriptionBox.Text = "";
            TypeComboBox.SelectedIndex = -1;
            DatafieldValueBox.Text = "";
            DataFieldCreationWindow.IsPrimaryButtonEnabled = false;
        }

        /// <summary>
        /// When a different type is selected in combo box
        /// Set placement text in value textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //String selected
            if (TypeComboBox.SelectedIndex == 0)
            {
                DatafieldValueBox.PlaceholderText = "Enter a string";
            }
            else if (TypeComboBox.SelectedIndex == 1)
            {
                DatafieldValueBox.PlaceholderText = "enter 'true' or 'false' without the quotes";
            }
        }

        /// <summary>
        /// When add datafieldbutton is pressed show popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddDatafieldBut_OnClick(object sender, RoutedEventArgs e)
        {
            await DataFieldCreationWindow.ShowAsync();
        }

        /// <summary>
        /// When cancel is pressed, reset text fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DataFieldCreationWindow_OnSecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ResetFields();
        }

        private void CheckTextInput(TextBox sender, TextBoxTextChangingEventArgs args)
        {

            if (!string.IsNullOrWhiteSpace(DatafieldNameBox.Text) &&
                !string.IsNullOrWhiteSpace(DatafieldDescriptionBox.Text) &&
                !string.IsNullOrWhiteSpace(DatafieldValueBox.Text))
                DataFieldCreationWindow.IsPrimaryButtonEnabled = true;
            else
                DataFieldCreationWindow.IsPrimaryButtonEnabled = false;

        }

        /// <summary>
        /// Deletes datafield when button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDatafieldBut_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = DatafieldsTable.SelectedIndex;
            if (selectedItem == -1) return;
            _viewModel.DeleteDatafield(selectedItem);
        }
    }
}