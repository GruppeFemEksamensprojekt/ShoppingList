using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Model;

namespace ShoppingList.Handlers
{
    class SearchHandler
    {
        public bool Bought { get; set; } = false;

        public ObservableCollection<ProductModel> productCatalog { get; set; }

        public SearchHandler()
        {
            productCatalog = new ObservableCollection<ProductModel>();
            Bought = false;
        }
        public ObservableCollection<ProductModel> SearchList1(string search)
        {
            try
            {
                var list = productCatalog.Where(product => product.Name.Contains(search.ToLower()));
                return new ObservableCollection<ProductModel>(list);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Din søgning på {search}, gav ingen resultater\n{e}");
            }

            return null;
        }
    }
}
