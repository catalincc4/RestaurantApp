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

namespace WinFormsApp1.UI
{
    public partial class CreateAccountWindow : Form
    {
        UserService userService = new UserService();
        public CreateAccountWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox2.Text.ToString();
            var name = textBox1.Text.ToString();
            var password = textBox3.Text.ToString();

            if (username != "" && name != "" && password != "" && !userService.findByUsername(username))
            {
                userService.createEmployeeAccount(username, name, password);
                MessageBox.Show("Account created!!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Account already exist!!!");
            }

        }
    }


}
