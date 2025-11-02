using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RestaurantManagement.Models;

namespace RestaurantManagement.Services
{
    public class DataService
    {
        private const string OrdersFile = "orders.json";
        private const string MenuFile = "menu.json";

        public List<Order> LoadOrders()
        {
            if (!File.Exists(OrdersFile))
                return GetDefaultOrders();

            var json = File.ReadAllText(OrdersFile);
            return JsonSerializer.Deserialize<List<Order>>(json) ?? GetDefaultOrders();
        }

        public void SaveOrders(List<Order> orders)
        {
            var json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(OrdersFile, json);
        }

        public List<MenuItem> LoadMenuItems()
        {
            if (!File.Exists(MenuFile))
                return GetDefaultMenu();

            var json = File.ReadAllText(MenuFile);
            return JsonSerializer.Deserialize<List<MenuItem>>(json) ?? GetDefaultMenu();
        }

        public void SaveMenuItems(List<MenuItem> menuItems)
        {
            var json = JsonSerializer.Serialize(menuItems, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(MenuFile, json);
        }

        private List<Order> GetDefaultOrders()
        {
            return new List<Order>
            {
                new Order { Id = 1, CustomerName = "Олена Сітнікова", OrderDate = System.DateTime.Now, TotalAmount = 450, Status = "Completed" },
                new Order { Id = 2, CustomerName = "Даяна Нойниць", OrderDate = System.DateTime.Now, TotalAmount = 320, Status = "Preparing" },
                new Order { Id = 3, CustomerName = "Ілля Бабич", OrderDate = System.DateTime.Now, TotalAmount = 280, Status = "Pending" }
            };
        }

        private List<MenuItem> GetDefaultMenu()
        {
            return new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Рамен", Description = "Традиційний японський рамен, добре смакує гострим", Price = 250, Category = "Перші страви", IsAvailable = true },
                new MenuItem { Id = 2, Name = "Піца маргарита", Description = "Ферментоване тісто та фермерський сир, що ідеально поєднюються", Price = 320, Category = "Основні страви", IsAvailable = true },
                new MenuItem { Id = 3, Name = "Салат Цезар", Description = "Салат з куркою та соусом Цезар", Price = 250, Category = "Салати", IsAvailable = true },
                new MenuItem { Id = 4, Name = "Тірамісу", Description = "Італійський десерт", Price = 190, Category = "Десерти", IsAvailable = false }
            };
        }
    }
}