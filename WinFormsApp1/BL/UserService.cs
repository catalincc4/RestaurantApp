using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WinFormsApp1.DAL;
using WinFormsApp1.Entities;

namespace WinFormsApp1.BL
{
    class UserService
    {
        private UsersDAL users = null;
        public String login(String username, String password)
        {
            users = UsersDAL.getInstance();

            User user = users.getUser(username, encryptPassword(password));
            if (user != null)
            {
                return user.getRole().ToString();
            }
            return null;
        }

        public String encryptPassword(String password)
        {
            return getMd5Hash(password);
        }

        static string getMd5Hash(string input)

        {

            // Create a new instance of the MD5CryptoServiceProvider object. 

            MD5 md5Hasher = MD5.Create();



            // Convert the input string to a byte array and compute the hash. 

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));



            // Create a new Stringbuilder to collect the bytes 

            // and create a string. 

            StringBuilder sBuilder = new StringBuilder();



            // Loop through each byte of the hashed data  

            // and format each one as a hexadecimal string. 

            for (int i = 0; i < data.Length; i++)

            {

                sBuilder.Append(data[i].ToString("x2"));

            }



            // Return the hexadecimal string. 

            return sBuilder.ToString();

        }

        public void createEmployeeAccount(String username, String name, String password)
        {
            users = UsersDAL.getInstance();
            users.saveUser(username, encryptPassword(password), name, Role.Employee.ToString());
        }

        public void ExportDataGridViewToCSV(DataGridView dataGridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.Title = "Export to CSV";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {

                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        sw.Write(column.HeaderText + ",");
                    }
                    sw.WriteLine();


                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sw.Write(cell.Value + ",");
                        }
                        sw.WriteLine();
                    }


                    sw.Close();
                }
                MessageBox.Show("CSV file saved successfully.", "Export to CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void ExportDataGridViewToXML(DataGridView dataGridView)
        {
           
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            saveFileDialog.Title = "Export to XML";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;

                
                using (XmlWriter writer = XmlWriter.Create(saveFileDialog.FileName, settings))
                {
                 
                    writer.WriteStartElement("Table");

                   
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        writer.WriteStartElement("Row");

                       
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.WriteAttributeString(cell.OwningColumn.HeaderText, cell.Value.ToString());
                        }

                        writer.WriteEndElement();
                    }

                  
                    writer.WriteEndElement();
                    writer.Close();
                }

                MessageBox.Show("XML file saved successfully.", "Export to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool findByUsername(String username)
        {
            UsersDAL user = UsersDAL.getInstance();
            if(user.findByUsername(username) != null)
            {
                return true;
            }
            return false;
        }


    }
}
