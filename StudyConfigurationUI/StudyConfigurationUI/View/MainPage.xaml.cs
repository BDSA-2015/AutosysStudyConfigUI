using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.View.Pages;
using StudyConfigurationUI.ViewModel;
using HomePage = StudyConfigurationUI.View.Pages.HomePage;
using StudyCreationPage = StudyConfigurationUI.View.Pages.StudyCreationPage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudyConfigurationUI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private MainPageViewModel _viewModel;

        public MainPage()
        {
            this.InitializeComponent();
            _viewModel = new MainPageViewModel();
            DataContext = _viewModel;
            Home.IsSelected = true;
            Title.Text = "Home";
            MainFrame.Navigate(typeof (HomePage));

        }

        /// <summary>
        /// When Burger button is clicked - show or hide splitpane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Naviagte between pages when a page button is
        /// pressed in splitview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var titleText = "";

            if (Home.IsSelected)
            {
                MainFrame.Navigate(typeof(HomePage));
                titleText = "Home";
            }
            else if (StudyCreation.IsSelected)
            {
                MainFrame.Navigate(typeof(StudyCreationPage));
                titleText = "Study Creation";
            }
            else if (ManageStudies.IsSelected)
            {
                MainFrame.Navigate(typeof(ManageStudiesPage));
                titleText = "Manage Studies";
            }
            else if (Resources.IsSelected)
            {
                MainFrame.Navigate(typeof(ResourcePage));
                titleText = "Resources";
            }

            Title.Text = titleText;
        }
    }
}
