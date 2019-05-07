using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WAESAssignment.Diff.Api.Entity;
using WAESAssignment.Diff.Api.Interfaces.Repository;
using WAESAssignment.Diff.Api.Service;
using Xunit;

namespace WAESAssignment.Diff.Api.UnitTests.Service
{
    public class DifferenceServiceTest
    {
        [Fact]
        public void Compare_WhenSameObject_ShouldReturnEquals()
        {
            //Arrange
            var base64 = BuildSmallBase64();
            var id = 1;
            //mocking left side
            var mockDiffLeftRepository = MockDiffLeft(base64, id);
            //mocking right side
            var mockDiffRightRepository = MockDiffRight(base64, id);

            var differenceService = new DifferenceService(mockDiffLeftRepository.Object, mockDiffRightRepository.Object);

            //Act
            var result = differenceService.Compare(id);

            //Assert
            Assert.Equal("EQUAL", result.Status);
        }

        [Fact]
        public void Compare_WhenDifferentSize_ShouldReturnDifferentSize()
        {
            //Arrange
            var smallBase64 = BuildSmallBase64();
            var biggerBase64 = BuildBiggerBase64();
            var id = 1;
            //mocking left side
            var mockDiffLeftRepository = MockDiffLeft(smallBase64, id);
            //mocking right side
            var mockDiffRightRepository = MockDiffRight(biggerBase64, id);

            var differenceService = new DifferenceService(mockDiffLeftRepository.Object, mockDiffRightRepository.Object);

            //Act
            var result = differenceService.Compare(id);

            //Assert
            Assert.Equal("DIFFERENT_SIZES", result.Status);
        }

        [Fact]
        public void Compare_WhenSameSizeButOneDifference_ShouldReturnInsights()
        {
            //Arrange
            var smallBase64 = BuildSmallBase64();
            var differentBase64 = BuildSmallWithOneDifferenceBase64();
            //var smallBase64 = "asdfghjkl";
            //var differentBase64 = "asderhjkl";
            var id = 1;
            //mocking left side
            var mockDiffLeftRepository = MockDiffLeft(smallBase64, id);
            //mocking right side
            var mockDiffRightRepository = MockDiffRight(differentBase64, id);

            var differenceService = new DifferenceService(mockDiffLeftRepository.Object, mockDiffRightRepository.Object);

            //Act
            var result = differenceService.Compare(id);

            //Assert
            Assert.Equal("SAME_SIZE_BUT_DIFFERENT_DATA", result.Status);
            Assert.Equal(1, result.Insights.Count);
            Assert.Equal(298, result.Insights.FirstOrDefault().Offset);
            Assert.Equal(1, result.Insights.FirstOrDefault().Lenght);
        }

        private static Mock<IDifferenceRightRepository> MockDiffRight(string base64, int id)
        {
            var mockDiffRightRepository = new Mock<IDifferenceRightRepository>();
            mockDiffRightRepository
                .Setup(m => m.GetById(1))
                .Returns(Task
                    .FromResult(new DifferenceRight(id, base64)));
            return mockDiffRightRepository;
        }

        private static Mock<IDifferenceLeftRepository> MockDiffLeft(string base64, int id)
        {
            var mockDiffLeftRepository = new Mock<IDifferenceLeftRepository>();
            mockDiffLeftRepository
                .Setup(m => m.GetById(1))
                .Returns(Task
                    .FromResult(new DifferenceLeft(id, base64)));
            return mockDiffLeftRepository;
        }

        /// <summary>
        /// Builds a single object encoded in base64
        /// </summary>
        /// <returns></returns>
        private string BuildSmallBase64()
        {
            var data = new TestPayload(1, "John");

            return ObjectToString(data);
        }

        /// <summary>
        /// Builds a small base64 with 1 difference
        /// </summary>
        /// <returns></returns>
        private string BuildSmallWithOneDifferenceBase64()
        {
            var data = new TestPayload(2, "John");

            return ObjectToString(data);
        }

        /// <summary>
        /// Builds a Bigger than BuildJohnBase64 base64
        /// </summary>
        /// <returns></returns>
        private dynamic BuildBiggerBase64()
        {
            var data = new TestPayload(12345, "John Doe");

            return ObjectToString(data);
        }

        /// <summary>
        /// Serializes objects do Base64Strings
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private string ObjectToString(object o)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, o);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
