// StudyHandler.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Linq;
using StudyConfigurationUI.Model.StudyModels;

namespace StudyConfigurationUI.Model.Handlers
{
    public class StudyHandler
    {
        public bool SendStudy(Study studyToSend)
        {

        }

        private bool IsNameDescriptionValid(Study study)
        {
            return (!string.IsNullOrWhiteSpace(study.Name) && !string.IsNullOrWhiteSpace(study.Description));
        }

        private bool IsUsersValid(Study study)
        {
            if (study.Users.Count == 0) return false;
            return study.Users.All(user => !string.IsNullOrWhiteSpace(user.Name) || !string.IsNullOrWhiteSpace(user.Description) || user.Id >= 0);
        }

        private bool IsDatafieldsValid(Study study)
        {
            
        }

        private bool IsPhasesValid(Study study)
        {
            
        }

        private bool IsCriteriaValid(Study study)
        {
            
        }

        private bool IsResourceFileValid(Study study)
    }
}