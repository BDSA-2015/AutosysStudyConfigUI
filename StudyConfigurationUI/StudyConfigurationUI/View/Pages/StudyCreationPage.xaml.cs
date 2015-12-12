using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.View.Pages.PhaseCreationPages;
using StudyConfigurationUI.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyCreationPage : Page
    {
        private StudyCreationPageViewModel _viewModel;
        public StudyCreationPage()
        {
            this.InitializeComponent();
            _viewModel = new StudyCreationPageViewModel();
            DataContext = _viewModel;
        }

        private void AddPhaseBut_OnClick(object sender, RoutedEventArgs e)
        {
            var toCreate = _viewModel.AddPhase();
            Frame.Navigate(typeof(PhaseOverviewPage));
           
        }

        private async void SubmitBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_viewModel.ValidateStudy())
            {
                var dialog = new MessageDialog("Study has not been configured correctly. Please validate your settings again") {Title = "Error"};   
            }
            
            if (PhaseList.SelectedIndex != -1)
            {
                var dialog = new MessageDialog(
                    "Are you sure you want to submit the Study?")
                { Title = "Delete Phase." };
                dialog.Commands.Add(new UICommand("Yes") { Id = 0 });
                dialog.Commands.Add(new UICommand("No") { Id = 1 });

                dialog.DefaultCommandIndex = 1;
                dialog.CancelCommandIndex = 1;

                var choice = await dialog.ShowAsync();

                if (choice.Id.Equals(0))
                {
                    _viewModel.DeletePhase(PhaseList.SelectedIndex);
                }
            }
        }

        private void EditPhaseBut_OnClick(object sender, RoutedEventArgs e)
        {
           var phaseToEdit = _viewModel.GetPhase(PhaseList.SelectedIndex);
            //Todo Add navigation to phase editor/creation page
        }

        private async void DeletePhaseBut_OnClick(object sender, RoutedEventArgs e)
        {
            if (PhaseList.SelectedIndex != -1)
            {
                var dialog = new MessageDialog(
                    "Are you sure you want to delete the selected phase?")
                { Title = "Delete Phase." };
                dialog.Commands.Add(new UICommand("Yes") { Id = 0 });
                dialog.Commands.Add(new UICommand("No") { Id = 1 });

                dialog.DefaultCommandIndex = 1;
                dialog.CancelCommandIndex = 1;

                var choice = await dialog.ShowAsync();

                if (choice.Id.Equals(0))
                {
                    _viewModel.DeletePhase(PhaseList.SelectedIndex);
                }
            }
        }
    }
}
