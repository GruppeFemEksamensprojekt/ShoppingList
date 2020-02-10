﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Model
{
    public class ShoppingListModel
    {
        //Indkøbsliste Model
        public string _shoppinglistName;
        public ObservableCollection<ProductModel> _productCatalog;

        public ShoppingListModel(string shoppinglistName)
        {
            _productCatalog = new ObservableCollection<ProductModel>();

        }

        public ObservableCollection<ProductModel> ProductCatalog
        {
            get 
            {
                return _productCatalog; 
            } 
            set
            {
                _productCatalog = value; 
            } 
        }
        public string ListIsEmpty
        {
            get;
            set;
        }
    }
}
