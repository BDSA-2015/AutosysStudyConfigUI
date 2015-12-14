using System.Collections.Generic;

namespace StudyConfigurationUI.Model.PhaseModels
{
    public class Phase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] TeamIds { get; set; }
        public IList<Datafield> Datafields { get; set; } 

        /// <summary>
        /// List of members and their roles.
        /// </summary>
        public Dictionary<int,Member[]> Members { get; set; }

    }
}