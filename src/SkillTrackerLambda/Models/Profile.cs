using System.Collections.Generic;

namespace SkillTrackerLambda.Models
{
    // SkillTracker myDeserializedClass = JsonConvert.DeserializeObject<SkillTracker>(myJsonResponse);

    public class Profile
    {
        public string username { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string associateId { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public List<Skill> technicalSkills { get; set; }
        public List<Skill> communicationSkills { get; set; }

        public Profile()
        {
            technicalSkills = new List<Skill>();
            communicationSkills = new List<Skill>();
        }
    }

    public class Skill
    {
        public string description { get; set; }
        public string rating { get; set; }
    }
}
