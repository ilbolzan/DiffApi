using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WAESAssignment.Diff.Api.UnitTests.Helpers
{
    public static class DbContextOptionsHelper
    {
        /// <summary>
        /// Create a ContextOptions configured with Slite in-memory that would be used for unit tests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static DbContextOptions<T> CreateOptions<T>() where T : DbContext
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();


            return new DbContextOptionsBuilder<T>()
                .UseSqlite(connection)
                .Options;
        }
    }
}
