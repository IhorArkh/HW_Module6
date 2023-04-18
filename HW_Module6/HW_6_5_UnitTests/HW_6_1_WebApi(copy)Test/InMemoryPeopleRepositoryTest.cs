using HW_6_1_WebApi.Core;
using HW_6_1_WebApi.Models;
using System.Diagnostics.Contracts;
using System.Runtime.ExceptionServices;

namespace HW_6_1_WebApi_copy_Test
{
    public class InMemoryPeopleRepositoryTest
    {
        [Fact]
        public async void GetPeopleAsync_ShouldReturnExpectedPeople()
        {
            //Arrange
            var expectedPeople = new[]
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

            //Act
            var repository = new InMemoryPeopleRepository();

            var actualPeople = await repository.GetPeopleAsync();

            //Assert
            Assert.Equal(expectedPeople.Length, actualPeople.Length);

            var counter = 0;
            foreach (var human in expectedPeople)
            {
                var x = actualPeople.ElementAt(counter);

                Assert.True(human.Name == actualPeople.ElementAt(counter).Name &&
                    human.Age == actualPeople.ElementAt(counter).Age &&
                    human.Passport == actualPeople.ElementAt(counter).Passport);

                counter++;
            }
            //такое "интересное" решение потому, что при сравнении объектов всегда выходит False, хоть они и одинаковые
        }


        [Theory]
        [InlineData(101010)]
        public async void GetHumanAsync_ShouldReturnCorrectHuman(int passport)
        {
            //Arrange
            var expectedHuman = new Human
            {
                Passport = 101010,
                Name = "Ihor",
                Age = 22
            };

            //Act
            var repository = new InMemoryPeopleRepository();

            var result = await repository.GetHumanAsync(passport);

            //Assert
            Assert.True(expectedHuman.Name == result.Name &&
                expectedHuman.Passport == result.Passport && expectedHuman.Age == result.Age);
        }


        [Theory]
        [InlineData(554411)]
        public async void GetHumanAsync_WithUnexistingPassport(int passport)
        {
            //Arrange
            Human expectedResult = null;

            //Act
            var repository = new InMemoryPeopleRepository();

            var result = await repository.GetHumanAsync(passport);

            //Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData (4, 1)]
        [InlineData(5, 2)]
        [InlineData(6, 3)]
        public async void CreateHumanAsync_ShouldCreateHumanInMemoryRepositoryAndExpectedLengthSholdMatch(int expectedLength, int count)
        {
            //Arrange
            var newHuman = new Human() { Age = 20, Name = "QWE", Passport = 111};

            //Act
            var repository = new InMemoryPeopleRepository();

            for (int i = 0; i < count; i++)
            {
                await repository.CreateHumanAsync(newHuman);
            }

            var actualPeople = await repository.GetPeopleAsync();

            //Assert
            Assert.Equal(expectedLength, actualPeople.Length);
            Assert.Equal(newHuman.Passport, actualPeople.Last().Passport);
        }

        [Theory]
        [InlineData(101010)]
        [InlineData(121212)]
        public async void DeleteHumanAsync_ShouldDeleteHuman(int passport)
        {
            //Arrange
            
            //Act
            var repository = new InMemoryPeopleRepository();

            var result = await repository.DeleteHumanAsync(passport);

            var deletedHuman = await repository.GetHumanAsync(passport);

            //Assert
            Assert.Equal(null, deletedHuman);
            Assert.True(result == 1);
        }


        [Theory]
        [InlineData(1234)]
        public async void DeleteHumanAsync_DeletingUnexistingHuman(int passport)
        {
            //Arrange
            var expectedResult = -1;

            //Act
            var repository = new InMemoryPeopleRepository();

            var result = await repository.DeleteHumanAsync(passport);

            var human = await repository.GetHumanAsync(passport);

            //Assert
            Assert.Equal(expectedResult, result);
            Assert.True(human == null);
        }


        [Theory]
        [InlineData(101010)]
        [InlineData(121212)]
        public async void UpdateHumanAsync_ShouldUpdateHuman(int passport)
        {
            //Arrange
            var human = new Human() { Name = "Updated", Age = 10, Passport = 101211};

            //Act
            var repository = new InMemoryPeopleRepository();

            var result = await repository.UpdateHumanAsync(passport, human);

            var humanAfterUpdate = await repository.GetHumanAsync(human.Passport);

            //Assert
            Assert.Equal(1, result);
            Assert.Equal(human, humanAfterUpdate);
        }


        [Theory]
        [InlineData(554422)]
        [InlineData(554411)]
        public async void UpdateHumanAsync_UpdatingUnexistingHuman(int passport)
        {
            //Arrange
            var human = new Human() { Name = "Updated", Age = 10, Passport = 101211 };

            //Act
            var repository = new InMemoryPeopleRepository();

            var result = await repository.UpdateHumanAsync(passport, human);

            //Assert
            Assert.Equal(-1, result);
        }
    }
}