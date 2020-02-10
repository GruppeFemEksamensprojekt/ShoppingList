using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Handlers;
using ShoppingList.Persistancy;

namespace ShoppingList.Model
{
    public sealed class ShoppingListSingleton
    {
        #region Instance Fields

        private static ShoppingListSingleton instance = null;
        public ObservableCollection<ShoppingListModel> ShoppingListList { get; }

        #endregion Instance Fields

        #region Constructors

        private ShoppingListSingleton()
        {
            ShoppingListList = new ObservableCollection<ShoppingListModel>();
            LoadShoppingListAsync();
        }

        #endregion Constructors

        #region Properties

        public static ShoppingListSingleton Instance
        {
            get { return instance ?? (instance = new ShoppingListSingleton()); }
        }

        #endregion Properties

        #region
        public void AddListToCollection(ShoppingListModel eventObj)
        {
            ShoppingListList.Add(eventObj);
        }
        public void Remove(ShoppingListModel eventObj)
        {
            ShoppingListList.Remove(eventObj);
        }
        public async void LoadShoppingListAsync()
        {
            PersistancyService.FileCreation();
            ObservableCollection<ShoppingListModel> shopLists = await PersistancyService.LoadShopListFromJsonAsync();
            ShoppingListSingleton.Instance.ShoppingListList.Clear();
            if (shopLists == null)
            {
                ShoppingListList.Add(new ShoppingListModel("FiskeFars", ViewModel.ViewModel.Category[0]));
                PersistancyService.SaveShopListAsJsonAsync(ShoppingListList);
            }
            else
            {
                foreach (var shopList in shopLists)
                {
                    ShoppingListList.Add(shopList);
                }
            }
        }
        #endregion
    }
}
