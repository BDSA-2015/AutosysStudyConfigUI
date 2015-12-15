// PhaseViewModel.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudyConfigurationUI.Annotations;
using StudyConfigurationUI.Model.PhaseModels;

#endregion

namespace StudyConfigurationUI.ViewModel
{
    public class PhaseViewModel : INotifyPropertyChanged
    {
        private Phase _phase;
        private string _description;
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Datafield> VisibleDatafields { get; }
        public ObservableCollection<Datafield> RequestedDatafields { get; }
        public ObservableCollection<Datafield> AvailableDatafields { get; } 

        public PhaseViewModel(Phase phase, IList<User> selectedUser, List<Datafield> datafields )
        {
            SelectedUsers = new ObservableCollection<User>();
            RequestedDatafields = new ObservableCollection<Datafield>();
            VisibleDatafields = new ObservableCollection<Datafield>();
            AvailableDatafields = new ObservableCollection<Datafield>();
            AddSelectedUserToObservable(selectedUser);
            AddAvailableFields(datafields);
            _phase = phase;
        }

        private ObservableCollection<User> SelectedUsers { get; }
        /// <summary>
        /// Phase members are users with defined roles
        /// </summary>
        private IList<PhaseMember> PhaseMembers { get; }

        /// <summary>
        ///     Populate observable list with users selected
        ///     to the study.
        /// </summary>
        /// <param name="users"> List of users</param>
        private void AddSelectedUserToObservable(IList<User> users)
        {
            foreach (var user in users)
            {
                SelectedUsers.Add(user);
            }
        }

        /// <summary>
        /// Populating available datafields
        /// </summary>
        /// <param name="datafields"></param>
        private void AddAvailableFields(IList<Datafield> datafields)
        {
            foreach (var datafield in datafields)
            {
                AvailableDatafields.Add(datafield);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}