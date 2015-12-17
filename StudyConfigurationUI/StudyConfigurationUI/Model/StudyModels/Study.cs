// Study.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.Collections.Generic;
using StudyConfigurationUI.Model.PhaseModels;

#endregion

namespace StudyConfigurationUI.Model.StudyModels
{
    /// <summary>
    ///     This class represents a full study
    /// </summary>
    public class Study
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Datafield> Datafields { get; set; }
        public IList<Phase> Phases { get; set; }
        public IList<Criteria> ExclusioCriteria { get; set; }
        public IList<Criteria> InclusionCriteria { get; set; }
        public IList<User> Users { get; set; }

        public string ResourceFile { get; set; }
    }
}