using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RestaurantManagement.Commands;
using RestaurantManagement.Models;
using RestaurantManagement.Services;

namespace RestaurantManagement.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private readonly DataService _dataService;
        private Order _selectedOrder;

        public OrdersViewModel(DataService dataService)
        {
            _dataService = dataService;
            Orders = new ObservableCollection<Order>(_dataService.LoadOrders());

            AddOrderCommand = new RelayCommand(_ => AddOrder());
            DeleteOrderCommand = new RelayCommand(_ => DeleteOrder(), _ => SelectedOrder != null);
            SaveOrdersCommand = new RelayCommand(_ => SaveOrders());
        }

        public static List<string> OrderStatuses => new List<string>
        {
            "Pending",
            "Preparing",
            "Completed",
            "Cancelled"
        };

        public ObservableCollection<Order> Orders { get; }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => SetProperty(ref _selectedOrder, value);
        }

        public ICommand AddOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }
        public ICommand SaveOrdersCommand { get; }

        private void AddOrder()
        {
            var newOrder = new Order
            {
                Id = Orders.Count > 0 ? Orders.Max(o => o.Id) + 1 : 1,
                CustomerName = "Новий клієнт",
                OrderDate = System.DateTime.Now,
                TotalAmount = 0,
                Status = "Pending"
            };
            Orders.Add(newOrder);
            SelectedOrder = newOrder;
        }

        private void DeleteOrder()
        {
            if (SelectedOrder != null)
            {
                Orders.Remove(SelectedOrder);
                SelectedOrder = null;
            }
        }

        private void SaveOrders()
        {
            _dataService.SaveOrders(Orders.ToList());
        }
    }
}