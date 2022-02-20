using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helmes.WebApi.EndPoint;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Helmes.Shared.Model;
using Moq;
using Helmes.WebApi.Service;
using Helmes.WebApiTests;

namespace Helmes.WebApi.EndPoint.Tests
{
    [TestClass()]
    public class UserEndpointDefinitionTests
    {
        [TestMethod]
        public async Task CreateUser_ReturnBadRequest_DidNotAgreeWithTerms()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "Unit",
                AgreedToTerms = false,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            var controller = new UserEndpointDefinition();
            var result = await controller.CreateUserAsync(repositoryMock.Object, user);
            Assert.AreEqual(400, result.GetOkObjectResultStatusCode());
        }

        [TestMethod]
        public async Task CreateUser_ReturnBadRequest_NameIsNull()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = null,
                AgreedToTerms = true,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            var controller = new UserEndpointDefinition();
            var result = await controller.CreateUserAsync(repositoryMock.Object, user);
            Assert.AreEqual(400, result.GetOkObjectResultStatusCode());
        }

        [TestMethod]
        public async Task CreateUser_ReturnBadRequest_NameIsWhiteSpace()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "",
                AgreedToTerms = true,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            var controller = new UserEndpointDefinition();
            var result = await controller.CreateUserAsync(repositoryMock.Object, user);
            Assert.AreEqual(400, result.GetOkObjectResultStatusCode());
        }

        [TestMethod]
        public async Task CreateUser_ReturnBadRequest_NoSectors()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "",
                AgreedToTerms = true,
            };
            var repositoryMock = new Mock<IUserService>();
            var controller = new UserEndpointDefinition();
            var result = await controller.CreateUserAsync(repositoryMock.Object, user);
            Assert.AreEqual(400, result.GetOkObjectResultStatusCode());
        }

        [TestMethod]
        public async Task CreateUser_ReturnBadRequest_TooManySectors()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "Unit",
                AgreedToTerms = true,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                    new Sectors(){ SectorID =5,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            var controller = new UserEndpointDefinition();
            var result = await controller.CreateUserAsync(repositoryMock.Object, user);
            Assert.AreEqual(400, result.GetOkObjectResultStatusCode());
        }

        [TestMethod]
        public async Task CreateUser_ReturnBadRequest_GUID_Dublication()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "Unit",
                AgreedToTerms = true,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                    new Sectors(){ SectorID =5,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            repositoryMock
                .Setup(r => r.GetByIdAsync(guid))
                .ReturnsAsync(user);
            var controller = new UserEndpointDefinition();
            var result = await controller.CreateUserAsync(repositoryMock.Object, user);
            Assert.AreEqual(400, result.GetOkObjectResultStatusCode());
        }

        [TestMethod]
        public async Task CreateUser_ReturnUser()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "Unit",
                AgreedToTerms = true,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            var controller = new UserEndpointDefinition();
            var result = await controller.CreateUserAsync(repositoryMock.Object, user);
            var resultUser = result.GetOkObjectResultValue<User>();
            Assert.AreEqual(201, result.GetOkObjectResultStatusCode());
            Assert.IsNotNull(result);
            Assert.AreEqual("Unit", resultUser.Name);
            Assert.AreEqual(guid, resultUser.ID);
            Assert.IsTrue(resultUser.AgreedToTerms);
        }

        [TestMethod]
        public async Task UpdateUser_ReturnOkUser_WhenUserExists()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "Unit",
                AgreedToTerms = true,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            repositoryMock
              .Setup(r => r.GetByIdAsync(guid))
              .ReturnsAsync(user);
            var controller = new UserEndpointDefinition();
            user.Name = "Changed Unit";
            var result = await controller.UpdateUserAsync(repositoryMock.Object, guid, user);
            var resultUser = result.GetOkObjectResultValue<User>();
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.GetOkObjectResultStatusCode());
            Assert.AreEqual("Changed Unit", resultUser.Name);
            Assert.AreEqual(guid, resultUser.ID);
            Assert.IsTrue(resultUser.AgreedToTerms);
        }

        [TestMethod]
        public async Task UpdateUser_ReturnNotFound_WhenUserDoesNotExsist()
        {
            var guid = Guid.NewGuid();
            var user = new User
            {
                ID = guid,
                Name = "Unit",
                AgreedToTerms = true,
                Sectors = new List<Sectors>
                {
                    new Sectors(){ SectorID =0,},
                    new Sectors(){ SectorID =1,},
                    new Sectors(){ SectorID =2,},
                    new Sectors(){ SectorID =3,},
                    new Sectors(){ SectorID =4,},
                }
            };
            var repositoryMock = new Mock<IUserService>();
            var controller = new UserEndpointDefinition();
            user.Name = "Changed Unit";
            var result = await controller.UpdateUserAsync(repositoryMock.Object, Guid.NewGuid(), user);
            var resultUser = result.GetOkObjectResultValue<User>();
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.GetOkObjectResultStatusCode());
        }

        [TestMethod]
        public async Task GetUserByID_ReturnUser_WhenUserExists()
        {
            var guid = Guid.NewGuid();
            var user = new User { Name = "Unit", ID = guid, AgreedToTerms = true };
            var repositoryMock = new Mock<IUserService>();
            repositoryMock
                .Setup(r => r.GetByIdAsync(guid))
                .ReturnsAsync(user);

            var controller = new UserEndpointDefinition();
            var result = await controller.GetUserByIdAsync(repositoryMock.Object, guid);
            var resultUser = result.GetOkObjectResultValue<User>();
            if (resultUser is null)
                Assert.Fail("Could not get Instance of a User");
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.GetOkObjectResultStatusCode());
            Assert.AreEqual("Unit", resultUser.Name);
            Assert.AreEqual(guid, resultUser.ID);
            Assert.IsTrue(resultUser.AgreedToTerms);
        }

        [TestMethod]
        public async Task GetUserByID_ReturnNotFound_WhenUserDoesNotExists()
        {
            var guid = Guid.NewGuid();
            var user = new User { Name = "Unit", ID = guid, AgreedToTerms = true };
            var repositoryMock = new Mock<IUserService>();
            repositoryMock
                .Setup(r => r.GetByIdAsync(guid))
                .ReturnsAsync(user);

            var controller = new UserEndpointDefinition();
            var result = await controller.GetUserByIdAsync(repositoryMock.Object, Guid.NewGuid());
            var resultUser = result.GetOkObjectResultValue<User>();
            Assert.AreEqual(404, result.GetOkObjectResultStatusCode());
        }
    }
}