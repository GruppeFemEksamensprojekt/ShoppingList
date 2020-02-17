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
        private string _itemName;
        private string _store;
        private int _itemAmount;
        private string _itemAmountType;
        private double _itemPrice;

        public ProductModel(string itemName, string store, int itemAmount, string itemAmountType, double itemPrice)
        {
            _itemName = itemName;
            _store = store;
            _itemAmount = itemAmount;
            _itemAmountType = itemAmountType;
            _itemPrice = itemPrice;
        }

        public string ItemName { get { return _itemName; } set { _itemName = value; } }
        public string Store { get { return _store; } set { _store = value; } }
        public int ItemAmount { get { return _itemAmount; } set { _itemAmount = value; } }
        public string ItemAmountType { get { return _itemAmountType; } set { _itemAmountType = value; } }
        public double ItemPrice { get { return _itemPrice; } set { _itemPrice = value; } }
    }
}
