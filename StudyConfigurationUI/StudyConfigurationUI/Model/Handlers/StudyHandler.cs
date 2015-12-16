// StudyHandler.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.Linq;
using StudyConfigurationUI.Model.StudyModels;
using StudyConfigurationUI.Model.WebAPI;

#endregion

namespace StudyConfigurationUI.Model.Handlers
{
    public class StudyHandler
    {
        /// <summary>
        ///     Validates a study and sends it to server
        /// </summary>
        /// <param name="studyToSend"> Study that are to be send</param>
        /// <returns>bool if validation was successful</returns>
        public bool SendStudy(Study studyToSend)
        {
            var webHandler = new WebApiHandler();
            if (IsCriteriaValid(studyToSend) &&
                IsDatafieldsValid(studyToSend) &&
                IsNameDescriptionValid(studyToSend) &&
                IsPhasesValid(studyToSend) &&
                IsResourceFileValid(studyToSend) &&
                IsUsersValid(studyToSend))
            {
                webHandler.SendStudy(studyToSend);
                return true;
            }
            return false;
        }

        private bool IsNameDescriptionValid(Study study)
        {
            return (!string.IsNullOrWhiteSpace(study.Name) && !string.IsNullOrWhiteSpace(study.Description));
        }

        private bool IsUsersValid(Study study)
        {
            if (study.Users.Count == 0) return false;
            return
                study.Users.All(
                    user =>
                        !string.IsNullOrWhiteSpace(user.Name) || !string.IsNullOrWhiteSpace(user.Description) ||
                        user.Id >= 0);
        }

        private bool IsDatafieldsValid(Study study)
        {
            return study.Datafields.Count > 0;
        }

        private bool IsPhasesValid(Study study)
        {
            return study.Phases.Count > 0;
        }

        private bool IsCriteriaValid(Study study)
        {
            return study.ExclusioCriteria.Count > 0 && study.InclusionCriteria.Count > 0;
        }

        private bool IsResourceFileValid(Study study)
        {
            return !string.IsNullOrWhiteSpace(study.ResourceFile);
        }
    }
}