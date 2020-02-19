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
        private ObservableCollection<ProductModel> _boughtProductList;

        public ShoppingListModel(string shoppinglistName, string category)
        {
            _shoppinglistName = shoppinglistName;
            Category = category;
            _productCatalog = new ObservableCollection<ProductModel>();
            _boughtProductList = new ObservableCollection<ProductModel>();

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
        public ObservableCollection<ProductModel> BoughtProductList
        {
            get { return _boughtProductList; }
            set { _boughtProductList = value; }
        }

        public string Category { get; set; }
        public string TotalProductListPrice
        {
            get
            {
                double result = 0;
                foreach (ProductModel item in ProductCatalog)
                {
                    result += Convert.ToDouble(item.ItemPrice);
                }
                foreach (ProductModel item in BoughtProductList)
                {
                    result += Convert.ToDouble(item.ItemPrice);
                }
                return "Total pris: " + result + ",-";
            }
        }
        public string ListIsEmpty
        {
            get;
            set;
        }
    }
}
