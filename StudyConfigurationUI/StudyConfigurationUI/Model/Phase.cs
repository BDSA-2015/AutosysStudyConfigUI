using System.Collections.Generic;

namespace StudyConfigurationUI.Model
{
    public class Phase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] TeamIds { get; set; }

        /// <summary>
        /// Role id with list of users.
        /// </summary>
        public Dictionary<int,int[]> Roles { get; set; }

    }
}