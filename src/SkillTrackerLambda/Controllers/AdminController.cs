using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillTrackerLambda.Models;
using SkillTrackerLambda.Services;

namespace SkillTrackerLambda.Controllers
{
    [Route("/api/profiles/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger, IProfileService profileService)
        {
            _logger = logger;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Invoking GET method");
                var result = await _profileService.GetAllAsync();
                if (result == null || !result.Any())
                    return NotFound();
                _logger.LogInformation("Receieved Search Result Successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in get-profile:{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{criteria}/{criteriaValue}")]
        public async Task<ActionResult<List<Profile>>> Get(string criteria, string criteriaValue)
        {
            if (string.IsNullOrWhiteSpace(criteria) || string.IsNullOrWhiteSpace(criteriaValue))
            {
                _logger.LogInformation("AdminController Index executed at {date}", DateTime.UtcNow);
                _logger.LogInformation("Input Parameter is not valid");
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("Invoking GET method by passing Search Criteria");
                var profiles = await _profileService.GetAsync(criteria, criteriaValue);

                _logger.LogInformation("Receieved Search Result Successfully");
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in get-profile-by-criteria:{ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
