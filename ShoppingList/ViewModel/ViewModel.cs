using ShoppingList.Handlers;
using ShoppingList.Model;
using ShoppingList.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ShoppingList.Persistancy;
using Windows.UI.Popups;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingList.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Instance Fields
        private ShoppingListModel _selectedShoppingList;
        private double _selectedListTotalPrice;
        #endregion

        #region Constructor
        public ViewModel()
        {
            StartPageVisibility();
            ShoppingListList = ShoppingListSingleton.Instance.ShoppingListList;
            CreateShoppingListCommand = new RelayCommand(CreateShoppingList, null);
            AddItemToSelectedShoppinglistProductlistCommand = new RelayCommand(AddItemToSelectedShoppinglistProductlistMethod, null);

            NavigateToCreateShoppingListCommand = new RelayCommand(ShowCreateShoppinglistPageMethod, null);
            NavigateToCreateItemCommand = new RelayCommand(ShowCreateItemPageMethod, null);
            NavigateBackToFrontpageCommand = new RelayCommand(StartPageVisibility, null);
            NavigateBackToShoppingListPageCommand = new RelayCommand(ShowViewShoppinglistPageMethod, null);
        }
        #endregion

        #region Properties
        public static List<string> Category
        {
            get
            {
                return new List<string> { "Opskrift", "Dagligvarer", "Sexlegetøj", "Andet" };
            }
        }
        public ObservableCollection<ProductModel> ProductList { get; set; }
        public ObservableCollection<ShoppingListModel> ShoppingListList { get; set; }
        public ShoppingListModel SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set 
            { 
                _selectedShoppingList = value;
                ShowViewShoppinglistPageMethod();
            }
        }
        public string CategoryVM { get; set; }
        public string ShoppingListNameVM { get; set; }
        public double SelectedListTotalPrice
        {
            get
            {
                foreach (ProductModel item in SelectedShoppingList.ProductCatalog)
                {
                    _selectedListTotalPrice =+ item.ItemPrice;
                }
                return _selectedListTotalPrice;
            }
        }
        #region Commands
        public ICommand CreateShoppingListCommand { get; set; }
        public ICommand AddItemToSelectedShoppinglistProductlistCommand { get; set; }

        public ICommand NavigateToCreateShoppingListCommand { get; set; }
        public ICommand NavigateToCreateItemCommand { get; set; }
        public ICommand NavigateBackToFrontpageCommand { get; set; }
        public ICommand NavigateBackToShoppingListPageCommand { get; set; }
        #endregion

        //public ObservableCollection<ProductModel> SelectedProductList
        //{
        //    get { return _selectedShoppingList.ProductCatalog; }
        //}

        #region Product Properties
        public string ItemNameVM { get; set; }
        public string StoreVM { get; set; }
        public int ItemAmountVM { get; set; }
        public string ItemAmountTypeVM { get; set; }
        public double ItemPriceVM { get; set; }
        #endregion

        #region Vibility Properties
        public Visibility ShowFrontPageVisibility { get; set; }
        public Visibility ShowViewShoppinglistPageVisibility { get; set; }
        public Visibility ShowCreateShoppinglistPageVisibility { get; set; }
        public Visibility ShowCreateItemPageVisibility { get; set; }
        #endregion
        #endregion

        #region Methods
        public async void CreateShoppingList()
        {
            ContentDialog messageDialog = new ContentDialog()
            {
                Title = "Fiskemand",
                Content = "Fuck af",
                CloseButtonText = "Bol mig"
            };

            if (string.IsNullOrEmpty(ShoppingListNameVM) || string.IsNullOrEmpty(CategoryVM))
            {
                await messageDialog.ShowAsync();
            }
            else
            {
                ShoppingListSingleton.Instance.ShoppingListList.Add(new ShoppingListModel(ShoppingListNameVM, CategoryVM));
                StartPageVisibility();
                PersistancyService.SaveShopListAsJsonAsync(ShoppingListSingleton.Instance.ShoppingListList);

            }
        }




        public void AddItemToSelectedShoppinglistProductlistMethod()
        {
            //_selectedShoppingList.ProductCatalog.Add(new ProductModel(ItemNameVM, StoreVM, ItemAmountVM, ItemAmountTypeVM, ItemPriceVM));
            ShoppingListSingleton.Instance.AddItemToSelectedShoppingList(_selectedShoppingList, new ProductModel(ItemNameVM, StoreVM, ItemAmountVM, ItemAmountTypeVM, ItemPriceVM));
            PersistancyService.SaveShopListAsJsonAsync(ShoppingListSingleton.Instance.ShoppingListList);
        }




        public bool ShoppingListIsSelected()
        {
            return SelectedShoppingList != null;
        }

        #region "Navigation Methods" - Warning.. NOT VERY DRY CODE
        public void StartPageVisibility()
        {
            _selectedShoppingList = null;
            ShowFrontPageVisibility = Visibility.Visible;
            ShowViewShoppinglistPageVisibility = Visibility.Collapsed;
            ShowCreateShoppinglistPageVisibility = Visibility.Collapsed;
            ShowCreateItemPageVisibility = Visibility.Collapsed;
            OnPropertyChanged(nameof(SelectedShoppingList));
            OnPropertyChanged(nameof(ShowFrontPageVisibility));
            OnPropertyChanged(nameof(ShowViewShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateItemPageVisibility));
        }
        public void ShowViewShoppinglistPageMethod()
        {
            ShowFrontPageVisibility = Visibility.Collapsed;
            ShowViewShoppinglistPageVisibility = Visibility.Visible;
            ShowCreateShoppinglistPageVisibility = Visibility.Collapsed;
            ShowCreateItemPageVisibility = Visibility.Collapsed;
            OnPropertyChanged(nameof(ShowFrontPageVisibility));
            OnPropertyChanged(nameof(ShowViewShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateItemPageVisibility));
        }
        public void ShowCreateShoppinglistPageMethod()
        {
            ShowFrontPageVisibility = Visibility.Collapsed;
            ShowViewShoppinglistPageVisibility = Visibility.Collapsed;
            ShowCreateShoppinglistPageVisibility = Visibility.Visible;
            ShowCreateItemPageVisibility = Visibility.Collapsed;
            OnPropertyChanged(nameof(ShowFrontPageVisibility));
            OnPropertyChanged(nameof(ShowViewShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateItemPageVisibility));
        }
        public void ShowCreateItemPageMethod()
        {
            ShowFrontPageVisibility = Visibility.Collapsed;
            ShowViewShoppinglistPageVisibility = Visibility.Collapsed;
            ShowCreateShoppinglistPageVisibility = Visibility.Collapsed;
            ShowCreateItemPageVisibility = Visibility.Visible;
            OnPropertyChanged(nameof(ShowFrontPageVisibility));
            OnPropertyChanged(nameof(ShowViewShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateItemPageVisibility));
        }
        #endregion
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
