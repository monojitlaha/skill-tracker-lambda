using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SkillTrackerLambda.Models;

namespace SkillTrackerLambda.Repository
{
    public class DynamoDBClient : IDynamoDBClient
    {
        private readonly IDynamoDBContext _dynamoDbContext;
        public DynamoDBClient(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext; 
        }

        /// <summary>
        /// Get Profiles by condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<List<Profile>> GetAsync(List<ScanCondition> condition)
        {
            return await _dynamoDbContext.ScanAsync<Profile>(condition).GetRemainingAsync();
        }

        public async Task<bool> SaveAsync(Profile profile)
        {
            await _dynamoDbContext.SaveAsync(profile);
            return true;
        }


        public async Task<bool> DeleteAsync(Profile profile)
        {
            await _dynamoDbContext.DeleteAsync(profile);
            return true;
        }
    }
}
