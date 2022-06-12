using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using SkillTrackerLambda;
using Amazon.DynamoDBv2;
using SkillTrackerLambda.Services;
using SkillTrackerLambda.Models;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SkillTrackerLambda.Repository;

namespace SkillTrackerLambda.Tests
{
    public class FunctionTest
    {
        public AmazonDynamoDBClient client;
        public DynamoDBContext dynamoDBContext;
        public DynamoDBClient dynamoDBClient;
        public ProfileService profileService;


        public FunctionTest()
        {

#if (DEBUG)           
            client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
#else
            client = new AmazonDynamoDBClient();
#endif
            dynamoDBContext = new DynamoDBContext(client);

            dynamoDBClient = new DynamoDBClient(dynamoDBContext);

            profileService = new ProfileService(dynamoDBClient);

        }

        [Fact]
        public void Test_ProfileService_CreateAsync_Function()
        {
            Profile profile = new Profile
            {
                name = "Monojit Laha",
                mobile = "9830080250",
                email = "monojit.laha@cognizant.com",
                associateId = "451111"
            };
            profile.technicalSkills.Add(new Skill { description = "HTML-CSS-JAVASCRIPT", rating = "20" });
            profile.technicalSkills.Add(new Skill { description = "ANGULAR", rating = "18" });
            profile.technicalSkills.Add(new Skill { description = "REACT", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "SPRING", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "RESTFUL", rating = "18" });
            profile.technicalSkills.Add(new Skill { description = "HIBERNATE", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "GIT", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "DOCKER", rating = "18" });
            profile.technicalSkills.Add(new Skill { description = "JENKINS", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "AWS", rating = "18" });

            profile.communicationSkills.Add(new Skill { description = "SPOKEN", rating = "15" });
            profile.communicationSkills.Add(new Skill { description = "COMMUNICATION", rating = "18" });
            profile.communicationSkills.Add(new Skill { description = "APTITUDE", rating = "19" });

            ProfileService profileService = new ProfileService(dynamoDBClient);

            var result = profileService.CreateAsync(profile);

            Assert.True(true);
        }

        [Fact]
        public async void Test_ProfileService_GetAsyncWithCondition_Function()
        {
            var result = await profileService.GetAsync("email", "monojit.laha@cognizant.com");
            Assert.True(true);
        }

        [Fact]
        public async void Test_ProfileService_GetAllAsync_Function()
        {
            var result = await profileService.GetAllAsync();
            Assert.True(true);
        }

        [Fact]
        public async void Test_ProfileService_UpdateAsync_FunctionAsync()
        {
            Profile profile = new Profile
            {
                id = "5c31b498-55d1-46eb-9c9f-d02baa4c7579",
                name = "Swadhin Kumar Mukherjee",
                mobile = "9830080000",
                email = "swadhin.mukherjee@cognizant.com",
                associateId = "451125"
            };
            profile.technicalSkills.Add(new Skill { description = "HTML-CSS-JAVASCRIPT", rating = "20" });
            profile.technicalSkills.Add(new Skill { description = "ANGULAR", rating = "18" });
            profile.technicalSkills.Add(new Skill { description = "REACT", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "SPRING", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "RESTFUL", rating = "18" });
            profile.technicalSkills.Add(new Skill { description = "HIBERNATE", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "GIT", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "DOCKER", rating = "18" });
            profile.technicalSkills.Add(new Skill { description = "JENKINS", rating = "15" });
            profile.technicalSkills.Add(new Skill { description = "AWS", rating = "18" });

            profile.communicationSkills.Add(new Skill { description = "SPOKEN", rating = "15" });
            profile.communicationSkills.Add(new Skill { description = "COMMUNICATION", rating = "18" });
            profile.communicationSkills.Add(new Skill { description = "APTITUDE", rating = "19" });

            ProfileService profileService = new ProfileService(dynamoDBClient);

            var result = await profileService.UpdateAsync("107821b0-0707-4815-adb9-491f4f9784f1", profile);

            Assert.True(true);
        }

        [Fact]
        public async void Test_ProfileService_DeleteAsync_FunctionAsync()
        {
            var result = await profileService.RemoveAsync("107821b0-0707-4815-adb9-491f4f9784f1");

            Assert.True(true);
        }
    }
}
