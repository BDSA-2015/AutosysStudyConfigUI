using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudyConfigurationUI.Annotations;
using StudyConfigurationUI.Model;

namespace StudyConfigurationUI.ViewModel
{
    public class StudyCreationPageViewModel : INotifyPropertyChanged
    {
        public StudyCreationPageViewModel()
        {
            Phases = new ObservableCollection<Phase>();
        }

        public ObservableCollection<Phase> Phases { get; private set; } 

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}