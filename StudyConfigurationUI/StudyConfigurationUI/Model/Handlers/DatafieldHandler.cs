// DatafieldHandler.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using StudyConfigurationUI.Model.PhaseModels;

namespace StudyConfigurationUI.Model.Handlers
{
    public class DatafieldHandler
    {
        public Datafield CreateCustomDatafield(string name, string description, string type, string value)
        {
            var customDatafield = new Datafield()
            {
                Name = name.Trim(),
                Description = description.Trim(),
                Type = type.Trim(),
                FieldData = new[] { value.Trim() }
                
            };
            if (IsCustomValid(customDatafield)) return customDatafield;
            else throw new ArgumentException("Invalid data entered");
        }

        private bool IsCustomValid(Datafield datafield)
        {
            if (datafield.Type == null) return false;
            if (datafield.Type == "string") return true;
            else return datafield.Type == "boolean" && (datafield.FieldData[0] == "true" || datafield.FieldData[0] == "false");
        }
    }
}