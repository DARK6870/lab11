using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab11.CRUD.StatusesCRUD
{
    public class StatusViewModel
    {
        public int i { get; set; }
        public byte StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
