using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Entityes
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CategoryId { get; set; }


        [Required, MaxLength(30), MinLength(5), Column(TypeName = "nvarchar(30)")]
        public string? CategoryName { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
