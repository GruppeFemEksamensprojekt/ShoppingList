﻿using ShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.ViewModel
{
    class ViewModel
    {
        #region Instance Fields
        private ShoppingListCatalog _selectedShoppingList;
        #endregion

        #region Constructor
        public ViewModel()
        {

        }
        #endregion

        #region Properties
        public ObservableCollection<ProductModel> ProductList { get; set; }
        public ShoppingListCatalog SelectedShoppingList
        {
            get { return _selectedShoppingList; }
            set { _selectedShoppingList = value; }
        }
        #endregion
        #region Methods
        public bool ShoppingListIsSelected()
        {
            return SelectedShoppingList != null;
        }
        #endregion
    }
}
