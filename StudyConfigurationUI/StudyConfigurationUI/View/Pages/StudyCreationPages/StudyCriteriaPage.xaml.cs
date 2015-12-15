// StudyCriteriaPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 14, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
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
    public sealed partial class StudyCriteriaPage : Page
    {
        private StudyCreationPageViewModel _viewModel;
        public StudyCriteriaPage()
        {
            InitializeComponent();
            _viewModel = App.StudyViewModel;
            DataContext = _viewModel;
        }

        private void CriteriaCreationWindow_OnPrimaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
            //Todo add creation of criteria and add it to obs list in viewmodel.
            //throw new NotImplementedException();
        }


        private void ExclusionComparator_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CriteriaTagComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void InclusionCreationWindow_OnPrimaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
            //throw new NotImplementedException();
        }


        private async void AddInclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            await CriteriaCreationWindow.ShowAsync();
            ResetFields();
        }

        private async void AddExclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            await CriteriaCreationWindow.ShowAsync();
            ResetFields();
        }


        private void CheckTextInput(TextBox sender, TextBoxTextChangingEventArgs args)
        {

            if (!string.IsNullOrWhiteSpace(CriteriaNameBox.Text) &&
                !string.IsNullOrWhiteSpace(CriteriaDescriptionBox.Text) &&
                !string.IsNullOrWhiteSpace(CriteriaValueBox.Text))
                CriteriaCreationWindow.IsPrimaryButtonEnabled = true;
            else
                CriteriaCreationWindow.IsPrimaryButtonEnabled = false;
        
        }

        /// <summary>
        /// Resets every fields in popup window
        /// </summary>
        private void ResetFields()
        {
            CriteriaNameBox.Text = "";
            CriteriaDescriptionBox.Text = "";
            CriteriaValueBox.Text ="";
            TagComboBox.SelectedIndex = -1;
            CriteriaComparatorComboBox.SelectedIndex = -1;   
            CriteriaCreationWindow.IsPrimaryButtonEnabled = false;
        }

    }
}