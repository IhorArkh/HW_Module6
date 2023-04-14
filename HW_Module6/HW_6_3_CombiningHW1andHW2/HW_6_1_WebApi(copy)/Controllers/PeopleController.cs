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

        [HttpGet("{passport}")]
        public async Task<Human> GetHumanAsync(int passport)
        {
            return await _peopleRepository.GetHumanAsync(passport);
        }

        [HttpPost]
        public async Task CreateHumanAsync([FromBody] Human human)
        {
            await _peopleRepository.CreateHumanAsync(human);
        }

        [HttpDelete("{passport}")]
        public async Task DeleteHumanAsync(int passport)
        {
            await _peopleRepository.DeleteHumanAsync(passport);
        }

        [HttpPut("{passport}")]
        public async Task UpdateHumanAsync(int passport, Human human)
        {
            await _peopleRepository.UpdateHumanAsync(passport, human);
        }
    }
}