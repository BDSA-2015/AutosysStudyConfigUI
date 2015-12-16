// ApiHandler.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.Model.StudyModels;

namespace StudyConfigurationUI.Model.WebAPI
{
    /// <summary>
    /// This class is responsible for handling communication beween server and gui
    /// </summary>
    public class WebApiHandler
    {
        /// <summary>
        /// Sends a study to server
        /// </summary>
        /// <param name="studyToSend"></param>
        /// <returns>Task</returns>
        public async Task SendStudy(Study studyToSend)
        {
            var JSON = JsonConvert.SerializeObject(studyToSend);
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets all datafields from resource file
        /// Server will parse the file and return the results
        /// </summary>
        /// <param name="resourceFile">File as string</param>
        /// <returns>List of Datafields</returns>
        public async Task<IList<Datafield>>GetDatafields(string resourceFile)
        {
            var JSON = JsonConvert.SerializeObject(resourceFile);
           throw new System.NotImplementedException();

        }

        /// <summary>
        /// Gets all stored user from database
        /// </summary>
        /// <returns>List of users</returns>
        public Task<IList<User>> GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}