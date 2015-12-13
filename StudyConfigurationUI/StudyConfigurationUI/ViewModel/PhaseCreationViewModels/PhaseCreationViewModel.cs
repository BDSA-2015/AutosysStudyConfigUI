using System.Collections.ObjectModel;
using StudyConfigurationUI.Model.PhaseModels;

namespace StudyConfigurationUI.ViewModel.PhaseCreationViewModels
{
    public class PhaseCreationViewModel
    {
        public PhaseCreationViewModel()
        {
            Criterias = new ObservableCollection<Criteria>();
        }

        public ObservableCollection<Criteria> Criterias { get; }
        public ObservableCollection<Task> Tasks { get; }
        public ObservableCollection<User> Users { get; }
        public ObservableCollection<Datafield> Datafields { get; }
    }
}