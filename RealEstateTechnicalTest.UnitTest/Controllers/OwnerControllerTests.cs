using Newtonsoft.Json;
using RealEstateTechnicalTest.Api;
using RealEstateTechnicalTest.Domain.Entities;
using RealEstateTechnicalTest.UnitTest.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RealEstateTechnicalTest.UnitTest.Controllers
{
    public class OwnerControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public OwnerControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync("/api/owner");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Owner>>(responseString);
            Assert.IsType<List<Owner>>(result);
            Assert.NotEmpty(result);
        }
    }
}
