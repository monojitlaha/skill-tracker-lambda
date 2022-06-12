using System.Collections.Generic;
using System.Threading.Tasks;
using SkillTrackerLambda.Models;

namespace SkillTrackerLambda.Services
{
    public interface IProfileService
    {
        Task<List<Profile>> GetAllAsync();
        Task<List<Profile>> GetAsync(string criteria, string criteriaValue);
        Task<bool> CreateAsync(Profile profile);
        Task<bool> UpdateAsync(string id, Profile profile);
        Task<bool> RemoveAsync(string id);
    }
}
