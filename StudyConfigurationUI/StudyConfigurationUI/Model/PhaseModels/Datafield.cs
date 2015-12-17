// Datafield.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace StudyConfigurationUI.Model.PhaseModels
{
    /// <summary>
    ///     This class represents a datafield
    /// </summary>
    public class Datafield
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string[] FieldData { get; set; }
    }
}