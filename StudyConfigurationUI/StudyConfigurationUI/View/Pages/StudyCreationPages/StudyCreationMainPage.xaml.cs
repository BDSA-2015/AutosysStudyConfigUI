// StudyCreationMainPage.xaml.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using Windows.UI.Xaml.Controls;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.StudyCreationPages
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyCreationMainPage : Page
    {
        public StudyCreationMainPage()
        {
            InitializeComponent();
            GeneralPageBut.IsSelected = true;
            PhasePageFrame.Navigate(typeof (StudyGeneralSettingsPage));
        }

        /// <summary>
        ///     Naviagte between pages in phase creation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GeneralPageBut.IsSelected)
            {
                PhasePageFrame.Navigate(typeof (StudyGeneralSettingsPage));
            }
            else if (DatafieldBut.IsSelected)
            {
                PhasePageFrame.Navigate(typeof (StudyDatafieldPage));
            }
            else if (CriteriasBut.IsSelected)
            {
                PhasePageFrame.Navigate(typeof (StudyCriteriaPage));
            }
        }
    }
}