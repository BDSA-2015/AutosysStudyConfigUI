using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhaseOverviewPage : Page
    {
        public PhaseOverviewPage()
        {
            InitializeComponent();
        }


        /// <summary>
        ///     Naviagte between pages in phase creation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamsBut.IsSelected)
            {
                Frame.Navigate(typeof (PhaseTeamRolesPage));
            }
            else if (TasksBut.IsSelected)
            {
                Frame.Navigate(typeof (PhaseTaskPage));
            }
            else if (CriteriasBut.IsSelected)
            {
                Frame.Navigate(typeof (PhaseCriteriaPage));
            }
        }
    }
}