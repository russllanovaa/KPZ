using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RestaurantManagement.Commands;
using RestaurantManagement.Models;
using RestaurantManagement.Services;

namespace RestaurantManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly DataService _dataService;
        private BaseViewModel _currentViewModel;

        public MainViewModel()
        {
            _dataService = new DataService();
            OrdersViewModel = new OrdersViewModel(_dataService);
            MenuViewModel = new MenuViewModel(_dataService);

            CurrentViewModel = OrdersViewModel;

            ShowOrdersCommand = new RelayCommand(_ => CurrentViewModel = OrdersViewModel);
            ShowMenuCommand = new RelayCommand(_ => CurrentViewModel = MenuViewModel);
        }

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public OrdersViewModel OrdersViewModel { get; }
        public MenuViewModel MenuViewModel { get; }

        public ICommand ShowOrdersCommand { get; }
        public ICommand ShowMenuCommand { get; }
    }
}