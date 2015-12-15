// StudyCriteriaPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.View.ViewDTO;
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
        private readonly StudyCreationPageViewModel _viewModel;
        private CriteriaType _type;

        public StudyCriteriaPage()
        {
            InitializeComponent();
            _viewModel = App.StudyViewModel;
            DataContext = _viewModel;
            CheckDatafieldNotEmpty();
            
        }

        /// <summary>
        /// Check if any datafields are defined 
        /// </summary>
        private async void CheckDatafieldNotEmpty()
        {
            if (!_viewModel.CheckDataField())
            {
                var dialog = new MessageDialog("Please note that no datafields are found.") {Title = "Notice"};
                await dialog.ShowAsync();
            }
        }

        /// <summary>
        ///     Pop ups criteria window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void CriteriaCreationWindow_OnPrimaryButtonClick(ContentDialog sender,
            ContentDialogButtonClickEventArgs args)
        {
            var fieldTag = (Datafield) TagComboBox.SelectionBoxItem;
            var dto = new ViewCriteriaDto
            {
                Name = CriteriaNameBox.Text,
                Description = CriteriaDescriptionBox.Text,
                Comparator = CriteriaComparatorComboBox.SelectionBoxItem.ToString().Trim().ToLower(),
                FieldTag = fieldTag.Name.Trim().ToLower(),
                Value = CriteriaValueBox.Text
            };

            var isSucces = false;
            if (_type == CriteriaType.Inclusion)
            {
                isSucces = _viewModel.AddInclusionCriteria(dto);
            }
            else if (_type == CriteriaType.Exclusion)
            {
                isSucces = _viewModel.AddExclusionCriteria(dto);
            }

            if (!isSucces)
            {
                var dialog = new MessageDialog("Entered data is invalid") {Title = "Error"};
                await dialog.ShowAsync();
            }
            ResetFields();
        }


        /// <summary>
        ///     Add inclusion criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddInclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            _type = CriteriaType.Inclusion;
            await CriteriaCreationWindow.ShowAsync();
        }

        /// <summary>
        ///     Add exclusion criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddExclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            _type = CriteriaType.Exclusion;
            await CriteriaCreationWindow.ShowAsync();
        }

        /// <summary>
        ///     Check if all fields a entered in popup window.
        ///     If all fields are contains text. submit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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
        ///     Resets every fields in popup window
        /// </summary>
        private void ResetFields()
        {
            CriteriaNameBox.Text = "";
            CriteriaDescriptionBox.Text = "";
            CriteriaValueBox.Text = "";
            TagComboBox.SelectedIndex = -1;
            CriteriaComparatorComboBox.SelectedIndex = -1;
            CriteriaCreationWindow.IsPrimaryButtonEnabled = false;
            _type = 0;
        }

        private void DeleteExclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            _type = CriteriaType.Exclusion;
            DeleteCriteria();
        }

        private void DeleteInclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            _type = CriteriaType.Inclusion;
            DeleteCriteria();
        }

        private void DeleteCriteria()
        {
            if (_type == CriteriaType.Inclusion)
            {
                _viewModel.DeleteInclusionCriteria(InclusionTable.SelectedIndex);
            }
            else if (_type == CriteriaType.Exclusion)
            {
                _viewModel.DeleteExclusionCriteria(ExclusionTable.SelectedIndex);
            }
        }


        /// <summary>
        ///     Enum used to determine what criteria table is selected when
        ///     adding criterias
        /// </summary>
        private enum CriteriaType
        {
            Inclusion,
            Exclusion
        }
    }
}