﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using ShoppingList.Model;

namespace ShoppingList.Persistancy
{
    public class PersistancyService
    {
        private static string jsonFileNameShopList = "ShoppingListsAsJson.dat";


        public static async void SaveShopListAsJsonAsync(ObservableCollection<ShoppingListModel> shoppingList)
        {
            string shoppingListJsonString = JsonConvert.SerializeObject(shoppingList);
            SerializeShopListFileAsync(shoppingListJsonString, jsonFileNameShopList);
        }
        public static async Task<ObservableCollection<ShoppingListModel>> LoadShopListFromJsonAsync()
        {
            string shoppingListJsonString = await DeSerializeFileAsync(jsonFileNameShopList);
            return (ObservableCollection<ShoppingListModel>)JsonConvert.DeserializeObject(shoppingListJsonString, typeof(ObservableCollection<ShoppingListModel>));
        }
        public static async void SerializeShopListFileAsync(string eventString, string fileName)
        {
            StorageFile localFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                    CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventString);
        }
        public static async Task<string> DeSerializeFileAsync(string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }

        public static async void FileCreation()
        {
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(jsonFileNameShopList);
            if (item == null)
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(jsonFileNameShopList);
            }
        }
    }
}
