// PhaseSetupPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.View.Pages.StudyCreationPages;
using StudyConfigurationUI.ViewModel.PhaseCreationViewModels;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages
{
    /// <summary>
    ///     This represents the page where you setup a phase
    /// </summary>
    public sealed partial class PhaseSetupPage : Page
    {
        private PhaseCreationViewModel _viewModel;

        public PhaseSetupPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Retrieves a phase that are to be configured when navigated to this page
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is PhaseCreationDto)
            {
                var phaseToCreate = (PhaseCreationDto) e.Parameter;
                _viewModel = new PhaseCreationViewModel(phaseToCreate);
                DataContext = _viewModel;
            }
            else
            {
                var dialog = new MessageDialog("Something went wrong.") {Title = "Error loading game."};
                await dialog.ShowAsync();
            }
        }

        private void AddRequestedFieldsBut_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedField = RequestedFieldsCombobox.SelectedIndex;
            if (selectedField == -1) return;
            _viewModel.AddRequestField(selectedField);
        }

        private void DeleteRequestedFieldsBut_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteRequestedField(RequestedDatafieldTable.SelectedIndex);
        }

        private void AddVisibleFieldsBut_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedField = VisibleFieldsComboBox.SelectedIndex;
            if (selectedField == -1) return;
            _viewModel.AddVisibleField(selectedField);
        }

        private void DeleteVisibleFieldsBut_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteVisibleField(RequestedDatafieldTable.SelectedIndex);
        }

        private void Validator_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMember = ReviewerCombobox.SelectedIndex;
            _viewModel.SetValidator(selectedMember);
        }

        private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var isSucces = _viewModel.SetPhaseSettings();
            if (!isSucces)
            {
                var dialog =
                    new MessageDialog(
                        "Something went wrong with creating the phase.")
                    {Title = "Error"};
                await dialog.ShowAsync();
                return;
            }
            else Frame.Navigate(typeof (StudyPhaseListPage));
        }
    }
}