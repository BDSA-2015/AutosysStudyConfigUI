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

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages.SubPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhaseCriteriaPage : Page
    {
        public PhaseCriteriaPage()
        {
            this.InitializeComponent();
        }

        private void ExclusionCreationWindow_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Todo add creation of criteria and add it to obs list in viewmodel.
            //throw new NotImplementedException();
        }

        private void ExclusionCreationWindow_OnOpened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void ExclusionComparator_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ExclusionTagComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void InclusionCreationWindow_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void InclusionCreationWindow_OnOpened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            ///throw new NotImplementedException();
        }

        private void InclusionTagComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void InclusionComparator_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async void AddInclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            await InclusionCreationWindow.ShowAsync();
        }

        private async void AddExclusionBut_OnClick(object sender, RoutedEventArgs e)
        {
            await ExclusionCreationWindow.ShowAsync();
        }
    }
}
