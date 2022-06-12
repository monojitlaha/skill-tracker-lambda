using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
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
        /// Get all Profile records
        /// </summary>
        /// <returns></returns>
        public async Task<List<Profile>> GetAsync()
        {
            return await _dynamoDbContext.ScanAsync<Profile>(new List<ScanCondition>() { }).GetRemainingAsync();
        }

        /// <summary>
        /// Get Profiles by condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<List<Profile>> GetWithScanConditionAsync(ScanCondition condition)
        {
            return await _dynamoDbContext.ScanAsync<Profile>(new List<ScanCondition>() { condition }).GetRemainingAsync();
        }
    }
}
