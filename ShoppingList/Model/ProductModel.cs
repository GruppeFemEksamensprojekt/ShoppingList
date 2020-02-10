using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Model
{
    public class ProductModel
    {
        // Vare model
        public string _itemName;
        public string _store;
        public int _itemAmount;
        public double _itemPrice;

        public ProductModel(string itemName, string store, int itemAmount, double itemPrice)
        {
            _itemName = itemName;
            _store = store;
            _itemAmount = itemAmount;
            _itemPrice = itemPrice;
        }

        public string ItemName { get; set; }
        public string Store { get; set; }
        public int ItemAmount { get; set; }
        public double ItemPrice { get; set; }
    }
}
