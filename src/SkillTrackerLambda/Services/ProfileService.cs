using System;
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

        public Task<List<Profile>> GetAllAsync()
        {
            return _dynamoDBClient.GetAsync(new List<ScanCondition>());
        }

        public async Task<List<Profile>> GetAsync(string criteria, string criteriaValue)
        {
            List<ScanCondition> scanConditions = new List<ScanCondition>();

            switch (criteria)
            {

                case "associateId":
                    scanConditions.Add(new ScanCondition("associateId", ScanOperator.Equal, criteriaValue));
                    break;
                case "email":
                    scanConditions.Add(new ScanCondition("email", ScanOperator.Equal, criteriaValue));
                    break;
                case "mobile":
                    scanConditions.Add(new ScanCondition("mobile", ScanOperator.Equal, criteriaValue));
                    break;
                case "name":
                    scanConditions.Add(new ScanCondition("name", ScanOperator.Equal, criteriaValue));
                    break;
                default:
                    scanConditions.Add(new ScanCondition("id", ScanOperator.Equal, criteriaValue));
                    break;
            }

            return await _dynamoDBClient.GetAsync(scanConditions);
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return await _dynamoDBClient.DeleteAsync(new Profile { id = id });
        }

        public async Task<bool> UpdateAsync(string id, Profile profile)
        {
            profile.id = id;
            return await _dynamoDBClient.SaveAsync(profile);
        }

        public async Task<bool> CreateAsync(Profile profile)
        {
            profile.id = Guid.NewGuid().ToString();
            return await _dynamoDBClient.SaveAsync(profile);
        }

    }
}

