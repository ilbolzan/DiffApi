using Microsoft.EntityFrameworkCore;
using System;
using WAESAssignment.Diff.Api.Entity;
using WAESAssignment.Diff.Api.Repository;
using Xunit;

namespace WAESAssignment.Diff.Api.UnitTests.Repository
{
    public class DifferenceRightRepositoryTest : BaseRepositoryTest
    {


        [Fact]
        public void Add_WhenLeftIsNull_ShouldThrowDbUpdateException()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceRightRepository = new DifferenceRightRepository(_context);

            //Act
            var difference = new DifferenceRight(1, null);

            //Assert
            Exception ex = Assert.Throws<DbUpdateException>(() => differenceRightRepository.Add(difference));
        }

        [Fact]
        public void Add_WhenPropertiesFilled_ShouldSave()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceRightRepository = new DifferenceRightRepository(_context);
            int id = 1;

            //Act
            var differenceSaved = new DifferenceRight(id, "a");
            differenceRightRepository.Add(differenceSaved);
        }

        [Fact]
        public void Add_WhenLeftSizeIs8000_ShouldSave()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceRightRepository = new DifferenceRightRepository(_context);
            int id = 1;

            //Act
            var differenceSaved = new DifferenceRight(id, new string('a', 8000));
            differenceRightRepository.Add(differenceSaved);
        }

        [Fact]
        public void Add_WhenLeftSizeIs8001_ShouldThrowException()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceRightRepository = new DifferenceRightRepository(_context);
            int id = 1;

            //Act
            var difference = new DifferenceRight(id, new string('a', 8001));
            differenceRightRepository.Add(difference);

            //Assert
            Exception ex = Assert.Throws<DbUpdateException>(() => differenceRightRepository.Add(difference));
        }

        [Fact]
        public async void GetById_WhenProperlySaved_ShouldReturnEqualValues()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceRightRepository = new DifferenceRightRepository(_context);
            int id = 1;

            //Act
            var differenceSaved = new DifferenceRight(id, "a");
            differenceRightRepository.Add(differenceSaved);

            var differenceReturned = await differenceRightRepository.GetById(id);

            //Assert
            Assert.Equal<Difference>(differenceSaved, differenceReturned);
        }

        [Fact]
        public async void GetById_WhenNonExistent_ShouldReturnNull()
        {
            //arrange
            _context.Database.EnsureCreated();
            var differenceRightRepository = new DifferenceRightRepository(_context);
            int id = 1;

            //Act
            var differenceReturned = await differenceRightRepository.GetById(id);

            //Assert
            Assert.Null(differenceReturned);
        }
    }
}
