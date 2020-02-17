using System;
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
        private string _shoppinglistName;
        private ObservableCollection<ProductModel> _productCatalog;

        public ShoppingListModel(string shoppinglistName, string category)
        {
            _shoppinglistName = shoppinglistName;
            Category = category;
            _productCatalog = new ObservableCollection<ProductModel>();

        }

        public string ShoppinglistName { get { return _shoppinglistName; } set { _shoppinglistName = value; } }
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

        public string Category { get; set; }
        public string TotalProductListPrice 
        { 
            get
            {
                double result = 0;
                foreach (ProductModel item in this.ProductCatalog)
                {
                    result += Convert.ToDouble(item.ItemPrice);
                }
                return "Total pris: "+result+",-";
            } 
        }
        public string ListIsEmpty
        {
            get;
            set;
        }
    }
}
