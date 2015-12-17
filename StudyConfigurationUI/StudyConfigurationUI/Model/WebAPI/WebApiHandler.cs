// WebApiHandler.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.Model.StudyModels;

#endregion

namespace StudyConfigurationUI.Model.WebAPI
{
    /// <summary>
    ///     This class is responsible for handling communication beween server and gui
    /// </summary>
    public class WebApiHandler
    {
        public WebApiHandler()
        {
        }


        /// <summary>
        ///     Sends a study to server
        /// </summary>
        /// <param name="studyToSend"></param>
        /// <returns>Task</returns>
        public async Task<bool> SendStudy(Study studyToSend)
        {
            var JSON = JsonConvert.SerializeObject(studyToSend);
            //var request = (HttpWebRequest)WebRequest.Create(new Uri("http://localhost:11813/api/study"));
            //request.Method = "POST";
            //request.ContentType = "text/json";

            //using (var writer = new StreamWriter(await request.GetRequestStreamAsync()))
            //{
            //    writer.Write(JSON);
            //    writer.Flush();
            //};

            //var httpResponse = await request.GetResponseAsync();

            //using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = await reader.ReadToEndAsync();
            //}
            return true;
        }

        /// <summary>
        ///     Gets all datafields from resource file
        ///     Server will parse the file and return the results
        /// </summary>
        /// <param name="resourceFile">File as string</param>
        /// <returns>List of Datafields</returns>
        public async Task<IList<Datafield>> GetDatafields(string resourceFile)
        {
            var JSON = JsonConvert.SerializeObject(resourceFile);

            //var request = (HttpWebRequest)WebRequest.Create(new Uri("http://localhost:11813/api/bibtex"));
            //request.Method = "POST";
            //request.ContentType = "text/json";

            //using (var writer = new StreamWriter(await request.GetRequestStreamAsync()))
            //{
            //    writer.Write(JSON);
            //    writer.Flush();
            //};

            //var httpResponse = await request.GetResponseAsync();
            //using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = await reader.ReadToEndAsync();
            //    var tags = JsonConvert.DeserializeObject<IEnumerable<BibtexTag>>(result);
            //    var datafields = tags.Select(tag => new Datafield() { Name = tag.Type, Type = "predifined" }).ToList();
            //    return datafields;
            //}

            return new List<Datafield>()
            {
                new Datafield() {Name = "Author", Type = "predefined"},
                new Datafield() {Name = "Title", Type = "predefined"},
                new Datafield() {Name = "Year", Type = "predefined"},
            };
        }


        /// <summary>
        ///     Gets all stored user from database
        /// </summary>
        /// <returns>List of users</returns>
        public async Task<IList<User>> GetUsers()
        {
            //var request = (HttpWebRequest)WebRequest.Create(new Uri("http://localhost:11813/api/user"));
            //request.Method = "GET";
            //request.ContentType = "text/json";

            //var response = (HttpWebResponse)await request.GetResponseAsync();
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{
            //    var result = await reader.ReadToEndAsync();
            //    var users = JsonConvert.DeserializeObject<IEnumerable<User>>(result);
            //    return users.ToList();
            //}

            return new List<User>()
            {
                new User() {Name = "John Doe", Metadata = "The husband"},
                new User() {Name = "Jane Doe", Metadata = "The wife"},
                new User() {Name = "Steven", Metadata = "The coder"},
                new User() {Name = "Paolo", Metadata = "The god"}
            };
        }

        /// <summary>
        ///  Retrives existing studies from server
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Study>> GetExistingStudies()
        {
            throw new NotImplementedException();
        }
    }
}