using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.CategoryCRUD
{
    public class CategoryViewModel
    {
        public int i {  get; set; }
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
