using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAESAssignment.Diff.Api.Entity
{
    /// <summary>
    /// <see cref="DifferenceLeft"/> and <see cref="DifferenceRight"/> have the same 
    /// properties inherited from <see cref="Difference"/>.
    /// They're only saved in different tables for improved performance since it would
    /// prevent concurrency and locking
    /// </summary>
    public class DifferenceRight : Difference
    {
        public DifferenceRight(int id, string base64String) : base(id, base64String)
        {
        }
    }
}
