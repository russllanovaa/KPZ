# KPZ — Конструювання програмного забезпечення

Лабораторні роботи з дисципліни «Конструювання програмного забезпечення».

## Лабораторна робота №2 — Restaurant Management (WPF, MVVM)

Десктопний застосунок для обліку **замовлень** і **меню** ресторану, побудований на **WPF** за шаблоном **MVVM**.

### Можливості

- Перемикання між розділами **«Замовлення»** та **«Меню»**
- Додавання, видалення та редагування замовлень і позицій меню в таблицях (`DataGrid`)
- Збереження даних у **JSON-файли** (`orders.json`, `menu.json`) і завантаження під час запуску
- Власний елемент керування `StatusIndicator` для відображення статусу
- Конвертери значень для прив'язки даних (`BoolToStatusConverter`, `NullToVisibilityConverter`)

### Технології

- **C# / .NET 8**, **WPF**
- Шаблон **MVVM**: `BaseViewModel` з `INotifyPropertyChanged`, команди через `RelayCommand` (`ICommand`)
- **Riok.Mapperly** — мапінг моделей у ViewModel
- `System.Text.Json` — серіалізація

### Структура

```
lab2/RestaurantManagement/RestaurantManagement/
├── Models/         # Order, MenuItem
├── ViewModels/     # MainViewModel, OrdersViewModel, MenuViewModel
├── Views/          # OrdersView, MenuView
├── Commands/       # RelayCommand
├── Controls/       # StatusIndicator
├── Converters/     # конвертери для data binding
├── Mappers/        # RestaurantMapper (Mapperly)
├── Services/       # DataService — читання/запис JSON
└── Styles/         # стилі DataGrid
```

### Запуск

**Потрібно:** Windows, .NET 8 SDK, Visual Studio 2022.

Відкрийте `lab2/RestaurantManagement/RestaurantManagement.sln` і запустіть (F5), або:

```bash
dotnet run --project lab2/RestaurantManagement/RestaurantManagement
```
