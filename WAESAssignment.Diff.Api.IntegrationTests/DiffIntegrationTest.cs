using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using WAESAssignment.Diff.Api;
using WAESAssignment.DiffApi;
using Xunit;

namespace WAESAssignment.Diff.Api.IntegrationTests
{
    public class DiffIntegrationTest : IClassFixture<BaseIntegrationTest<Startup>>
    {
        protected readonly HttpClient _client;

        public DiffIntegrationTest(BaseIntegrationTest<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async void Diff_WhenRequestWithoutLeftAndRightData_ShoultReturnBadRequest()
        {
            // Arrange
            var request = "v1/Diff/-3";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void GetDifferenceLeft_WhenRequestWithoutPreviousPost_ShoulReturnBadRequest()
        {
            // Arrange
            var request = "v1/Diff/-1/left";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
