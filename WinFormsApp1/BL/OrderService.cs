using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Entities;

namespace WinFormsApp1.BL
{
    public class OrderService
    { 
        private OrderDAL orderDAL= null;

        public OrderService()
        {
            orderDAL = OrderDAL.getInstance();
        }

        public Double getTotalCost(List<Dish> dishes) { 
            Double totalCost = 0;
            foreach (Dish dish in dishes) {
                totalCost += dish.getPrice();
            }
            return totalCost;
        }

        public void createOrder(List<Dish> dishes)
        {

            Order order = new Order(dishes, getTotalCost(dishes), OrderType.NewOrder, DateTime.Now);
            
            
            List<OrderDetail> details = new List<OrderDetail>(); 
            foreach (Dish dish in dishes) {
                OrderDetail orderDetail = details.FirstOrDefault(dd => dd.DishId == dish.getId());
                if (orderDetail != null)
                {
                    orderDetail.Quantity += 1;
                }
                else
                {
                    details.Add(new OrderDetail(0, dish.getId(), 1));
                }
            }
                
                 orderDAL.saveOrder(order, details);
            DishService dishService = new DishService();
            foreach(OrderDetail detail in details)
            {
                dishService.updateStockWithAmount(detail.DishId, detail.Quantity);
            }

        }

        public void modifyOrderStatus(int orderId, OrderType orderStatus)
        {
            orderDAL.updateOrder(orderId, orderStatus); 
        }
        public void deleteOrder(Order order)
        {
            orderDAL.deleteOrder(order);
        }

        public List<Order> ordersBetweenTwoDates(DateTime date1, DateTime date2)
        {
            List<Order> orders = new List<Order>();
           orders = orderDAL.getOrdersBetweenTwoDates(date1, date2);
            return orders;
        }
       
    }
}
