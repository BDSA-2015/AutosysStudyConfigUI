// StudyCreationPageViewModel.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Storage;
using StudyConfigurationUI.Annotations;
using StudyConfigurationUI.Model;
using StudyConfigurationUI.Model.Handlers;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.Model.StudyModels;
using StudyConfigurationUI.View.ViewDTO;

#endregion

namespace StudyConfigurationUI.ViewModel
{
    /// <summary>
    ///     view model for study creation
    /// </summary>
    public class StudyCreationPageViewModel : INotifyPropertyChanged
    {
        private string _description;
        private string _loadedFile;
        private string _name;


        public StudyCreationPageViewModel()
        {
            Initialize();
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

        public string LoadedFile
        {
            get { return _loadedFile; }
            set
            {
                if (value == _loadedFile) return;
                _loadedFile = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Phase> Phases { get; set; }
        public ObservableCollection<User> AllUsers { get; set; }
        public ObservableCollection<Datafield> Datafields { get; set; }
        public ObservableCollection<Criteria> ExclusionCriteria { get; set; }
        public ObservableCollection<Criteria> InclusionCriteria { get; set; }

        /// <summary>
        ///     Selected users for the study
        /// </summary>
        public IList<User> SelectedUsers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Initialize view model.
        /// </summary>
        private void Initialize()
        {
            Name = "";
            Description = "";
            LoadedFile = "";
            Phases = new ObservableCollection<Phase>();
            AllUsers = new ObservableCollection<User>();
            Datafields = new ObservableCollection<Datafield>();
            ExclusionCriteria = new ObservableCollection<Criteria>();
            InclusionCriteria = new ObservableCollection<Criteria>();
            SelectedUsers = new List<User>();
            AddCachedUsers();
            AddPredefinedDatafields();


            AllUsers.Add(new User() {Description = "Test", Name = "Name1"});
            AllUsers.Add(new User() {Description = "Test", Name = "Name2"});
            AllUsers.Add(new User() {Description = "Test", Name = "Name3"});
            AllUsers.Add(new User() {Description = "Test", Name = "Name4"});
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        //UserMethods

        /// <summary>
        ///     Add all users retrieved from server
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
        ///     Add selected user to study.
        /// </summary>
        /// <param name="selectedUsers"></param>
        public void AddSelectedUsers(IList<User> selectedUsers)
        {
            SelectedUsers = selectedUsers;
        }


        //DatafieldMethods

        public bool CheckDataField()
        {
            return Datafields.Count != 0;
        }


        /// <summary>
        ///     Add a custom datafield defined in UI
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
        ///     Removes a datafield from collection
        /// </summary>
        /// <param name="selectedItem"></param>
        public void DeleteDatafield(int selectedItem)
        {
            var toDelete = Datafields[selectedItem];
            if (toDelete.Type == "predifined") return;
            Datafields.RemoveAt(selectedItem);
        }

        /// <summary>
        ///     Add all predefined datafields from database.
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

        //ResourceFileMethods
        /// <summary>
        ///     Read content of resource file and load it to memory
        /// </summary>
        /// <param name="file"></param>
        /// <returns>
        ///     Task if successful
        /// </returns>
        public async Task<bool> AddResourceFile(StorageFile file)
        {
            try
            {
                var handler = new FileHandler();
                var parsedFile = await handler.Parse(file);
                if (!string.IsNullOrWhiteSpace(parsedFile))
                {
                    LoadedFile = parsedFile;
                    return true;
                }
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }


        //CriteriaMethods

        /// <summary>
        ///     Adds inclusion criteria
        /// </summary>
        /// <param name="dto">dto of criteria</param>
        /// <returns> if adding criteria is successful</returns>
        public bool AddInclusionCriteria(ViewCriteriaDto dto)
        {
            try
            {
                return AddCriteria(InclusionCriteria, dto);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }


        /// <summary>
        ///     Adds exclusion criteria
        /// </summary>
        /// <param name="dto">dto of criteria given from view</param>
        /// <returns> if adding criteria is successful</returns>
        public bool AddExclusionCriteria(ViewCriteriaDto dto)
        {
            try
            {
                return AddCriteria(ExclusionCriteria, dto);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        ///     Add criteria to a observable collection
        /// </summary>
        /// <param name="list"> Observable collection</param>
        /// <param name="dto"> dto of criteria given from view</param>
        /// <returns></returns>
        private bool AddCriteria(ICollection<Criteria> list, ViewCriteriaDto dto)
        {
            var handler = new CriteriaHandler();
            var criteria = handler.CreateCriteria(dto);
            list.Add(criteria);
            return true;
        }

        /// <summary>
        ///     Delete criteria from inclusion list
        /// </summary>
        /// <param name="selectedIndex"> criteria to delete</param>
        public void DeleteInclusionCriteria(int selectedIndex)
        {
            DeleteCriteria(InclusionCriteria, selectedIndex);
        }

        /// <summary>
        ///     Delete criteria from inclusion list
        /// </summary>
        /// <param name="selectedIndex">criteria to delete</param>
        public void DeleteExclusionCriteria(int selectedIndex)
        {
            DeleteCriteria(ExclusionCriteria, selectedIndex);
        }

        /// <summary>
        ///     Deletes a criteria from an observable list
        /// </summary>
        /// <param name="list"> observable list</param>
        /// <param name="index"> of criteria to delete</param>
        private void DeleteCriteria(IList list, int index)
        {
            list.RemoveAt(index);
        }

        /// <summary>
        ///     Resets the study configuration
        /// </summary>
        public void ResetConfiguration()
        {
            Initialize();
        }


        //Phase Methods
        /// <summary>
        ///     Add a phase to collection and returns it for creation
        /// </summary>
        /// <returns>Phase object</returns>
        public PhaseCreationDto AddPhase()
        {
            if (Datafields.Count == 0 || SelectedUsers.Count == 0) return null;
            try
            {
                var phase = new Phase();
                var handler = new PhaseHandler();
                var dto = handler.GetPhaseCreationDto(phase, Datafields.ToList(), SelectedUsers);
                if (dto != null)
                {
                    Phases.Add(phase);
                    return dto;
                }
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        //Study Creation
        /// <summary>
        ///     Submits a created study to server.
        /// </summary>
        public bool SubmitStudy()
        {
            var toSend = new Study()
            {
                Name = _name,
                Description = _description,
                Users = SelectedUsers,
                Datafields = Datafields,
                Phases = Phases,
                ExclusioCriteria = ExclusionCriteria,
                InclusionCriteria = InclusionCriteria,
                ResourceFile = _loadedFile
            };
            var handler = new StudyHandler();
            return handler.SendStudy(toSend);
        }
    }
}