using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WinFormsApp1.Entities;

namespace WinFormsApp1.DAL
{
    public class UsersDAL
    {
        private static UsersDAL _usersDAL = null;

        private String _connectionString = @"Data Source=DESKTOP-6TFU7KK\SQLEXPRESS01;Initial Catalog=Labps;Integrated Security=True";

        SqlConnection _conn = null;



        private UsersDAL()

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



        public static UsersDAL getInstance()

        {

            if (_usersDAL == null)

            {

                _usersDAL = new UsersDAL();

            }

            return _usersDAL;

        }





        public User getUser(String username, String password)

        {

            User u = null;

            String sql = "SELECT * FROM users WHERE username='" + username + "' AND password='"  + password +"'";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
            
         
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    u = new User();
                    u.setUsername(reader.GetString(0));
                    u.setPassword(reader.GetString(1));
                    u.setName(reader.GetString(2));
                    u.setRole((Role)Enum.Parse(typeof(Role),reader.GetString(3)));
                }
                _conn.Close();

               

            } catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

                return null;

            }

            return u;

        }
        public User findByUsername(String username)
        {
            User u = null;
            String sql = "Select * from users where username = @value";
            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("value", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    u = new User();
                    u.setUsername(reader.GetString(0));
                    u.setPassword(reader.GetString(1));
                    u.setName(reader.GetString(2));
                    u.setRole((Role)Enum.Parse(typeof(Role), reader.GetString(3)));
                }
                _conn.Close();



            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

                return null;

            }

            return u;

        }
        public void saveUser(String username, String password, String name, String role)
        {
            String sql = "INSERT INTO users(username, password, name, role)" +
                "VALUES(@value1, @value2, @value3, @value4)";

            try

            {

                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("value1", username);
                cmd.Parameters.AddWithValue("value2", password);
                cmd.Parameters.AddWithValue("value3", name);
                cmd.Parameters.AddWithValue("value4", role);
                int rowsAffected = cmd.ExecuteNonQuery();

                _conn.Close();

            }

            catch (SqlException e)

            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);

            }
        }
    }
}
