using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TamroTask.Api.Controllers;
using TamroTask.Core.DTOs;
using TamroTask.Core.Entities;
using TamroTask.Core.Interfaces;
using Xunit;

namespace UnitTests
{
    public class UsersControllerTest
    {
        private readonly Mock<IUserRepository> _repository;
        public UsersControllerTest()
        {
            _repository = new Mock<IUserRepository>();
        }

        [Fact]
        public void GetAllUsers_WithUsersInRepo_ReturnsOkResult()
        {
            _repository.Setup(repo => repo.GetUsers()).ReturnsAsync(GetTestUsers());

            var controller = new UsersController(_repository.Object);
            var result = controller.GetUsers().Result;

            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetAllUsers_WithUsersInRepo_ReturnsAllItems()
        {
            _repository.Setup(repo => repo.GetUsers()).ReturnsAsync(GetTestUsers());

            var controller = new UsersController(_repository.Object);
            var okResult = controller.GetUsers().Result as OkObjectResult;

            var items = Assert.IsAssignableFrom<IEnumerable<UserDto>>(okResult.Value);
            Assert.Equal(2, items.Count());
        }

        [Fact]
        public void GetAllUsers_WithnNoUsersInRepo_ReturnsNoContentResult()
        {
            _repository.Setup(repo => repo.GetUsers()).ReturnsAsync(new List<User> { });

            var controller = new UsersController(_repository.Object);
            var result = controller.GetUsers().Result;

            Assert.IsType<NoContentResult>(result as NoContentResult);
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>();
            users.Add(new User()
            {
                Id = 1,
                FirstName = "Dalius",
                LastName = "Butrimas",
                Email = "daliusbutrimas@outlook.com",
                PhoneNumber = "+37062916834"
            });
            users.Add(new User()
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                Email = "JohnDoe@outlook.com",
                PhoneNumber = "+37062911111"
            });
            return users;
        }
    }
}
