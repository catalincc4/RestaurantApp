using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.BL;
using WinFormsApp1.Entities;

namespace WinFormsApp1.UI
{
    public partial class AdminWindow : Form
    {

        DataTable dataMenu = new DataTable();
        OrderService orderService = new OrderService();
        DishService dishService = new DishService();
        DataTable dishData = new DataTable();

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("CSV");
            comboBox1.Items.Add("XML");

            dataGridView1.Enabled = true;
            dataGridView3.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView3.Visible = false;

            dataGridView1.DataSource = dishService.getDishes();

            dataMenu.Columns.Add("id", typeof(int));
            dataMenu.Columns.Add("dishName", typeof(string));
            dataMenu.Columns.Add("price", typeof(Double));
            dataMenu.Columns.Add("stock", typeof(int));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginWindow window = new LoginWindow();
            window.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            dataGridView3.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView3.Visible = false;
            dishData =  dishService.getDishes();
            dataGridView1.DataSource = dishData; 
        }


        private void button4_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            if (comboBox1.SelectedItem.ToString() == "CSV")
            {
                if (dataGridView1.Visible == true)
                {

                    userService.ExportDataGridViewToCSV(dataGridView1);
                }
                else
                {
                    userService.ExportDataGridViewToCSV(dataGridView1);
                }
            }
            else if(comboBox1.SelectedItem.ToString() == "XML")
            {
                if (dataGridView1.Visible == true)
                {

                    userService.ExportDataGridViewToXML(dataGridView1);
                }
                else
                {
                    userService.ExportDataGridViewToXML(dataGridView1);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            dataGridView3.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView3.Visible = false;
            dataGridView1.DataSource = dishService.mostOrderDishes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView3.Enabled = true;
            dataGridView1.Enabled = false;
            dataGridView3.Visible = true;
            dataGridView1.Visible = false;
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            List<Order> orders = new List<Order>();
            orders = orderService.ordersBetweenTwoDates(date1, date2);
            var orderViews = orders.Select(o => new OrderView
            {
                Id = o.Id,
                Dishes = string.Join(", ", o.Dishes.Select(d => d.Name)),
                TotalPrice = o.getTotalCost(),
                OrderStatus = o.getOrderStatus().ToString(),
                CreateDate = o.getCreateDate()

            }).ToList();
            dataGridView3.DataSource = orderViews;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Show();
            CreateAccountWindow window = new CreateAccountWindow();
            window.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            DataRow row = dataMenu.NewRow();
            row["id"] = selectedRow.Cells[0].Value;
            row["dishName"] = selectedRow.Cells[1].Value;
            row["price"] = selectedRow.Cells[2].Value;
            row["stock"] = selectedRow.Cells[3].Value;
            bool rowExists = dataMenu.AsEnumerable().Any(row => row.Field<int>("id") == Int32.Parse(selectedRow.Cells[0].Value.ToString()));
            if (!rowExists)
            {
                dataMenu.Rows.Add(row);
                dataGridView2.DataSource = dataMenu;
            }
        }

        private void setMenuButton_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            foreach(DataRow row in dataMenu.Rows)
            {
                list.Add(Int32.Parse(row["id"].ToString()));
            }
            dishService.updateMenu(list);
            MessageBox.Show("Menu is update");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dishService.updateData(dishData);
        }
    }
}
