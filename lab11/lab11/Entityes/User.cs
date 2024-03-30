using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace lab11.Entityes
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }


        [Required, DefaultValue(0), Column(TypeName = "tinyint")]
        public byte RoleId { get; set; }
            

        [Required, Column(TypeName = "nvarchar(30)"), MaxLength(30)]
        [MinLength(5)]
        public string? UserName { get; set; }


        [Column(TypeName = "nvarchar(50)"), MaxLength(50)]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }


        [Required, MinLength(5), Column(TypeName = "nvarchar(250)")]
        public string? PasswordHash { get; set; }


        [Required]
        public string? FullName { get; set; }


        [Required, MinLength(10), Column(TypeName = "nvarchar(70)"), MaxLength(70)]
        public string? Adress { get; set; }


        [Required, MaxLength(20), Column(TypeName = "nvarchar(20)")]
        public string? PhoneNumber { get; set; }



        public ICollection<Order>? Orders { get; set; }
    }
}
