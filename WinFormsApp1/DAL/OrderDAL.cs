using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.BL;
using WinFormsApp1.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1.DAL
{
    public class OrderDAL
    {
        private static OrderDAL _ordersDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-6TFU7KK\SQLEXPRESS01;Initial Catalog=Labps;Integrated Security=True";
        SqlConnection _conn = null;

        private OrderDAL()
        {

            try

            {

                _conn = new SqlConnection(_connectionString);

            }

            catch (SqlException e)

            {

                //de facut ceva error handling, afisat mesaj, etc.. 

                _conn = null;

            }
        }

        public static OrderDAL getInstance()
        {
            if (_ordersDAL == null)
            {
                _ordersDAL = new OrderDAL();
            }
            return _ordersDAL;
        }

        public void saveOrder(Order order, List<OrderDetail> details)
        {
            String sql = "INSERT INTO Orders(totalCost, orderStatus, createDate)" +
                "VALUES(@value1, @value2, @value3); " +
                "SELECT SCOPE_IDENTITY();";
         
            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("value1", order.getTotalCost());
                cmd.Parameters.AddWithValue("value2", order.getOrderStatus().ToString());
                cmd.Parameters.AddWithValue("value3", order.getCreateDate());
               int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                String sql2 = "INSERT INTO OrderDetail(OrderID, DishID, quantity) " +
                    "Values(@orderId, @dishId, @quantity)";
            
                SqlCommand cmd2 = new SqlCommand(sql2, _conn);
                
                foreach(OrderDetail detail in details)
                {
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("orderId", orderId);
                    cmd2.Parameters.AddWithValue("dishId", detail.DishId);
                    cmd2.Parameters.AddWithValue("quantity", detail.Quantity);
                    cmd2.ExecuteNonQuery();
                }



                _conn.Close();

             

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
               
            }
         
        }

        public void updateOrder(int orderId, OrderType orderStatus)
        {
            String sql = "UPDATE Orders SET orderStatus = @NewValue WHERE id = @ConditionValue";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@NewValue", orderStatus.ToString());
                cmd.Parameters.AddWithValue("@ConditionValue", orderId);

                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }
        }

        public void deleteOrder(Order order)
        {
            String sql = "delete from Orders  WHERE id = @ConditionValue";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@ConditionValue", order.getId());

                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }

        }

        public Order getOrder(int id)
        {
            Order o = new Order();
            String sql = "SELECT * FROM Orders WHERE id= @ConditionValue" ;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("ConditionValue", id);
                SqlDataReader reader = cmd.ExecuteReader();
                

                if (reader.Read())
                {
                    o.setId(reader.GetInt32(0));
                    o.setTotalCost(reader.GetDouble(1));
                    o.setOrderStaus((OrderType)Enum.Parse(typeof(OrderType), reader.GetString(2)));
                    o.setCreateDate(reader.GetDateTime(3));
                }
                _conn.Close();
                OrderDetailDAL od = OrderDetailDAL.getInstance();
                o.setDishes(od.getOrderDishes(id));
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

                return null;
            }
            return o;
        }

        public List<Order> getOrdersBetweenTwoDates(DateTime date1, DateTime date2)
        {
            List<Order> orders = new List<Order>();
            String sql = "Select * from Orders where createDate Between @value1 AND @value2";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("value1", date1);
                cmd.Parameters.AddWithValue("value2", date2);
                SqlDataReader reader = cmd.ExecuteReader();


               while (reader.Read())
                {
                    Order o= new Order();
                    o.setId(reader.GetInt32(0));
                    o.setTotalCost(reader.GetDouble(1));
                    o.setOrderStaus((OrderType)Enum.Parse(typeof(OrderType), reader.GetString(2)));
                    o.setCreateDate(reader.GetDateTime(3));
                    orders.Add(o);
                }
                _conn.Close();

                OrderDetailDAL od = OrderDetailDAL.getInstance();
                foreach(Order o in orders)
                {
                    o.setDishes(od.getOrderDishes(o.getId()));
                }
              
            }catch(SqlException e)
            {
                return null;
            }
            return orders;
        }

        public List<Order> getOrders()
        {
            List<Order> orders = new List<Order>();
            String sql = "select * from orders";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Order o = new Order();
                    o.setId(reader.GetInt32(0));
                    o.setTotalCost(reader.GetDouble(1));
                    o.setOrderStaus((OrderType)Enum.Parse(typeof(OrderType), reader.GetString(2)));
                    o.setCreateDate(reader.GetDateTime(3));
                    orders.Add(o);
                }
                OrderDetailDAL od = OrderDetailDAL.getInstance();
                foreach (Order o in orders)
                {
                    o.setDishes(od.getOrderDishes(o.getId()));
                }
                _conn.Close();
            }
            catch(SqlException e)
            {
                return null;
            }
            return orders;
        }

    }
}
