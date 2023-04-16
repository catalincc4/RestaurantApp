using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Entities;

namespace WinFormsApp1.DAL
{
    public class DishDAL
    {

        private static DishDAL _dishDal = null;
        private String _connectionString = @"Data Source=DESKTOP-6TFU7KK\SQLEXPRESS01;Initial Catalog=Labps;Integrated Security=True";

        SqlConnection _conn = null;

        private DishDAL()
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

        public static DishDAL getInstance()
        {
            if (_dishDal == null)
            {
                _dishDal = new DishDAL();
            }
            return _dishDal;
        }

        public void saveDish(Dish dish)
        {
            String sql = "INSERT INTO Dish(dishName, price, stock)" +
                "VALUES(@value1, @value2, @value3)";

            try

            {

                _conn.Open();
                
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("value1", dish.getName());
                cmd.Parameters.AddWithValue("value2", dish.getPrice());
                cmd.Parameters.AddWithValue("value3", dish.getStock());
                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }
        }

        public void updateDish(int  dishId, int stock)
        {
            String sql = "UPDATE Dish SET stock = @NewValue WHERE id = @ConditionValue";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@NewValue", stock);
                cmd.Parameters.AddWithValue("@ConditionValue", dishId);

                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }

        }

        public void updateStockWithAmount(int dishId, int amount)
        {
            String sql = "UPDATE Dish SET stock =stock - @NewValue WHERE id = @ConditionValue";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@NewValue", amount);
                cmd.Parameters.AddWithValue("@ConditionValue", dishId);

                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }

        }
        public void deleteDish(int dishId)
        {

            String sql = "delete from Dish  WHERE id = @ConditionValue";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@ConditionValue", dishId);

                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }

        }

        public void deleteAll()
        {

            String sql = "delete from Menu";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
          

                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }

        }
        public void updateData(DataTable dt)
        {
            String sql = "select id,dishName, price, stock  from dish";

            try

            {

                _conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(sql, _conn);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(dt);

                _conn.Close();
                MessageBox.Show("Record Update");
            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
              

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void createMenu(List<int> ids)
        {

            String sql = "Insert INTO Menu(idDish) Values(@id)";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);

                foreach (int id in ids)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }

   
                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }

        }

        public DataTable getOrderedDishes()
        {
            DataTable list = null;
            String sql = "SELECT DISTINCT d.*, SUM(od.quantity) AS howmany " +
                            "FROM Dish d " +
                            "JOIN OrderDetail od ON d.id = od.DishID " +
                            "Group by d.id, d.dishName, d.price, d.stock " +
                            "ORDER BY howmany DESC ";

            try

            {

                _conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(sql, _conn);
                list = new DataTable();
                sda.Fill(list);

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            return list;
        }

        public List<Dish> getDishes()
        {
            List<Dish> list = new List<Dish>();
            String sql = "Select * from Dish";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dish dish = new Dish();
                    dish.setId(reader.GetInt32(0));
                    dish.setName(reader.GetString(1));
                    dish.setPrice(reader.GetDouble(2));
                    dish.setStock(reader.GetInt32(3));

                    list.Add(dish);
                }

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

        public DataTable getMenu()
        {
            DataTable list = null;
            String sql = "select d.id,d.dishName, d.price, d.stock from dish d Join menu m on d.id = m.idDish";

            try

            {

                _conn.Open();

                SqlDataAdapter sda= new SqlDataAdapter(sql, _conn);
                list = new DataTable();
                sda.Fill(list);

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            return list;
        }

        public DataTable getDishesData()
        {
            DataTable list = null;
            String sql = "select * from dish";

            try

            {

                _conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter(sql, _conn);
                list = new DataTable();
                sda.Fill(list);

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                return null;

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            return list;
        }

    }



    }
