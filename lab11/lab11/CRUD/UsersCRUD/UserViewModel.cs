using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.UsersCRUD
{
    public class UserViewModel
    {
        public int i { get; set; }
        public int UserID { get; set; }
        public string? RoleName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
