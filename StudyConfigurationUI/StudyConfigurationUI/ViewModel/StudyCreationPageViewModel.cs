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
            AllUsers= new ObservableCollection<User>();
            SelectedUsers = new List<User>();
            SelectedFile = "";
            Phases.Add(new Phase()
            {
                Name = "Phase 1 Test",
                Description = "This is just a test of a phase object added to phase collection"
            });
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
        public IList<User> SelectedUsers { get; }


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
    }
}