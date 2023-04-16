using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Entities;

namespace WinFormsApp1.BL
{
    public class DishService
    {
        private DishDAL dishDAL = null;

        public DishService()
        {
            dishDAL = DishDAL.getInstance();
        }
        public void createDish(String name, Double price, int stock)
        {
            dishDAL.saveDish(new Dish(name, price, stock));
        }

        public void updateStock(int dishId, int newStock)
        {
            dishDAL.updateDish(dishId, newStock);
        }

        public void updateStockWithAmount(int dishId, int amount)
        {
            dishDAL.updateStockWithAmount(dishId, amount);
        }
        public void deleteDish(int dishId)
        {
            dishDAL.deleteDish(dishId);
        }

        public DataTable mostOrderDishes()
        {
           
           return dishDAL.getOrderedDishes();
           
        }

        public DataTable getDishes()
        {
            return dishDAL.getDishesData();
        }

        public void updateMenu(List<int> ids)
        {
            dishDAL.deleteAll();
            dishDAL.createMenu(ids);

        }
        public void updateData(DataTable dt)
        {
            dishDAL.updateData(dt);
        }
    }
}
