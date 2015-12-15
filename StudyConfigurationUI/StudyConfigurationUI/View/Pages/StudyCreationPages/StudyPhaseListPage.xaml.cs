using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StudyConfigurationUI.View.Pages.PhaseCreationPages.SubPages;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages.StudyCreationPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyPhaseListPage : Page
    {
        public StudyPhaseListPage()
        {
            this.InitializeComponent();
        }



        private void EditPhaseBut_OnClick(object sender, RoutedEventArgs e)
        {
            
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
                    //Add Deletetion
                }
            }
        }

        private void AddPhaseBut_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (PhaseSetupPage));
        }
    }
}
