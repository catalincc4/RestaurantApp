using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entities
{
    public class OrderDetail
    {
        private int orderId;
        private int dishId;
        private int quantity;

        public OrderDetail(int orderId, int dishId, int quantity)
        {
            this.orderId = orderId;
            this.dishId = dishId;
            this.quantity = quantity;
        }

        public int OrderId {
            get { return orderId; }
            set { orderId = value; }
        }

        public int DishId
        {
            get { return dishId; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
