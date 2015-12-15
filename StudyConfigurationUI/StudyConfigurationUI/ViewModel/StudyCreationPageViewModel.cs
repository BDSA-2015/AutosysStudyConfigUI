﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudyConfigurationUI.Annotations;
using StudyConfigurationUI.Model.PhaseModels;

namespace StudyConfigurationUI.ViewModel
{
    public class StudyCreationPageViewModel : INotifyPropertyChanged
    {
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
        private string _name;

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
        private string _description;

        public ObservableCollection<Phase> Phases { get; } 
        public ObservableCollection<User> AllUsers { get; } 
        public IList<User> SelectedUsers { get;} 

        public event PropertyChangedEventHandler PropertyChanged;


        public StudyCreationPageViewModel()
        {
            Phases = new ObservableCollection<Phase>();
            Phases.Add(new Phase() {Name = "Phase 1 Test", Description = "This is just a test of a phase object added to phase collection"});
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Add a phase to collection and returns it for creation
        /// </summary>
        /// <returns>Phase object</returns>
        public Phase AddPhase()
        {
            var toCreate = new Phase();
            Phases.Add(toCreate);
            return toCreate;
        }

        /// <summary>
        /// Delete a given phase
        /// </summary>
        /// <param name="selectedIndex"> Selected phase in UI</param>
        public void DeletePhase(int selectedIndex)
        {
            Phases.RemoveAt(selectedIndex);
        }

        /// <summary>
        /// Gets a phase selected from UI
        /// </summary>
        /// <param name="selectedIndex"> selected phase</param>
        /// <returns> Phase Object</returns>
        public Phase GetPhase(int selectedIndex)
        {
            return Phases[selectedIndex];
        }

        /// <summary>
        /// Validates the study if the configuration is correct.
        /// </summary>
        /// <returns></returns>
        public bool ValidateStudy()
        {
            throw new NotImplementedException();
        }
    }
}