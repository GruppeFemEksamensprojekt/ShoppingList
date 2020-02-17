using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml.Controls;
using ShoppingList.Annotations;
using ShoppingList.Model;

namespace ShoppingList.Handlers
{
    class SearchHandler : INotifyPropertyChanged
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
                 ContentDialog NoNameSearch = new ContentDialog()
                {
                    Title = "No result from namesearch",
                    Content = $"Din søgning på produktet {search}, gav ingen resultater\n{e}",
                    CloseButtonText = "Ok"
                };
                NoNameSearch.ShowAsync();
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
                ContentDialog NoStoreSearch = new ContentDialog()
                {
                    Title = "No result from namesearch",
                    Content = $"Din søgning på produktet {search}, gav ingen resultater\n{e}",
                    CloseButtonText = "Ok"
                };

            }

            return null;
        }

        public ObservableCollection<ProductModel> SearchEngine(string search)
        {
            ObservableCollection<ProductModel> Result = new ObservableCollection<ProductModel>();
            ObservableCollection<ProductModel> Result1 = (SearchListName(search));
            ObservableCollection<ProductModel> Result2 = (SearchListStore(search));
            foreach (var result in Result1)
            {
                Result.Add(result);
            }
            foreach (var result in Result2)
            {
                Result.Add(result);
            }
            OnPropertyChanged();
            return Result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}