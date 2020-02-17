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
        

        public ObservableCollection<ProductModel> Filter(string category)
        {
           var list = ViewModelRef.ProductListOnSelectedShoppingList.Where(x => x.ItemCatagory == category);
           return new ObservableCollection<ProductModel>(list);
        }
        public void FilterVeggies()
        {
            Filter("Frugt & Grønt");
        }
        public void FilterMeat()
        {
            Filter("Kød");
        }
        public void FilterGeneral()
        {
            Filter("Generalt");
        }
        public void FilterToiletPaper()
        {
            Filter("Toiletpapir");
        }
        public void FilterDairy()
        {
            Filter("Majeriprodukter");
        }
    }
}
