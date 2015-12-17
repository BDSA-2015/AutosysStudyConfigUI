// ViewCriteriaDto.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace StudyConfigurationUI.View.ViewDTO
{
    /// <summary>
    /// This class is to transfer criteria information from view
    /// </summary>
    public class ViewCriteriaDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FieldTag { get; set; }
        public string Comparator { get; set; }
        public string Value { get; set; }
    }
}