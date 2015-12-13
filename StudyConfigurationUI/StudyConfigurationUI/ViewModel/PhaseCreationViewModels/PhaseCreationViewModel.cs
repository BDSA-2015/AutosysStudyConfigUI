using System.Collections.ObjectModel;
using StudyConfigurationUI.Model.PhaseModels;

namespace StudyConfigurationUI.ViewModel.PhaseCreationViewModels
{
    public class PhaseCreationViewModel
    {
        public ObservableCollection<Criteria> Criterias { get; }
        public ObservableCollection<Task> Tasks{ get; }
        public ObservableCollection<User> Users { get; }
        public ObservableCollection<Datafield> Datafields { get; }




        public PhaseCreationViewModel()
        {
            Criterias = new ObservableCollection<Criteria>();
        }
    }
}