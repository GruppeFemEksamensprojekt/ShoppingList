using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ShoppingList
{
    public static class ObservableCollectionExtensions
    {

        public static void Sort<TSource, Tkey>(this ObservableCollection<TSource> source, Func<TSource, Tkey> keySelector)
        {
            var sortedSource = source.OrderBy(keySelector).ToList();

            for (var i = 0; i < sortedSource.Count; i++)
            {
                var itemToSort = sortedSource[i];

                if (source.IndexOf(itemToSort) == i)
                {
                    continue;
                }

                source.Remove(itemToSort);
                source.Insert(i, itemToSort);
            }
        }

    }
}
