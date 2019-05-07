using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAESAssignment.Diff.Api.DTO
{
    /// <summary>
    /// Store index and lenght of each difference found between both base64Strings
    /// </summary>
    public class OffsetInsight
    {
        public OffsetInsight(int offset, int lenght)
        {
            Offset = offset;
            Lenght = lenght;
        }

        public int Offset { get; set; }
        public int Lenght { get; set; }
    }
}
