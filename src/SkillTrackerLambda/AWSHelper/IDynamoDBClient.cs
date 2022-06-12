using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using SkillTrackerLambda.Models;

namespace SkillTrackerLambda.Repository
{
    public interface IDynamoDBClient
    {
        Task<List<Profile>> GetAsync(List<ScanCondition> conditionsn);

        Task<bool> DeleteAsync(Profile profile);

        Task<bool> SaveAsync(Profile profile);
    }
}
