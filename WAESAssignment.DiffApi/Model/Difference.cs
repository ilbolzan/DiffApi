using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAESAssignment.Diff.Api.Model
{
    public class Difference
    {
        public int Id { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
    }
}
