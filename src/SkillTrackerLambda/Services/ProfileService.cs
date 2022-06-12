using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SkillTrackerLambda.Models;
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
            return _dynamoDBClient.GetAsync();
        }

        public async Task<List<Profile>> GetAsync(string criteria, string criteriaValue)
        {
            ScanCondition condition = null;
            if (criteria.Trim().ToLower() == "name")
            {
                condition = new ScanCondition("name", ScanOperator.Equal, criteriaValue);
            }
            else if (criteria.Trim().ToLower() == "username")
            {
                condition = new ScanCondition("username", ScanOperator.Equal, criteriaValue);
            }
            else if (criteria.Trim().ToLower() == "associateid")
            {
                condition = new ScanCondition("associateid", ScanOperator.Equal, criteriaValue);
            }
            else if (criteria.Trim().ToLower() == "email")
            {
                condition = new ScanCondition("email", ScanOperator.Equal, criteriaValue);
            }
            else if (criteria.Trim().ToLower() == "mobile")
            {
                condition = new ScanCondition("mobile", ScanOperator.Equal, criteriaValue);
            }
            //else if (criteria.Trim().ToLower() == "skill")
            //{
            //    condition = new ScanCondition("technicalSkills.Description", ScanOperator.Contains, criteriaValue);
            //}
            else
            {
                condition = new ScanCondition("id", ScanOperator.Equal, criteriaValue);
            }
            return await _dynamoDBClient.GetWithScanConditionAsync(condition); 
        }

        public Task RemoveAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(string id, Profile profile)
        {
            throw new System.NotImplementedException();
        } 

        //public async Task CreateAsync(Profile profile) =>
        // await _profiles.InsertOneAsync(profile);

        //public async Task UpdateAsync(string id, Profile profile) =>
        // await _profiles.ReplaceOneAsync(x => x.Id == id, profile);

        //public async Task RemoveAsync(string id) =>
        // await _profiles.DeleteOneAsync(x => x.Id == id);
    }
}

