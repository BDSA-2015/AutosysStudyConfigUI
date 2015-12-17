// PhaseCreationDto.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.Collections.Generic;

#endregion

namespace StudyConfigurationUI.Model.PhaseModels
{
    /// <summary>
    ///     This class is used to transfer data between studycreation and phasecreation that are to be
    ///     used when creating a phase.
    /// </summary>
    public class PhaseCreationDto
    {
        public Phase Phase { get; set; }
        public IList<PhaseMember> Members { get; set; }
        public IList<Datafield> Datafields { get; set; }
    }
}