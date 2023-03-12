using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Ogen.Models
{
    public class Product
    {
        [NotNull]
        [Key]
        public int Id { get; set; }

        [NotNull]
        [StringLength(30)]
        public string Type { get; set; }

        [NotNull]
        [StringLength(100)]
        public string Name { get; set; }

        [NotNull]
        [StringLength(30)]
        public string Producer { get; set; }

        [NotNull]

        public int Size { get; set; }
        [NotNull]
        [StringLength(30)]
        public string Flavor { get; set; }
        [NotNull]
        public int Stock { get; set; }

    }
}
