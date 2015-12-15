// Member.cs is a part of Autosys project in BDSA-2015. Created: 14, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace StudyConfigurationUI.Model.PhaseModels
{
    /// <summary>
    /// This class represents a member for a given phase in a study
    /// </summary>
    public class PhaseMember
    {
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}