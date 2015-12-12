using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.View.Pages.PhaseCreationPages.SubPages;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhaseCreationPage : Page
    {
        public PhaseCreationPage()
        {
            InitializeComponent();
            OverviewPageBut.IsSelected = true;
            PhasePageFrame.Navigate(typeof (PhaseOverviewPage));
        }

        /// <summary>
        ///     Naviagte between pages in phase creation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (OverviewPageBut.IsSelected)
            {
                PhasePageFrame.Navigate(typeof(PhaseOverviewPage));
            }
            else if (TeamsBut.IsSelected)
            {
                PhasePageFrame.Navigate(typeof (PhaseTeamRolesPage));
            }
            else if (TasksBut.IsSelected)
            {
                PhasePageFrame.Navigate(typeof (PhaseTaskPage));
            }
            else if (CriteriasBut.IsSelected)
            {
                PhasePageFrame.Navigate(typeof (PhaseCriteriaPage));
            }
            
        }
    }
}