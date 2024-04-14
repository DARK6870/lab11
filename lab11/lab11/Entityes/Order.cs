using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.Entityes
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public virtual User? Users { get; set; }


        [Required, ForeignKey(nameof(Products))]
        public int ProductId { get; set; }
        public virtual Product? Products { get; set; }


        [Required, Column(TypeName = "smallint")]
        public short Quantity { get; set; }


        [Required]
        public int TotalPrice { get; set; }


        [Required, ForeignKey(nameof(Statuses))]
        public byte StatusId { get; set; }
        public virtual Status? Statuses { get; set; }
    }
}
