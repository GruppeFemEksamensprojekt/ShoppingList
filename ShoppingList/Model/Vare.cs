using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Model
{
    class Vare
    {

        private string _name;
        private int _quantity;
        private string _quantityType;
        private int _price;
        private string _shop;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }



    }
}
