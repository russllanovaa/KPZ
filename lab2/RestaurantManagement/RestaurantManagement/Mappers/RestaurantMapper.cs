using RestaurantManagement.Models;
using Riok.Mapperly.Abstractions;

namespace RestaurantManagement.Mappers
{
    [Mapper]
    public static partial class RestaurantMapper
    {
        public static partial MenuItem MapToMenuItem(MenuItemDto dto);
        public static partial MenuItemDto MapToMenuItemDto(MenuItem item);
        public static partial Order MapToOrder(OrderDto dto);
        public static partial OrderDto MapToOrderDto(Order order);
    }

    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}