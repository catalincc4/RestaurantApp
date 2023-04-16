using System.Data;
using WinFormsApp1.BL;
using WinFormsApp1.DAL;
using WinFormsApp1.Entities;

namespace WinFormsApp1.UI
{
    public partial class EmployeeWindow : Form
    {

        bool readyToUpdateStatus = false;
        int idOrderToUpdate = 0;
        DataTable dataOrder = new DataTable();
                
        public EmployeeWindow()
        {
            InitializeComponent();
        }
        private void EmployeeWindow_Load(object sender, EventArgs e)
        {

            List<Order> orders = new List<Order>();
            OrderDAL ord = OrderDAL.getInstance();
            orders = ord.getOrders();

            dataOrder.Columns.Add("id", typeof(int));
            dataOrder.Columns.Add("dishName", typeof(string));
            dataOrder.Columns.Add("price", typeof(Double));
            dataOrder.Columns.Add("stock", typeof(int));

            dataGridView2.Enabled = false;
            dataGridView2.Visible = false;
            dataGridView1.Enabled = true;
            dataGridView1.Visible = true;

            var orderViews = orders.Select(o => new OrderView
            {
                Id = o.Id,
                Dishes = string.Join(", ", o.Dishes.Select(d => d.Name)),
                TotalPrice = o.getTotalCost(),
                OrderStatus = o.getOrderStatus().ToString(),
                CreateDate = o.getCreateDate()

            }).ToList();
            dataGridView1.DataSource = orderViews;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (readyToUpdateStatus)
            {
                OrderDAL ord = OrderDAL.getInstance();
                OrderService ordS = new OrderService();

                OrderType orderStatus = ord.getOrder(idOrderToUpdate).getOrderStatus();
                if (orderStatus == OrderType.NewOrder)
                {
                    ordS.modifyOrderStatus(idOrderToUpdate, OrderType.OrderInProcess);

                }
                else if(orderStatus == OrderType.OrderInProcess)
                {
                    ordS.modifyOrderStatus(idOrderToUpdate, OrderType.OrderDone);
                }
                MessageBox.Show("Status Update for order with id =>" + idOrderToUpdate);
            }
            readyToUpdateStatus = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataOrder.Rows.Count > 0)
            {
                List<Dish> dishes = new List<Dish>();
                foreach (DataRow row in dataOrder.Rows)
                {
                    Dish d = new Dish(Int32.Parse(row[0].ToString()), row[1].ToString(), Double.Parse(row[2].ToString()), Int32.Parse(row[3].ToString()));
                    dishes.Add(d);
                }
                OrderService orderService = new OrderService();
                orderService.createOrder(dishes);
                MessageBox.Show("Order Created!!!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DishDAL menu = DishDAL.getInstance();
            dataGridView1.Visible = true;
            dataGridView1.Visible = true;
            dataGridView2.Enabled = false;
            dataGridView2.Visible = false;
            dataGridView2.DataSource = menu.getMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            readyToUpdateStatus = false;
            DishDAL menu = DishDAL.getInstance();
            dataGridView1.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Enabled = true;
            dataGridView2.Visible = true;
            dataGridView2.DataSource = menu.getMenu();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            idOrderToUpdate = Int32.Parse(selectedRow.Cells[0].Value.ToString());
            readyToUpdateStatus = true;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];
            if (Int32.Parse(selectedRow.Cells[3].Value.ToString()) > 0)
            {
                DataRow row = dataOrder.NewRow();
                row["id"] = selectedRow.Cells[0].Value;
                row["dishName"] = selectedRow.Cells[1].Value;
                row["price"] = selectedRow.Cells[2].Value;
                row["stock"] = selectedRow.Cells[3].Value;
                dataOrder.Rows.Add(row);
                dataGridView3.DataSource = dataOrder;
            }
        }


    }
}
