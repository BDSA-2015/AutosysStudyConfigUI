using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StudyConfigurationUI.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyConfigurationUI.View.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResourcePage : Page
    {
        private readonly ResourcePageViewModel _viewModel ;
        public ResourcePage()
        {
            this.InitializeComponent();
            _viewModel = new ResourcePageViewModel();
            DataContext = _viewModel;
        }

        private async void SelectFile_OnClick(object sender, RoutedEventArgs e)
        {
            var filePicker = new FileOpenPicker {
                CommitButtonText = "Select" ,
                SuggestedStartLocation = PickerLocationId.Downloads,
                ViewMode = PickerViewMode.List,
                FileTypeFilter = {".bib"}
            };
           
            var file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                SelectedFileLabel.Text = file.Path;
            }

        }

        private void SubmitFile_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO Make sure file is being sent and converted
            var task = Task.Run(async () =>
            {
               await _viewModel.UploadFileToDatabase(SelectedFileLabel.Text);
            });
        }
    }
}
