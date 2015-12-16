// MainPageViewModel.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudyConfigurationUI.Annotations;

#endregion

namespace StudyConfigurationUI.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private double _version = 0.8;
        public string VersionText => "Autosys Study Configuation - Version: " + _version;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}