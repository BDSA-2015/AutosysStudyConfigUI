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
using StudyConfigurationUI.View;
using StudyConfigurationUI.View.Pages;
using HomePage = StudyConfigurationUI.View.Pages.HomePage;
using StudyCreationPage = StudyConfigurationUI.View.Pages.StudyCreationPage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudyConfigurationUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        /// <summary>
        /// Naviagte between pages when a radio button is
        /// pressed in splitview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioSplitPaneItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            var pressedRadioButton = sender as RadioButton;
            if (pressedRadioButton != null)
            {
                switch (pressedRadioButton.Tag.ToString())
                {
                    case "Home":
                        MainFrame.Navigate(typeof(HomePage));
                        break;
                    case "StudyCreation":
                        MainFrame.Navigate(typeof (StudyCreationPage));
                        break;
                    case "ManageStudies":
                        MainFrame.Navigate(typeof (ManageStudiesPage));
                        break;
                    case "Resources":
                        MainFrame.Navigate(typeof (ResourcePage));
                        break;
                }
            }
        }
    }
}
