using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RestaurantManagement.Commands;
using RestaurantManagement.Models;
using RestaurantManagement.Services;

namespace RestaurantManagement.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly DataService _dataService;
        private MenuItem _selectedMenuItem;

        public MenuViewModel(DataService dataService)
        {
            _dataService = dataService;
            MenuItems = new ObservableCollection<MenuItem>(_dataService.LoadMenuItems());

            AddMenuItemCommand = new RelayCommand(_ => AddMenuItem());
            DeleteMenuItemCommand = new RelayCommand(_ => DeleteMenuItem(), _ => SelectedMenuItem != null);
            SaveMenuCommand = new RelayCommand(_ => SaveMenu());
        }

        public static List<string> Categories => new List<string>
        {
            "Перші страви",
            "Основні страви",
            "Салати",
            "Десерти",
            "Напої",
            "Закуски"
        };

        public ObservableCollection<MenuItem> MenuItems { get; }

        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }

        public ICommand AddMenuItemCommand { get; }
        public ICommand DeleteMenuItemCommand { get; }
        public ICommand SaveMenuCommand { get; }

        private void AddMenuItem()
        {
            var newItem = new MenuItem
            {
                Id = MenuItems.Count > 0 ? MenuItems.Max(m => m.Id) + 1 : 1,
                Name = "Нова страва",
                Description = "Опис страви",
                Price = 0,
                Category = "Основні",
                IsAvailable = true
            };
            MenuItems.Add(newItem);
            SelectedMenuItem = newItem;
        }

        private void DeleteMenuItem()
        {
            if (SelectedMenuItem != null)
            {
                MenuItems.Remove(SelectedMenuItem);
                SelectedMenuItem = null;
            }
        }

        private void SaveMenu()
        {
            _dataService.SaveMenuItems(MenuItems.ToList());
        }
    }
}