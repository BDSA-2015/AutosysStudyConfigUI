// StudyPhaseListPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.ViewModel;
using PhaseSetupPage = StudyConfigurationUI.View.Pages.PhaseCreationPages.PhaseSetupPage;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.StudyCreationPages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyPhaseListPage : Page
    {
        private StudyCreationPageViewModel _viewModel;

        public StudyPhaseListPage()
        {
            InitializeComponent();
            _viewModel = App.StudyViewModel;
            DataContext = _viewModel;
        }


        private async void DeletePhaseBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (PhaseList.SelectedIndex != -1)
            {
                var dialog = new MessageDialog(
                    "Are you sure you want to delete the selected phase?")
                {Title = "Delete Phase."};
                dialog.Commands.Add(new UICommand("Yes") {Id = 0});
                dialog.Commands.Add(new UICommand("No") {Id = 1});

                dialog.DefaultCommandIndex = 1;
                dialog.CancelCommandIndex = 1;

                var choice = await dialog.ShowAsync();

                if (choice.Id.Equals(0))
                {
                    _viewModel.DeletePhase(PhaseList.SelectedIndex);
                }
            }
        }

        private async void AddPhaseBut_OnClick(object sender, RoutedEventArgs e)
        {
            var dto = _viewModel.AddPhase();
            if( dto == null)
            {
                var dialog = new MessageDialog("Something went wrong when creating phase") {Title = "Error"};
                await dialog.ShowAsync();
            }
            else Frame.Navigate(typeof (PhaseSetupPage),dto);
        }
    }
}