using Microsoft.EntityFrameworkCore;
using System;
using WAESAssignment.Diff.Api.Entity;
using WAESAssignment.Diff.Api.Models;
using WAESAssignment.Diff.Api.Repository;
using WAESAssignment.Diff.Api.UnitTests.Helpers;
using Xunit;

namespace WAESAssignment.Diff.Api.UnitTests.Repository
{
    public class DifferenceLeftRepositoryTest : BaseRepositoryTest
    {
        [Fact]
        public void Add_WhenLeftIsNull_ShouldThrowDbUpdateException()
        {
            //Arrange
            _context.Database.EnsureCreated();
            var differenceLeftRepository = new DifferenceLeftRepository(_context);

            //Act
            var difference = new DifferenceLeft(1, null);

            //Assert
            Exception ex = Assert.Throws<DbUpdateException>(() => differenceLeftRepository.Add(difference));
        }

        [Fact]
        public void Add_WhenPropertiesFilled_ShouldSave()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceLeftRepository = new DifferenceLeftRepository(_context);
            int id = 1;

            //Act
            var differenceSaved = new DifferenceLeft(id, "a");
            differenceLeftRepository.Add(differenceSaved);
        }

        [Fact]
        public void Add_WhenLeftSizeIs8000_ShouldSave()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceLeftRepository = new DifferenceLeftRepository(_context);
            int id = 1;

            //Act
            var differenceSaved = new DifferenceLeft(id, new string('a', 8000));
            differenceLeftRepository.Add(differenceSaved);
        }

        [Fact]
        public void Add_WhenLeftSizeIs8001_ShouldThrowException()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceLeftRepository = new DifferenceLeftRepository(_context);
            int id = 1;

            //Act
            var difference = new DifferenceLeft(id, new string('a', 8001));
            differenceLeftRepository.Add(difference);

            //Assert
            Exception ex = Assert.Throws<DbUpdateException>(() => differenceLeftRepository.Add(difference));
        }

        [Fact]
        public async void GetById_WhenProperlySaved_ShouldReturnEqualValues()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceLeftRepository = new DifferenceLeftRepository(_context);
            int id = 1;

            //Act
            var differenceSaved = new DifferenceLeft(id, "a");
            differenceLeftRepository.Add(differenceSaved);

            var differenceReturned = await differenceLeftRepository.GetById(id);


            //Assert
            Assert.Equal<Difference>(differenceSaved, differenceReturned);
        }

        [Fact]
        public async void GetById_WhenNonExistent_ShouldReturnNull()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceLeftRepository = new DifferenceLeftRepository(_context);
            int id = 1;

            //Act
            var differenceReturned = await differenceLeftRepository.GetById(id);

            //Assert
            Assert.Null(differenceReturned);
        }
    }
}
