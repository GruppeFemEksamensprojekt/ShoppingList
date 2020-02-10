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

namespace ShoppingList.ViewModel
{
    class ViewModel
    {
        #region Instance Fields
        private ShoppingListModel _selectedShoppingList;
        private double _selectedListTotalPrice;
        #endregion

        #region Constructor
        public ViewModel()
        {
            ShoppingListList = ShoppingListSingleton.Instance.ShoppingListList;
            CreateShoppingListCommand = new RelayCommand(CreateShoppingList, null);
            NavigateToCreateShoppingListCommand = new RelayCommand(NavigateToCreateShoppingList, null);
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
            set { _selectedShoppingList = value; }
        }
        public string CategoryVM { get; set; }
        public string ShoppingListNameVM { get; set; }
        public ICommand CreateShoppingListCommand { get; set; }
        public ICommand NavigateToCreateShoppingListCommand { get; set; }
        #endregion

        #region Methods
        public bool ShoppingListIsSelected()
        {
            return SelectedShoppingList != null;
        }

        public ObservableCollection<ProductModel> SelectedProductList
        {
            get { return SelectedShoppingList.ProductCatalog; }
        }
        public double SelectedListTotalPrice
        {
            get
            {
                foreach (ProductModel item in SelectedShoppingList.ProductCatalog)
                {
                    _selectedListTotalPrice = +item.ItemPrice;
                }
                return _selectedListTotalPrice;
            }
        }
        public void NavigateToCreateShoppingList()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(CreateShoppingList));
        }
        public async void CreateShoppingList()
        {
            ContentDialog messageDialog = new ContentDialog()
            {
                Title = "Fiskemand",
                Content = "Fuck af",
                CloseButtonText = "Bol mig"
            };

            if (string.IsNullOrEmpty(ShoppingListNameVM))
            {
                await messageDialog.ShowAsync();
            }
            else
            {
                ShoppingListSingleton.Instance.ShoppingListList.Add(new ShoppingListModel(ShoppingListNameVM, CategoryVM));
                ((Frame)Window.Current.Content).GoBack();
                PersistancyService.SaveShopListAsJsonAsync(ShoppingListSingleton.Instance.ShoppingListList);

            }
        }

        #endregion
    }
}
