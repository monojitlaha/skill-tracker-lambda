using System.Collections.Generic;

namespace SkillTrackerLambda.Models
{
    // SkillTracker myDeserializedClass = JsonConvert.DeserializeObject<SkillTracker>(myJsonResponse);

    public class SkillTracker
    {
        public int id { get; set; }
        public string value { get; set; }
        public string name { get; set; }
        public string associateId { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public List<TechnicalSkill> technicalSkills { get; set; }
        public List<CommunicationSkill> communicationSkills { get; set; }

        public SkillTracker()
        {
            technicalSkills = new List<TechnicalSkill>();
            communicationSkills = new List<CommunicationSkill>();
        }
    }

    public class TechnicalSkill
    {
        public string description { get; set; }
        public string rating { get; set; }
    }
    public class CommunicationSkill
    {
        public string description { get; set; }
        public string rating { get; set; }
    }
}
