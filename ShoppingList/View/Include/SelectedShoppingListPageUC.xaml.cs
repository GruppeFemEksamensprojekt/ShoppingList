using ShoppingList.Model;
using ShoppingList.Persistancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ShoppingList.View.Include
{
    public sealed partial class SelectedShoppingListPageUC : UserControl
    {
        public SelectedShoppingListPageUC()
        {
            this.InitializeComponent();
            BoughtListView.DragItemsCompleted += BoughtListView_DragItemsCompleted;
            BaseProductList.DragItemsCompleted += BaseProductList_DragItemsCompleted;
        }

        private void BoughtListView_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            PersistancyService.SaveShopListAsJsonAsync(ShoppingListSingleton.Instance.ShoppingListList);
        }
        private void BaseProductList_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            PersistancyService.SaveShopListAsJsonAsync(ShoppingListSingleton.Instance.ShoppingListList);
        }
    }
}
