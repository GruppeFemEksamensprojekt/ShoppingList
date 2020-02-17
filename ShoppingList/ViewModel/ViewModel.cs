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
        private ProductModel _selectedShoppingListItemVM;
        private double _selectedListTotalPrice;
        #endregion

        #region Constructor
        public ViewModel()
        {
            StartPageVisibility();
            ShoppingListList = ShoppingListSingleton.Instance.ShoppingListList;
            CreateShoppingListCommand = new RelayCommand(CreateShoppingList, null);
            AddItemToSelectedShoppinglistProductlistCommand = new RelayCommand(AddItemToSelectedShoppinglistProductlistMethod, null);
            DeleteShoppingListCommand = new RelayCommand(DeleteShoppingList, null);
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
        public ObservableCollection<ProductModel> ProductListOnSelectedShoppingList { get; set; }

        public ObservableCollection<ShoppingListModel> ShoppingListList { get; set; }
        public ShoppingListModel SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set 
            { 
                _selectedShoppingList = value;
                if (_selectedShoppingList != null)
                {
                    ProductListOnSelectedShoppingList = _selectedShoppingList.ProductCatalog;
                    RefreshTotalPrice();
                }
                OnPropertyChanged(nameof(ProductListOnSelectedShoppingList));
                OnPropertyChanged(nameof(SelectedListTotalPrice));
                ShowViewShoppinglistPageMethod();
            }
        }
        public string CategoryVM { get; set; }
        public string ShoppingListNameVM { get; set; }
        public string SelectedListTotalPrice { get; set; }
        #region Commands
        public ICommand CreateShoppingListCommand { get; set; }
        public ICommand AddItemToSelectedShoppinglistProductlistCommand { get; set; }
        public ICommand DeleteShoppingListCommand { get; set; }
        public ICommand NavigateToCreateShoppingListCommand { get; set; }
        public ICommand NavigateToCreateItemCommand { get; set; }
        public ICommand NavigateBackToFrontpageCommand { get; set; }
        public ICommand NavigateBackToShoppingListPageCommand { get; set; }
        #endregion

        #region Product Properties
        public string ItemNameVM { get; set; }
        public string StoreVM { get; set; }
        public string ItemAmountVM { get; set; }
        public string ItemAmountTypeVM { get; set; }
        public string ItemPriceVM { get; set; }
        #endregion

        #region  Vibility Properties
        public Visibility ShowFrontPageVisibility { get; set; }
        public Visibility ShowViewShoppinglistPageVisibility { get; set; }
        public Visibility ShowCreateShoppinglistPageVisibility { get; set; }
        public Visibility ShowCreateItemPageVisibility { get; set; }
        #endregion
        #endregion

        #region Methods
        public bool ShoppingListIsSelected()
        {
            return SelectedShoppingList != null;
        }

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
            ShoppingListSingleton.Instance.AddItemToSelectedShoppingList(_selectedShoppingList, new ProductModel(ItemNameVM, StoreVM, ItemAmountVM, ItemAmountTypeVM, ItemPriceVM));
            PersistancyService.SaveShopListAsJsonAsync(ShoppingListSingleton.Instance.ShoppingListList);
            RefreshTotalPrice();
            ShowViewShoppinglistPageMethod();
        }

        public void RefreshVisiblityProperties()
        {
            OnPropertyChanged(nameof(ShowFrontPageVisibility));
            OnPropertyChanged(nameof(ShowViewShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateShoppinglistPageVisibility));
            OnPropertyChanged(nameof(ShowCreateItemPageVisibility));
        }
        public void ChangeVisibility(Visibility frontpage, Visibility showViewShoppingPageVis, Visibility showCreateShoppinglistVis, Visibility showCreateItemPageVis)
        {
            ShowFrontPageVisibility = frontpage;
            ShowViewShoppinglistPageVisibility = showViewShoppingPageVis;
            ShowCreateShoppinglistPageVisibility = showCreateShoppinglistVis;
            ShowCreateItemPageVisibility = showCreateItemPageVis;
        }

        #region "Navigation Methods" - Warning.. NOT VERY DRY CODE
        public void StartPageVisibility()
        {
            _selectedShoppingList = null;
            ChangeVisibility(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
            OnPropertyChanged(nameof(SelectedShoppingList));
            RefreshVisiblityProperties();
        }
        public void ShowViewShoppinglistPageMethod()
        {
            ChangeVisibility(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed);
            RefreshVisiblityProperties();
        }
        public void ShowCreateShoppinglistPageMethod()
        {
            ChangeVisibility(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed);
            RefreshVisiblityProperties();
        }
        public void ShowCreateItemPageMethod()
        {
            ChangeVisibility(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible);
            RefreshVisiblityProperties();
        }
        public void RefreshTotalPrice()
        {
            SelectedListTotalPrice = _selectedShoppingList.TotalProductListPrice;
            OnPropertyChanged(nameof(SelectedListTotalPrice));
        }
        public void DeleteShoppingList()
        {
            if (_selectedShoppingList != null)
            {
                ShoppingListSingleton.Instance.ShoppingListList.Remove(_selectedShoppingList);
                PersistancyService.SaveShopListAsJsonAsync(ShoppingListSingleton.Instance.ShoppingListList);
                StartPageVisibility();
            }
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
