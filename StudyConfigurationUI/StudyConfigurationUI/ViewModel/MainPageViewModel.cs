using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudyConfigurationUI.Annotations;

namespace StudyConfigurationUI.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private double _version = 0.7;
        public string VersionText => "Autosys Study Configuation - Version: " + _version;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}