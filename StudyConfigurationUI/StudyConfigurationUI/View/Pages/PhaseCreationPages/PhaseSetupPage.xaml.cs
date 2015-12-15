using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.ViewModel.PhaseCreationViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhaseSetupPage : Page
    {
        private PhaseCreationViewModel _viewModel;
        public PhaseSetupPage()
        {
            this.InitializeComponent();
            _viewModel = new PhaseCreationViewModel();
            DataContext = _viewModel;
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
