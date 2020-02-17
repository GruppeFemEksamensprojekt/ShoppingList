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
        private ObservableCollection<ProductModel> productCatalogFilters { get; set; }
        private ViewModel.ViewModel ViewModelRef;

        private FilterHandler()
        {
            productCatalogFilters = new ObservableCollection<ProductModel>();
        }
        

        private ObservableCollection<ProductModel> Filter(string category)
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
