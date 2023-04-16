using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entities;

namespace WinFormsApp1.DAL
{
    public class OrderDetailDAL
    {
        private static OrderDetailDAL _orderDishDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-6TFU7KK\SQLEXPRESS01;Initial Catalog=Labps;Integrated Security=True";

        SqlConnection _conn = null;

        private OrderDetailDAL()
        {
            try
            {
                _conn = new SqlConnection(_connectionString);
            }
            catch(SqlException e)
            {
                _conn = null;
            }
        }

        public static OrderDetailDAL getInstance()
        {
            if(_orderDishDAL == null)
            {
                _orderDishDAL = new OrderDetailDAL();
            }

            return _orderDishDAL;
        }
        

        public List<Dish> getOrderDishes(int id)
        {
            List<Dish> result = new List<Dish>();

            String sql = "SELECT d.* " +
                "FROM Orders o " +
                "Join OrderDetail od ON o.id = od.OrderID " +
                "Join Dish d On od.DishID = d.id " +
                "where o.id = @ConditionValue";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("ConditionValue", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dish dish = new Dish();
                    dish.setId(reader.GetInt32(0));
                    dish.setName(reader.GetString(1));
                    dish.setPrice(reader.GetDouble(2));
                    dish.setStock(reader.GetInt32(3));

                    result.Add(dish);
                }

                

                _conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

                return null;
            }

            return result;
        }
    }
}
