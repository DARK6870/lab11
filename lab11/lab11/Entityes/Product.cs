using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Entityes
{
    [Table("Product")]
    public class Product
    {
        [Key, Required]
        public int ProductId { get; set; }


        [Required, MaxLength(50), Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }


        [Required, MaxLength(500), Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }


        [Required]
        public int Price { get; set; }


        [Required]
        public string? ImageUrl { get; set; }


        [Required, ForeignKey(nameof(Categories))]
        public byte CategoryId { get; set; }
        public virtual Category? Categories { get; set; }


        [Required]
        public bool Available { get; set; }


        public ICollection<Order>? Orders { get; set; }
    }
}
