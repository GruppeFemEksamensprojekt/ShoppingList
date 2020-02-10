using ShoppingList.Model;
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
        public ObservableCollection<ProductModel> ProductList { get; set; }
    }
}
