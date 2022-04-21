using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using UsersApi.Controllers;
using UsersApi.Models;
using UsersApi.Services;
using Xunit;

namespace UsersservicesTest
{
    public class UsersTest
    {

        private readonly UsersController _controller;
        private readonly IUserServices _userServices;
        private readonly IUserRepository _userRepository;
        private IOptions<UserDatabaseSettings> _config;


        public UsersTest()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();
            _config = Options.Create(configuration.GetSection("UserDatabaseSettings").Get<UserDatabaseSettings>());

            _userRepository = new UserRepository(_config);
            _userServices = new UserServices(_userRepository);
            _controller = new UsersController(_userServices);

        }


        [Fact]

        public void AddingUser()
        {
            User userData = new User()
            {
                Id = 1,
                Name = "Leanne Graham",
                UserName = "Bret",
                Email = "Sincere@april.biz",
                Address = new List<AddressList>
                {
                    new AddressList()
                    {
                        Street = "Kulas Light",
                        Suite = "Apt. 556",
                        City = "Gwenborough",
                        ZipCode = "92998-3874",
                        Geo=new List<GeoList>
                        {
                            new GeoList()
                            {
                                Lat= "-37.3159",
                                Lng= "81.1496"
                            }
                        }
                    }
                },
                Phone = "1-770-736-8031 x56442",
                Website = "hildegard.org",
                Company = new List<CompanyList>()
                {
                    new CompanyList()
                    {
                         Name= "Romaguera-Crona",
                         CatchPhrase= "Multi-layered client-server neural-net",
                         Bs= "harness real-time e-markets"
                    }
                }
            };

            var addResult = _controller.Create(userData);
            Assert.IsType<CreatedAtActionResult>(addResult);
        }

        [Fact]
        public void ReturnsAllItems()
        {
            var okResult = _controller.GetAllUserDetails();
            var items = Assert.IsType<List<User>>(okResult.Value);
            Assert.NotNull(items);
        }

        [Fact]
        public void RetrunOneItemDetails()
        {
            int id = 1;
            var okResult = _controller.GetUser(id);
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Update_Oneitem()
        {
            User userdata = new User()
            {
                Id = 1,
                Name = "Surya",
                UserName = "Bret",
                Email = "Sincere@april.biz",
                Address = new List<AddressList>
                {
                    new AddressList()
                    {
                        Street = "Kulas Light",
                        Suite = "Apt. 556",
                        City = "Gwenborough",
                        ZipCode = "92998-3874",
                        Geo=new List<GeoList>
                        {
                            new GeoList()
                            {
                                Lat= "-37.3159",
                                Lng= "81.1496"
                            }
                        }
                    }
                },
                Phone = "1-770-736-8031 x56442",
                Website = "hildegard.org",
                Company = new List<CompanyList>()
                {
                    new CompanyList()
                    {
                         Name= "Romaguera-Crona",
                         CatchPhrase= "Multi-layered client-server neural-net",
                         Bs= "harness real-time e-markets"
                    }
                }
            };
            var noContentResponse = _controller.Update(userdata.Id, userdata);
            Assert.IsType<NoContentResult>(noContentResponse);

        }
        [Fact]
        public void Remove_Existingid_RemovesOneItem()
        {

            int id = 1;
            var noContentResponse = _controller.Delete(id);
            Assert.IsType<NoContentResult>(noContentResponse);

        }
    }
}
