namespace StudyConfigurationUI.Model.PhaseModels
{
    /// <summary>
    /// This class represents a datafield
    /// </summary>
    public class Datafield
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string[] FieldData { get; set; }
    }
}