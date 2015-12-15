using System.Collections.Generic;

namespace StudyConfigurationUI.Model.PhaseModels
{
    public class Phase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<PhaseMember> PhaseMembers { get; set; }
        public IList<Datafield> VisibleDataField { get; set; }
        public IList<Datafield> RequestedDatafield { get; set; }

    }
}