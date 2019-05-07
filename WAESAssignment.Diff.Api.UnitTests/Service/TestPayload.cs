using System;

namespace WAESAssignment.Diff.Api.UnitTests.Service
{
    [Serializable]
    public class TestPayload
    {
        public TestPayload(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
