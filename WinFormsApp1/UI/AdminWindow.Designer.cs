namespace WinFormsApp1.UI
{
    partial class AdminWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.logOutButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.exportReportButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mostOrderdDishesButton = new System.Windows.Forms.Button();
            this.orderBetweenDatesButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.setMenuButton = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(250, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(552, 545);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.Red;
            this.logOutButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logOutButton.Location = new System.Drawing.Point(0, 509);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(102, 38);
            this.logOutButton.TabIndex = 1;
            this.logOutButton.Text = "Logout";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(42, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 38);
            this.button3.TabIndex = 3;
            this.button3.Text = "Show Dishes";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // exportReportButton
            // 
            this.exportReportButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.exportReportButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exportReportButton.Location = new System.Drawing.Point(42, 434);
            this.exportReportButton.Name = "exportReportButton";
            this.exportReportButton.Size = new System.Drawing.Size(162, 38);
            this.exportReportButton.TabIndex = 5;
            this.exportReportButton.Text = "ExportReport";
            this.exportReportButton.UseVisualStyleBackColor = false;
            this.exportReportButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(43, 405);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 23);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // mostOrderdDishesButton
            // 
            this.mostOrderdDishesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.mostOrderdDishesButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mostOrderdDishesButton.Location = new System.Drawing.Point(42, 361);
            this.mostOrderdDishesButton.Name = "mostOrderdDishesButton";
            this.mostOrderdDishesButton.Size = new System.Drawing.Size(162, 38);
            this.mostOrderdDishesButton.TabIndex = 7;
            this.mostOrderdDishesButton.Text = "MostOrderDishes";
            this.mostOrderdDishesButton.UseVisualStyleBackColor = false;
            this.mostOrderdDishesButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // orderBetweenDatesButton
            // 
            this.orderBetweenDatesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.orderBetweenDatesButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.orderBetweenDatesButton.Location = new System.Drawing.Point(42, 317);
            this.orderBetweenDatesButton.Name = "orderBetweenDatesButton";
            this.orderBetweenDatesButton.Size = new System.Drawing.Size(162, 38);
            this.orderBetweenDatesButton.TabIndex = 7;
            this.orderBetweenDatesButton.Text = "OrderBetweenDates";
            this.orderBetweenDatesButton.UseVisualStyleBackColor = false;
            this.orderBetweenDatesButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(30, 259);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(202, 23);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(30, 288);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(202, 23);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(220, 107);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(146, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create employee account";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // setMenuButton
            // 
            this.setMenuButton.BackColor = System.Drawing.Color.Lime;
            this.setMenuButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.setMenuButton.Location = new System.Drawing.Point(43, 159);
            this.setMenuButton.Name = "setMenuButton";
            this.setMenuButton.Size = new System.Drawing.Size(161, 38);
            this.setMenuButton.TabIndex = 11;
            this.setMenuButton.Text = "Set Menu";
            this.setMenuButton.UseVisualStyleBackColor = false;
            this.setMenuButton.Click += new System.EventHandler(this.setMenuButton_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(250, 2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(552, 545);
            this.dataGridView3.TabIndex = 12;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.ForestGreen;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(43, 203);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 38);
            this.button4.TabIndex = 11;
            this.button4.Text = "Update Records";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.setMenuButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.orderBetweenDatesButton);
            this.Controls.Add(this.mostOrderdDishesButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.exportReportButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminWindow";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.AdminWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button logOutButton;
        private Button button3;
        private Button exportReportButton;
        private ComboBox comboBox1;
        private Button mostOrderdDishesButton;
        private Button orderBetweenDatesButton;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DataGridView dataGridView2;
        private Button button1;
        private Button setMenuButton;
        private DataGridView dataGridView3;
        private Button button2;
        private Button button4;
    }
}