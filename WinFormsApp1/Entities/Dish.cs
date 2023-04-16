using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entities
{
    public class Dish
    {
        private int id;
        private String name;
        private Double price;
        private int stock;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }

        }

        public Double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Stock
        {
            get { return stock; }
            set
            {
                stock = value;
            }
        }
        public Dish(string name, double price, int stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
        }
        public Dish(int id, string name, double price, int stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
        }
        public Dish()
        {
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public Double getPrice()
        {
            return price;
        }
        public int getStock()
        {
            return stock;
        }

        public void setStock(int stock)
        {
            this.stock = stock;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setPrice(Double price)
        {
            this.price = price; 
        }
    }
}
