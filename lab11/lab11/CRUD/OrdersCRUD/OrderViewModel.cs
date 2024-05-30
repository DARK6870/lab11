using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.OrdersCRUD
{
    public class OrderViewModel
    {
        public int i {  get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public string Adres {  get; set; }
        public short Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string StatusName { get; set; }
    }
}
