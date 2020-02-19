using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Model;

namespace ShoppingList.Handlers
{
    public class FilterHandler
    {
        public ObservableCollection<ProductModel> productCatalogFilters { get; set; }
        public ViewModel.ViewModel ViewModelRef;

        public FilterHandler()
        {
            productCatalogFilters = new ObservableCollection<ProductModel>();
        }
        private ObservableCollection<ProductModel> Filter(string category)
        { 
            List<ProductModel> list = new List<ProductModel>();
            list = ViewModel.ViewModel.ProductListOnSelectedShoppingList.Where(x => x.ItemCatagory == category).ToList();
            return productCatalogFilters = new ObservableCollection<ProductModel>(list);
        }
        public void FilterVeggies()
        {
            Filter("Frugt og Grønt");
        }
        public void FilterMeat()
        {
            Filter("Kød");
        }
        public void FilterDessert()
        {
            Filter("Dessert");
        }
        public void FilterAlcohol()
        {
            Filter("Alkohol");
        }
        public void FilterDairy()
        {
            Filter("Mælkeprodukter");
        }
        public void FilterCandyAndChips()
        {
            Filter("Slik og Chips");
        }
        public void FilterOther()
        {
            Filter("Diverse");
        }
    }
}
