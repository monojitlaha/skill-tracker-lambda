using System.Collections.Generic;

namespace SkillTrackerLambda.DTO
{
    public class Profile
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string AssociateId { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public List<Skill> TechnicalSkills { get; set; }

        public List<Skill> CommunicationSkills { get; set; }
    }
}
