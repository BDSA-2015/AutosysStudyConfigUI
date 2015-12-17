// PhaseCreationViewModel.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using StudyConfigurationUI.Annotations;
using StudyConfigurationUI.Model.Handlers;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.View.ViewDTO;

#endregion

namespace StudyConfigurationUI.ViewModel.PhaseCreationViewModels
{
    /// <summary>
    ///     This viewmodel is used to create a single phase
    /// </summary>
    public class PhaseCreationViewModel : INotifyPropertyChanged
    {
        private PhaseMember _currentValidator;
        private string _description;


        private IList<PhaseMember> _members;
        private string _name;

        private Phase _phase;

        public PhaseCreationViewModel(PhaseCreationDto toCreate)
        {
            Initialize(toCreate);
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

        public ObservableCollection<PhaseMember> Members { get; set; }
        public ObservableCollection<PhaseMember> Reviewers { get; set; }

        public ObservableCollection<Datafield> VisibleDatafields { get; set; }
        public ObservableCollection<Datafield> RequestedDatafields { get; set; }
        public ObservableCollection<Datafield> Datafields { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Initialize(PhaseCreationDto toCreationDto)
        {
            Members = new ObservableCollection<PhaseMember>();
            VisibleDatafields = new ObservableCollection<Datafield>();
            RequestedDatafields = new ObservableCollection<Datafield>();
            Datafields = new ObservableCollection<Datafield>();
            _phase = toCreationDto.Phase;
            _members = toCreationDto.Members;

            foreach (var datafield in toCreationDto.Datafields)
            {
                Datafields.Add(datafield);
            }

            foreach (var member in toCreationDto.Members)
            {
                member.SetAsReviewer();
                Members.Add(member);
            }
        }

        /// <summary>
        ///     Add all reviewers to list
        /// </summary>
        private void AddReviewers()
        {
            Members.Clear();
            foreach (var member in _members)
            {
                Members.Add(member);
            }
        }

        /// <summary>
        ///     Set a member to current validator
        ///     and removes previous one if existing
        /// </summary>
        /// <param name="selectedMember"></param>
        public void SetValidator(int selectedMember)
        {
            if (selectedMember == -1) return;
            if (_currentValidator != null)
            {
                _currentValidator.SetAsReviewer();
                var newValidator = Members[selectedMember];
                newValidator.SetasValidator();
                _currentValidator = newValidator;
            }
            else
            {
                var newValidator = Members[selectedMember];
                newValidator.SetasValidator();
                _currentValidator = newValidator;
            }
            AddReviewers();
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Add datafield as requested datafield
        /// </summary>
        /// <param name="selectedField"></param>
        public void AddRequestField(int selectedField)
        {
            var toInsert = Datafields[selectedField];
            AddDatafield(RequestedDatafields, toInsert);
        }

        /// <summary>
        ///     Add given datafield as visiblefield
        /// </summary>
        /// <param name="selectedField"></param>
        public void AddVisibleField(int selectedField)
        {
            var toInsert = Datafields[selectedField];
            AddDatafield(VisibleDatafields, toInsert);
        }

        /// <summary>
        ///     Add a datafield to a given list.
        ///     If item datafield already exist in the list
        ///     The datafield will be skipped
        /// </summary>
        /// <param name="list">list to add datafield</param>
        /// <param name="toInsert">datafield to add</param>
        private void AddDatafield(IList<Datafield> list, Datafield toInsert)
        {
            if (list.Contains(toInsert)) return;
            list.Add(toInsert);
        }

        /// <summary>
        ///     Removes a requested datafield from list
        /// </summary>
        /// <param name="selectedIndex">index of datafield</param>
        public void DeleteRequestedField(int selectedIndex)
        {
            RequestedDatafields.RemoveAt(selectedIndex);
        }


        /// <summary>
        ///     Removes a visible datafield from list
        /// </summary>
        /// <param name="selectedIndex"> index of datafield</param>
        public void DeleteVisibleField(int selectedIndex)
        {
            VisibleDatafields.RemoveAt(selectedIndex);
        }
        
        /// <summary>
        /// Submit information on view to phase object
        /// </summary>
        /// <returns></returns>
        public bool SetPhaseSettings()
        {
            try
            {
                var phaseInfo = new ViewPhaseDto() {
                    Name = _name,Description = _description,
                    Members = this.Members,
                    RequestedDatafields = this.RequestedDatafields,
                    VisibleDatafields = this.VisibleDatafields};

                var handler = new PhaseHandler();
                return handler.SetPhase(_phase,phaseInfo);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}