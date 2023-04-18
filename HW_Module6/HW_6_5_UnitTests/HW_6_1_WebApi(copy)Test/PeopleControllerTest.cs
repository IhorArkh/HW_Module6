using HW_6_1_WebApi.Controllers;
using HW_6_1_WebApi.Core;
using HW_6_1_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_6_1_WebApi_copy_Test
{
    public class PeopleControllerTest
    {
        [Fact]
        public async void GetPeopleAsync_ShouldGetPeopleSuccessfully()
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
                }
            };

            var _peopleRepositoryMock = new Mock<IPeopleRepository>();

            _peopleRepositoryMock.Setup(x => x.GetPeopleAsync()).Returns(Task.FromResult(expectedPeople));

            //Act
            var controller = new PeopleController(_peopleRepositoryMock.Object);

            var result = await controller.GetPeopleAsync();

            //Assert
            Assert.Equal(expectedPeople, result);
            _peopleRepositoryMock.Verify(x => x.GetPeopleAsync(), Times.Once());
        }


        [Fact]
        public async void GetHumanAsync_ShouldGetHumanSuccessfully()
        {
            //Arrange
            var expectedHuman = new Human
            {
                Passport = 101010,
                Name = "Ihor",
                Age = 22
            };

            var _peopleRepositoryMock = new Mock<IPeopleRepository>();

            _peopleRepositoryMock.Setup(x => x.GetHumanAsync(It.IsAny<int>())).Returns(Task.FromResult(expectedHuman));

            //Act
            var controller = new PeopleController(_peopleRepositoryMock.Object);

            var result = await controller.GetHumanAsync(expectedHuman.Passport);

            //Assert
            Assert.Equal(expectedHuman, result);
            _peopleRepositoryMock.Verify(x => x.GetHumanAsync(expectedHuman.Passport), Times.Once());
        }


        [Fact]
        public async void CreateHumanAsync_ShouldCreateHumanSuccessfully()
        {
            //Arrange
            var human = new Human
            {
                Passport = 101010,
                Name = "Ihor",
                Age = 22
            };

            var _peopleRepositoryMock = new Mock<IPeopleRepository>();

            _peopleRepositoryMock.Setup(x => x.CreateHumanAsync(It.IsAny<Human>())).Returns(Task.CompletedTask);

            //Act
            var controller = new PeopleController(_peopleRepositoryMock.Object);

            var result = controller.CreateHumanAsync(human);

            //Assert
            Assert.True(result.IsCompletedSuccessfully);
            _peopleRepositoryMock.Verify(x => x.CreateHumanAsync(human), Times.Once());
        }


        [Fact]
        public async void DeleteHumanAsync_ShouldDeleteHumanSuccessfully()
        {
            //Arrange
            var passport = 112233;

            var _peopleRepositoryMock = new Mock<IPeopleRepository>();

            _peopleRepositoryMock.Setup(x => x.DeleteHumanAsync(It.IsAny<int>())).Returns(Task.FromResult(1));

            //Act
            var controller = new PeopleController(_peopleRepositoryMock.Object);

            var result = controller.DeleteHumanAsync(passport);

            //Assert
            Assert.True(result.IsCompletedSuccessfully);
            _peopleRepositoryMock.Verify(x => x.DeleteHumanAsync(passport), Times.Once());
        }


        [Fact]
        public async void UpdateHumanAsync_ShouldUpdateHumanSuccessfully()
        {
            //Arrange
            var passport = 115511;

            var human = new Human
            {
                Passport = 101010,
                Name = "Ihor",
                Age = 22
            };

            var _peopleRepositoryMock = new Mock<IPeopleRepository>();

            _peopleRepositoryMock.Setup
                (x => x.UpdateHumanAsync(It.IsAny<int>(), It.IsAny<Human>())).
                Returns(Task.FromResult(1));

            //Act
            var controller = new PeopleController(_peopleRepositoryMock.Object);

            var result = controller.UpdateHumanAsync(passport, human);

            //Assert
            Assert.True(result.IsCompletedSuccessfully);
            _peopleRepositoryMock.Verify(x => x.UpdateHumanAsync(passport, human), Times.Once());
        }
    }
}
