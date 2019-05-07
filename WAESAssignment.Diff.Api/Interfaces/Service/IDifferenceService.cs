using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAESAssignment.Diff.Api.DTO;

namespace WAESAssignment.Diff.Api.Interfaces.Service
{
    public interface IDifferenceService
    {
        ResultComparisson Compare(int id);
    }
}
