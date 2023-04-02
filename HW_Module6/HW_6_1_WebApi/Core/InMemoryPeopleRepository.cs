using HW_6_1_WebApi.Models;

namespace HW_6_1_WebApi.Core
{
    public sealed class InMemoryPeopleRepository : IPeopleRepository //не смог назвать класс и интерфейс как в задании из-за точки
    {
        //Predefined people
        private readonly List<Human> _people = new List<Human>
        {
            new Human
            {
                Name = "Ihor",
                Surname = "Arkhypenko",
                Age = 22
            },

            new Human
            {
                Name = "Hanna",
                Surname = "Martyfliak",
                Age = 22
            }
        };

        public Task<Human[]> GetPeopleAsync()
        {
            return Task.FromResult(_people.ToArray());
        }

        public Task CreateHumanAsync(Human human)
        {
            _people.Add(human);
            return Task.CompletedTask;
        }

        public Task DeleteHumanAsync(string name)
        {
            var index = _people.FindIndex(x => x.Name == name);
            if (index == -1)
            {
                return Task.CompletedTask;
            }
            _people.RemoveAt(index);

            return Task.CompletedTask;
        }

        public Task UpdateHumanAsync(string name, Human human)
        {
            var index = _people.FindIndex(x => x.Name == name);

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
