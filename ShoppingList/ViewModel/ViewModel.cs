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

namespace ShoppingList.ViewModel
{
    class ViewModel
    {
        #region Instance Fields
        private ShoppingListModel _selectedShoppingList;
        #endregion

        #region Constructor
        public ViewModel()
        {
            ShoppingListList = new ObservableCollection<ShoppingListModel>();
            ShoppingListList.Add(new ShoppingListModel("FiskeFars"));
            CreateShoppingListCommand = new RelayCommand(CreateShoppingList, null);
            NavigateToCreateShoppingListCommand = new RelayCommand(NavigateToCreateShoppingList, null);
        }
        #endregion

        #region Properties
        public ObservableCollection<ProductModel> ProductList { get; set; }
        public ObservableCollection<ShoppingListModel> ShoppingListList { get; set; }
        public ShoppingListModel SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set { _selectedShoppingList = value; }
        }
        public string ShoppingListNameVM { get; set; }
        public ICommand CreateShoppingListCommand { get; set; }
        public ICommand NavigateToCreateShoppingListCommand { get; set; }
        #endregion

        #region Methods
        public bool ShoppingListIsSelected()
        {
            return SelectedShoppingList != null;
        }

        public void NavigateToCreateShoppingList()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(CreateShoppingList));
        }
        public void CreateShoppingList()
        {
            ShoppingListList.Add(new ShoppingListModel(ShoppingListNameVM));
        }

        #endregion
    }
}
