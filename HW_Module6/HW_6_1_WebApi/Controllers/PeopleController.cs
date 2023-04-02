using HW_6_1_WebApi.Core;
using HW_6_1_WebApi.Models;
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

        [HttpGet]
        public async Task<Human[]> GetPeopleAsync()
        {
            _logger.LogInformation("GetPeopleAsync is executed");
            return await _peopleRepository.GetPeopleAsync();
        }

        [HttpPost]
        public async Task CreateHumanAsync([FromBody] Human human)
        {
            await _peopleRepository.CreateHumanAsync(human);
        }

        [HttpDelete("{name}")]
        public async Task DeleteHumanAsync(string name)
        {
            await _peopleRepository.DeleteHumanAsync(name);
        }

        [HttpPut("{name}")]
        public async Task UpdateHumanAsync(string name, Human human)
        {
            await _peopleRepository.UpdateHumanAsync(name, human);
        }
    }
}