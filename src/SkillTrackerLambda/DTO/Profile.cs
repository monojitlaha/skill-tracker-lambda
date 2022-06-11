using System.Collections.Generic;

namespace SkillTrackerLambda.Models
{
    public class Profile
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string AssociateId { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public List<Skill> TechnicalSkills { get; set; }

        public List<Skill> CommunicationSkills { get; set; }
    }
}
