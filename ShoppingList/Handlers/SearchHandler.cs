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

        public ObservableCollection<ProductModel> SearchListName(string search)
        {
            try
            {
                var list = productCatalog.Where(product => product.ItemName.Contains(search.ToLower().ToLower()));
                return new ObservableCollection<ProductModel>(list);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Din søgning på produktet {search}, gav ingen resultater\n{e}");
            }

            return null;
        }

        public ObservableCollection<ProductModel> SearchListStore(string search)
        {
            try
            {
                var list = productCatalog.Where(product => product.Store.ToLower().Contains(search.ToLower()));
                return new ObservableCollection<ProductModel>(list);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Din søgning på butikken {search}, gav ingen resultater\n{e}");
            }

            return null;
        }

        public ObservableCollection<ProductModel> SearchEngine(string search)
        {
            try
            {
                if (SearchListName(search) == null)
                {
                    SearchListStore(search);
                }
                else if (SearchListStore(search) == null)
                {
                    SearchListName(search);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Din søgning på butikken {search}, gav ingen resultater\n{e}");
            }

            return null;
        }
    }
}