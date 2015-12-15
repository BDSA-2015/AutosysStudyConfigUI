// StudyCreationPageViewModel.cs is a part of Autosys project in BDSA-2015. Created: 14, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudyConfigurationUI.Annotations;
using StudyConfigurationUI.Model;
using StudyConfigurationUI.Model.Handlers;
using StudyConfigurationUI.Model.PhaseModels;

#endregion

namespace StudyConfigurationUI.ViewModel
{
    public class StudyCreationPageViewModel : INotifyPropertyChanged
    {
        private string _description;
        private string _name;
        private string _selectedFile;


        public StudyCreationPageViewModel()
        {
            Phases = new ObservableCollection<Phase>();
            AllUsers = new ObservableCollection<User>();
            Datafields = new ObservableCollection<Datafield>();
            SelectedUsers = new List<User>();
            SelectedFile = "";
            AddCachedUsers();
            AddPredefinedDatafields();
        }

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

        public string SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                if (value == _selectedFile) return;
                _selectedFile = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Phase> Phases { get; }
        public ObservableCollection<User> AllUsers { get; }
        public ObservableCollection<Datafield> Datafields { get; }
        public IList<User> SelectedUsers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Add a phase to collection and returns it for creation
        /// </summary>
        /// <returns>Phase object</returns>
        public Phase AddPhase()
        {
            var toCreate = new Phase();
            Phases.Add(toCreate);
            return toCreate;
        }

        /// <summary>
        ///     Delete a given phase
        /// </summary>
        /// <param name="selectedIndex"> Selected phase in UI</param>
        public void DeletePhase(int selectedIndex)
        {
            Phases.RemoveAt(selectedIndex);
        }

        /// <summary>
        ///     Gets a phase selected from UI
        /// </summary>
        /// <param name="selectedIndex"> selected phase</param>
        /// <returns> Phase Object</returns>
        public Phase GetPhase(int selectedIndex)
        {
            return Phases[selectedIndex];
        }

        /// <summary>
        ///     Validates the study if the configuration is correct.
        /// </summary>
        /// <returns></returns>
        public bool ValidateStudy()
        {
            throw new NotImplementedException();
        }

        //UserMethods

        /// <summary>
        /// Add all users retrieved from server
        /// </summary>
        private void AddCachedUsers()
        {
            var users = LocalCache.GetCache().CachedUsers;
            if (users != null)
            {
                foreach (var user in users)
                {
                    AllUsers.Add(user);
                }
            }

        }

        /// <summary>
        /// Add selected user to study. 
        /// </summary>
        /// <param name="selectedUsers"></param>
        public void AddSelectedUsers(IList<User> selectedUsers)
        {
            SelectedUsers = selectedUsers;
        }


        //DatafieldMethods

        /// <summary>
        /// Add a custom datafield defined in UI
        /// </summary>
        /// <param name="name"> of datafield</param>
        /// <param name="description"></param>
        /// <param name="type"> of datafield</param>
        /// <param name="value"> value of type</param>
        /// <returns></returns>
        public bool AddDatafield(string name, string description, string type, string value)
        {
            var handler = new DatafieldHandler();
            try
            {
                var datafield = handler.CreateCustomDatafield(name, description, type, value);
                Datafields.Add(datafield);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }

        }

        /// <summary>
        /// Removes a datafield from collection
        /// </summary>
        /// <param name="selectedItem"></param>
        public void DeleteDatafield(int selectedItem)
        {
            var toDelete = Datafields[selectedItem];
            if(toDelete.Type == "predifined")return;
            Datafields.RemoveAt(selectedItem);
        }

        /// <summary>
        /// Add all predefined datafields from database.
        /// </summary>
        private void AddPredefinedDatafields()
        {
            var predifinedDatafields = LocalCache.GetCache().CachedDatafields;
            if (predifinedDatafields != null)
            {
                foreach (var datafield in predifinedDatafields)
                {
                    Datafields.Add(datafield);
                }
            }
        }

      

    }
}