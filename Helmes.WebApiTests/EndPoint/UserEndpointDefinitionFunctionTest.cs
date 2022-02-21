using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Helmes.Shared.Model;
using Helmes.WebApiTests;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

namespace Helmes.WebApi.EndPoint.Tests
{
    [TestClass]
    public class UserEndpointDefinitionFunctionTest
    {
        private HttpClient client;
        private TaskApplication app;

        [TestInitialize]
        public void Init()
        {
            app = new TaskApplication();
            client = app.CreateClient();
            
        }

        [TestMethod]
        public async Task GetSectors_ReturnOk_ManufacturerSectorExptected()
        {
            var reply = await client.GetAsync("/sectors");
            Assert.AreEqual(HttpStatusCode.OK, reply.StatusCode);
            var data = await client.GetFromJsonAsync<List<Sectors>>("/sectors");
            Assert.AreEqual(1, data.Where(x => x.Name == "Manufacturing").First().SectorID);
        }

        [TestMethod]
        public async Task CreateUser_ReturnCreated()
        {
            var reply = await client.GetAsync("/sectors");
            Assert.AreEqual(HttpStatusCode.OK, reply.StatusCode);
            var data = await client.GetFromJsonAsync<List<Sectors>>("/sectors");

            var user = new User()
            {
                Name = "UserNameValue",
                AgreedToTerms = true,
                Sectors = data.Take(4).ToList()
            };
            reply = await client.PostAsJsonAsync<User>("/user", user);
            Assert.AreEqual(HttpStatusCode.Created, reply.StatusCode);
            var replycontent = await reply.Content.ReadAsStringAsync();
            Assert.IsTrue(replycontent.Contains(user.Name));
        }

        [TestMethod]
        public async Task GetUserByID_ReturnOkUser()
        {
            var reply = await client.GetAsync("/sectors");
            Assert.AreEqual(HttpStatusCode.OK, reply.StatusCode);
            var data = await client.GetFromJsonAsync<List<Sectors>>("/sectors");
            var guid = Guid.NewGuid();
            var user = new User()
            {
                ID = guid,
                Name = "UserNameValue",
                AgreedToTerms = true,
                Sectors = data.Take(4).ToList()
            };
            reply = await client.PostAsJsonAsync<User>("/user", user);
            Assert.AreEqual(HttpStatusCode.Created, reply.StatusCode);
            var replycontent = await reply.Content.ReadAsStringAsync();
            Assert.IsTrue(replycontent.Contains(user.Name));

            var userResult = await client.GetFromJsonAsync<User>($"/user/{guid}");
            Assert.AreEqual(guid, userResult.ID);
        }

        [TestMethod]
        public async Task UpdateUser_ReturnOkUser()
        {
            var reply = await client.GetAsync("/sectors");
            Assert.AreEqual(HttpStatusCode.OK, reply.StatusCode);
            var data = await client.GetFromJsonAsync<List<Sectors>>("/sectors");
            var guid = Guid.NewGuid();
            var user = new User()
            {
                ID = guid,
                Name = "UserNameValue",
                AgreedToTerms = true,
                Sectors = data.Take(4).ToList()
            };
            reply = await client.PostAsJsonAsync<User>("/user", user);
            Assert.AreEqual(HttpStatusCode.Created, reply.StatusCode);
            var replycontent = await reply.Content.ReadAsStringAsync();
            Assert.IsTrue(replycontent.Contains(user.Name));

            var userResult = await client.GetFromJsonAsync<User>($"/user/{guid}");
            Assert.AreEqual(guid, userResult.ID);
            Assert.AreEqual(user.Name, userResult.Name);

            userResult.Name = "New Name";
            reply = await client.PutAsJsonAsync<User>($"/user/{guid}",userResult);
            Assert.AreEqual(HttpStatusCode.OK, reply.StatusCode);

            userResult = await client.GetFromJsonAsync<User>($"/user/{guid}");
            Assert.AreEqual(guid, userResult.ID);
            Assert.AreNotEqual(user.Name, userResult.Name);

        }
    }
}