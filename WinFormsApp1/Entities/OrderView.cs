using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entities
{
    public class OrderView
    {
        public int Id { get; set; }
        public string Dishes { get; set; }
        public Double TotalPrice { get; set; }
        public String OrderStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
