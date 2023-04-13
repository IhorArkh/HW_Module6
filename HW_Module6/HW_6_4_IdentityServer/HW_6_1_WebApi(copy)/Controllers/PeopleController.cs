using HW_6_1_WebApi.Core;
using HW_6_1_WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HW_6_1_WebApi.Controllers
{
    [ApiController]
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(
            ILogger<PeopleController> logger,
            IPeopleRepository peopleRepository)
        {
            _logger = logger;
            _peopleRepository = peopleRepository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "DefaultUser, Admin")]
        [HttpGet]
        public async Task<Human[]> GetPeopleAsync()
        {
            _logger.LogInformation("GetPeopleAsync is executed");
            return await _peopleRepository.GetPeopleAsync();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "DefaultUser, Admin")]
        [HttpGet("{passport}")]
        public async Task<Human> GetHumanAsync(int passport)
        {
            return await _peopleRepository.GetHumanAsync(passport);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task CreateHumanAsync([FromBody] Human human)
        {
            await _peopleRepository.CreateHumanAsync(human);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{passport}")]
        public async Task DeleteHumanAsync(int passport)
        {
            await _peopleRepository.DeleteHumanAsync(passport);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("{passport}")]
        public async Task UpdateHumanAsync(int passport, Human human)
        {
            await _peopleRepository.UpdateHumanAsync(passport, human);
        }
    }
}