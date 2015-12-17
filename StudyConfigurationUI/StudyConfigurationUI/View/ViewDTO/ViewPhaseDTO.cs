// ViewPhaseDto.cs is a part of Autosys project in BDSA-2015. Created: 17, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.Collections.Generic;
using StudyConfigurationUI.Model.PhaseModels;

#endregion

namespace StudyConfigurationUI.View.ViewDTO
{
    /// <summary>
    ///     This class is used to transfer information from view
    /// </summary>
    public class ViewPhaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<PhaseMember> Members { get; set; }
        public IList<Datafield> VisibleDatafields { get; set; }
        public IList<Datafield> RequestedDatafields { get; set; }
    }
}