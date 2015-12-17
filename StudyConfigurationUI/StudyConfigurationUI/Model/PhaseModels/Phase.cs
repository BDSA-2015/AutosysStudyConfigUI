// Phase.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.Collections.Generic;

#endregion

namespace StudyConfigurationUI.Model.PhaseModels
{
    public class Phase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<PhaseMember> PhaseMembers { get; set; }
        public IList<Datafield> VisibleDataField { get; set; }
        public IList<Datafield> RequestedDatafield { get; set; }
    }
}