using HW_6_1_WebApi.Models;

namespace HW_6_1_WebApi.Core
{
    public interface IPeopleRepository
    {
        public Task<Human[]> GetPeopleAsync();
        public Task CreateHumanAsync(Human human);
        public Task DeleteHumanAsync(string name);
        public Task UpdateHumanAsync(string name, Human human);
    }
}
