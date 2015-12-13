using System.Collections.Generic;

namespace StudyConfigurationUI.Model.PhaseModels
{
    public class Task
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public IList<User> Users { get; } 
        public IList<Datafield> Datafields { get;}

        public Task()
        {
            Users = new List<User>();
            Datafields = new List<Datafield>();
        } 
    }
}