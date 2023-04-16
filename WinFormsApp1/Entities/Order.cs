using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entities
{
   public enum OrderType
    {
        NewOrder,
        OrderInProcess,
        OrderDone
    }
    public class Order
    {
        private int id;
        private List<Dish> dishes;
        private Double totalCost;
        private OrderType orderStaus;
        private DateTime createDate;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public List<Dish> Dishes
        {
            get { return dishes; }
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }
        public Order(List<Dish> dishes, Double totalCost, OrderType orderSatus, DateTime createDate)
        {
            this.dishes = dishes;
            this.totalCost = totalCost;
            this.orderStaus = orderSatus;
            this.createDate = createDate;
        }
        public Order()
        {
            this.dishes = new List<Dish>();
        }

        public List<Dish> getDishes()
        {
            return dishes;
        }

        public Double getTotalCost()
        {
            return totalCost;
        }

        public OrderType getOrderStatus()
        {
            return orderStaus;
        }

        public DateTime getCreateDate()
        {
            return createDate;
        } 

        public void setDishes(List<Dish> dishes)
        {
            this.dishes=dishes;
        }

        public void setTotalCost(Double totalCost)
        {
            this.totalCost = totalCost;
        }

        public void setOrderStaus(OrderType orderSatus)
        {
            this.orderStaus=orderSatus;
        }
        public void setCreateDate(DateTime createDate)
        {
            this.createDate = createDate;
        }

    }
}
