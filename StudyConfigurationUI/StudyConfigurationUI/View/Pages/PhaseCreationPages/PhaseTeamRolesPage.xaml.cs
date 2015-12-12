using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhaseTeamRolesPage : Page
    {
        public PhaseTeamRolesPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Naviagte between pages in phase creation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (OverviewBut.IsSelected)
            {
                Frame.Navigate(typeof(PhaseOverviewPage));
            }
            else if (TasksBut.IsSelected)
            {
                Frame.Navigate(typeof(PhaseTaskPage));
            }
            else if (CriteriasBut.IsSelected)
            {
                Frame.Navigate(typeof(PhaseCriteriaPage));
            }
        }
    }
}
