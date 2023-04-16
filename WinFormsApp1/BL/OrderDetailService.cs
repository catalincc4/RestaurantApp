using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Entities;

namespace WinFormsApp1.BL
{
   public class OrderDetailService
    {
        private OrderDetailDAL orderDetailDAL = null;

        public OrderDetailService()
        {
            orderDetailDAL = OrderDetailDAL.getInstance();
        }
    }
}
