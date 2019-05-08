using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using WAESAssignment.Diff.Api;
using WAESAssignment.Diff.Api.Entity;
using WAESAssignment.DiffApi;
using Xunit;

namespace WAESAssignment.Diff.Api.IntegrationTests
{
    public class DiffIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        public DiffIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async void Diff_WhenRequestWithoutLeftAndRightData_ShoultReturnBadRequest()
        {
            // Arrange
            var request = "v1/Diff/-10";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async void GetDifferenceLeft_WhenRequestWithoutPreviousPost_ShoulReturnBadRequest()
        {
            // Arrange
            var request = "v1/Diff/-20/left";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async void GetDifferenceRight_WhenRequestWithoutPreviousPost_ShoulReturnBadRequest()
        {
            // Arrange
            var request = "v1/Diff/-30/right";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async void PostLeft_WhenIdAndBase64Provided_ShoulReturnHttp201()
        {
            // Arrange
            int id = 1;
            var requestUrl = $"v1/Diff/{id}/left";
            var differenceLeft = new DifferenceLeft(id, "ewogICAgImlkIjoxLAogICAgIm5hbWUiOiJ0ZXN0ZSIKfQ==");

            // Act
            var response = await _client.PostAsync(requestUrl, ContentHelper.GetStringContent(differenceLeft));

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async void PostRight_WhenIdAndBase64Provided_ShoulReturnHttp201()
        {
            // Arrange
            int id = 1;
            var requestUrl = $"v1/Diff/{id}/right";
            var differenceRight = new DifferenceRight(id, "ewogICAgImlkIjoxLAogICAgIm5hbWUiOiJ0ZXN0ZSIKfQ==");

            // Act
            var response = await _client.PostAsync(requestUrl, ContentHelper.GetStringContent(differenceRight));

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async void GetDifferenceRight_WhenExists_ShoulReturnHttp200()
        {
            // Arrange
            int id = 2;
            var postUrl = $"v1/Diff/{id}/right";
            var differenceRight = new DifferenceRight(id, "ewogICAgImlkIjoxLAogICAgIm5hbWUiOiJ0ZXN0ZSIKfQ==");
            var content = ContentHelper.GetStringContent(differenceRight);
            var postResponse = await _client.PostAsync(postUrl, content);

            var requestUrl = postUrl;

            // Act
            var response = await _client.GetAsync(requestUrl);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //TODO: Test for content
        }

        [Fact]
        public async void GetDifferenceLeft_WhenExists_ShoulReturnHttp200()
        {
            // Arrange
            int id = 2;
            var postUrl = $"v1/Diff/{id}/left";
            var differenceleft = new DifferenceLeft(id, "ewogICAgImlkIjoxLAogICAgIm5hbWUiOiJ0ZXN0ZSIKfQ==");
            var content = ContentHelper.GetStringContent(differenceleft);
            await _client.PostAsync(postUrl, content);

            var requestUrl = postUrl;

            // Act
            var response = await _client.GetAsync(requestUrl);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //TODO: Test for content
        }

        [Fact]
        public async void GetDifference_WhenEqualSizeButDifferentValues_ShoulReturnSameSizeButDifferentData()
        {
            // Arrange
            int id = 3;
            var postUrlLeft = $"v1/Diff/{id}/left";
            var differenceleft = new DifferenceLeft(id, "ewogICAgImlkIjoxLAogICAgIm5hbWUiOiJ0ZXN0ZSIKfQ==");
            var contentLeft = ContentHelper.GetStringContent(differenceleft);
            await _client.PostAsync(postUrlLeft, contentLeft);

            var postUrlRight = $"v1/Diff/{id}/right";
            var differenceRight = new DifferenceRight(id, "ewogICAgImlkIjoxLAogICAgIm5hbWUiOiJ0ZXN0ZTIiCn0=");
            var contentRight = ContentHelper.GetStringContent(differenceRight);
            await _client.PostAsync(postUrlRight, contentRight);

            var requestUrl = $"v1/Diff/{id}";

            // Act
            var response = await _client.GetAsync(requestUrl);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //TODO: Test for content
        }
    }
}
