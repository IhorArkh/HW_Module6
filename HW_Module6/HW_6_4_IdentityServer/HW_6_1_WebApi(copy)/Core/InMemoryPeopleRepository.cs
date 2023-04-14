using HW_6_1_WebApi.Models;

namespace HW_6_1_WebApi.Core
{
    public sealed class InMemoryPeopleRepository : IPeopleRepository
    {
        //Predefined people
        private readonly List<Human> _people = new List<Human>
        {
            new Human
            {
                Passport = 101010,
                Name = "Ihor",
                Age = 22
            },

            new Human
            {
                Passport = 111111,
                Name = "Hanna",
                Age = 22
            },

            new Human
            {
                Passport = 121212,
                Name = "Vlad",
                Age = 22
            }
        };

        public Task<Human[]> GetPeopleAsync()
        {
            return Task.FromResult(_people.ToArray());
        }

        public Task<Human> GetHumanAsync(int passport)
        {
            return Task.FromResult(_people.FirstOrDefault(h => h.Passport == passport));
        }

        public Task CreateHumanAsync(Human human)
        {
            _people.Add(human);
            return Task.CompletedTask;
        }

        public Task DeleteHumanAsync(int passport)
        {
            var index = _people.FindIndex(x => x.Passport == passport);
            if (index == -1)
            {
                return Task.CompletedTask;
            }
            _people.RemoveAt(index);

            return Task.CompletedTask;
        }

        public Task UpdateHumanAsync(int passport, Human human)
        {
            var index = _people.FindIndex(x => x.Passport == passport);

            if (index == -1)
            {
                return Task.CompletedTask;
            }
            _people.RemoveAt(index);
            _people.Add(human);

            return Task.CompletedTask;

        }
    }
}
