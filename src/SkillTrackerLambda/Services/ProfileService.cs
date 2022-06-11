using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SkillTrackerLambda.DTO;
using SkillTrackerLambda.Repository;

namespace SkillTrackerLambda.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IDynamoDBClient _dynamoDBClient;

        public ProfileService(IDynamoDBClient dynamoDBClient)
        {
            _dynamoDBClient = dynamoDBClient;
        }

        public Task CreateAsync(Profile profile)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Profile>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Profile>> GetAsync(string criteria, string criteriaValue)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(string id, Profile profile)
        {
            throw new System.NotImplementedException();
        }

        //public async Task<List<Profile>> GetAsync() =>
        // await _profiles.Find(Builders<Profile>.Filter.Empty, null).ToListAsync();

        //public async Task<List<Profile>> GetAsync(string criteria, string criteriaValue)
        //{
        //    FilterDefinition<Profile> filter;
        //    if (criteria.Trim().ToLower() == "name")
        //    {
        //        var escapeInput = Regex.Escape(criteriaValue);
        //        var regx = new Regex(escapeInput, RegexOptions.IgnoreCase);
        //        filter = Builders<Profile>.Filter.Regex("Name", BsonRegularExpression.Create(regx));
        //    }
        //    else if (criteria.Trim().ToLower() == "username")
        //    {
        //        filter = Builders<Profile>.Filter.Eq("UserName", criteriaValue);
        //    }
        //    else if (criteria.Trim().ToLower() == "associateid")
        //    {
        //        filter = Builders<Profile>.Filter.Eq("AssociateId", criteriaValue);
        //    }
        //    else if (criteria.Trim().ToLower() == "email")
        //    {
        //        filter = Builders<Profile>.Filter.Eq("Email", criteriaValue);
        //    }
        //    else if (criteria.Trim().ToLower() == "mobile")
        //    {
        //        filter = Builders<Profile>.Filter.Eq("Mobile", criteriaValue);
        //    }
        //    else if (criteria.Trim().ToLower() == "skill")
        //    {
        //        var techSkillsFilter = Builders<Profile>.Filter.ElemMatch(
        //                x => x.TechnicalSkills,
        //                y => y.Description.ToLower() == criteriaValue.ToLower());
        //        var commSkillsFilter = Builders<Profile>.Filter.ElemMatch(
        //                x => x.CommunicationSkills,
        //                y => y.Description.ToLower() == criteriaValue.ToLower());
        //        filter = Builders<Profile>.Filter.Or(techSkillsFilter, commSkillsFilter); 
        //    }
        //    else
        //    {
        //        var objectId = new ObjectId(criteriaValue);
        //        filter = Builders<Profile>.Filter.Eq("_id", objectId);
        //    }
        //    return await _profiles.FindAsync(filter).Result.ToListAsync();
        //}

        //public async Task CreateAsync(Profile profile) =>
        // await _profiles.InsertOneAsync(profile);

        //public async Task UpdateAsync(string id, Profile profile) =>
        // await _profiles.ReplaceOneAsync(x => x.Id == id, profile);

        //public async Task RemoveAsync(string id) =>
        // await _profiles.DeleteOneAsync(x => x.Id == id);
    }
}

