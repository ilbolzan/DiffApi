using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAESAssignment.Diff.Api.DTO
{
    /// <summary>
    /// Stores the comparisson result and the OffsetInights in case both have the same size
    /// </summary>
    public class ResultComparisson
    {
        public ResultComparisson (string status)
        {
            Status = status;
        }

        public ResultComparisson(string status, IList<OffsetInsight> insights)
        {
            Status = status;
            Insights = insights;
        }

        public string Status { get; set; }
        public IList<OffsetInsight> Insights { get; set; }
    }
}
