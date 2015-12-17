// DatafieldHandler.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using StudyConfigurationUI.Model.PhaseModels;

#endregion

namespace StudyConfigurationUI.Model.Handlers
{
    /// <summary>
    ///     This class is responsible for handling datafield operations
    /// </summary>
    public class DatafieldHandler
    {
        public Datafield CreateCustomDatafield(string name, string description, string type, string value)
        {
            var customDatafield = new Datafield()
            {
                Name = name.Trim(),
                Description = description.Trim(),
                Type = type.Trim(),
                FieldData = new[] {value.Trim()}
            };
            if (IsCustomValid(customDatafield)) return customDatafield;
            else throw new ArgumentException("Invalid data entered");
        }

        /// <summary>
        ///     Validates a given datafield and their type.
        /// </summary>
        /// <param name="datafield"></param>
        /// <returns>validation of datafield</returns>
        private bool IsCustomValid(Datafield datafield)
        {
            switch (datafield.Type)
            {
                case null:
                    return false;
                case "string":
                    return true;
                case "boolean":
                    return datafield.FieldData[0] == "true" || datafield.FieldData[0] == "false";
                default:
                    return false;
            }
        }
    }
}