using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAESAssignment.Diff.Api.Entity
{
    public abstract class Difference : IEquatable<Difference>
    {
        public Difference(int id, string base64String)
        {
            Id = id;
            Base64String = base64String;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(8000)]
        public string Base64String { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Difference);
        }

        public bool Equals(Difference other)
        {
            return other != null &&
                   Id == other.Id &&
                   Base64String == other.Base64String;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Base64String);
        }
    }
}
