using System.Collections.ObjectModel;
using StudyConfigurationUI.Model.PhaseModels;

namespace StudyConfigurationUI.ViewModel.PhaseCreationViewModels
{
    public class PhaseCreationViewModel
    {
        public PhaseCreationViewModel()
        {
        }

        public ObservableCollection<User> Users { get; }
        public ObservableCollection<Datafield> VisibleDatafields { get; }
        public ObservableCollection<Datafield> RequestedDatafields { get; }

    }
}