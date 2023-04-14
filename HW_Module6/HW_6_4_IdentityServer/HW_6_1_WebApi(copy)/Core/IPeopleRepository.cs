using HW_6_1_WebApi.Models;

namespace HW_6_1_WebApi.Core
{
    public interface IPeopleRepository
    {
        public Task<Human[]> GetPeopleAsync();
        public Task<Human> GetHumanAsync(int passport);
        public Task CreateHumanAsync(Human human);
        public Task DeleteHumanAsync(int name);
        public Task UpdateHumanAsync(int passport, Human human);
    }
}
