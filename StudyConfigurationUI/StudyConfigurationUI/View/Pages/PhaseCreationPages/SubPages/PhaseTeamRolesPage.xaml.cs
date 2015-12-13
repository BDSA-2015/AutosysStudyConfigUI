using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.Model.PhaseModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.PhaseCreationPages.SubPages
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

        private void DataFieldCreationWindow_OnOpened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            //throw new System.NotImplementedException();
        }


        private async void AddDatafieldBut_OnClick(object sender, RoutedEventArgs e)
        {
            await DataFieldCreationWindow.ShowAsync();
        }

        private void DataFieldCreationWindow_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Todo Add datafield creation and add it to observable list
        }

        private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Todo Set datafield object type
        }

        private void TaskCreationWindow_OnOpened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void TaskCreationWindow_OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Todo create new task and add it to observable collection
        }

        private async void AddTaskBut_OnClick(object sender, RoutedEventArgs e)
        {
            await TaskCreationWindow.ShowAsync();
        }
    }
}
