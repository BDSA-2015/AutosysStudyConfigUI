// CriteriaHandler.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Globalization;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.View.ViewDTO;

#endregion

namespace StudyConfigurationUI.Model.Handlers
{
    /// <summary>
    ///     This class is responsible for handling criterias
    /// </summary>
    public class CriteriaHandler
    {
        /// <summary>
        ///     Returns a criteria to be used
        /// </summary>
        /// <param name="dto">dto with criteria info</param>
        /// <returns>Criteria object</returns>
        public Criteria CreateCriteria(ViewCriteriaDto dto)
        {
            var criteria = new Criteria()
            {
                Name = dto.Name,
                Description = dto.Description,
                FieldTag = dto.FieldTag,
                Value = dto.Value.Trim()
            };

            switch (dto.Comparator.Trim().ToLower())
            {
                case "lessthan":
                    criteria.Comparator = "<";
                    break;
                case "greaterthan":
                    criteria.Comparator = ">";
                    break;
                case "equal":
                    criteria.Comparator = "=";
                    break;
                case "contains":
                    criteria.Comparator = "contains";
                    break;
                default:
                    throw new ArgumentException("Invalid comparator");
            }

            if (IsCriteriaValid(criteria))
            {
                return criteria;
            }
            else throw new ArgumentException("Invalid Value");
        }

        private bool IsCriteriaValid(Criteria criteria)
        {
            if (criteria.Comparator == "<" || criteria.Comparator == ">")
            {
                return IsNumeric(criteria.Value);
            }
            else return true;
        }


        /// <summary>
        ///     Used to check if string contains only numbers.
        ///     Taken from http://stackoverflow.com/questions/894263/how-to-identify-if-a-string-is-a-number
        ///     Written by Nelson Miranda
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private bool IsNumeric(string expression)
        {
            double retNum;
            bool isNum = double.TryParse(Convert.ToString(expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo,
                out retNum);
            return isNum;
        }
    }
}