using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Entityes
{
    [Table("Status")]
    public class Status
    {
        [Key, Column(TypeName = "tinyint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte StatusId { get; set; }


        [Required, MaxLength(15), Column(TypeName = "nvarchar(15)")]
        public string? StatusName { get; set; }


        public ICollection<Order>? Orders { get; set; }
    }
}
