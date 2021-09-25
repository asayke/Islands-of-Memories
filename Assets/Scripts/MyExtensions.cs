using System;
using System.Collections.Generic;
using UnityEngine;




namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static bool TryGetItemIndex (this List<SerializableKeyValuePair<Item,int>> enumerable, Item item, out int index)
        {
            bool res = false;
            index = -1;
            for (var i = 0; i < enumerable.Count; i++)
            {
                if (enumerable[i].Key.Name == item.Name)
                {
                    index = i;
                    res = true;
                }
            }
            return res;
        }

        public static SerializableKeyValuePair<Item,int> FindKeyValuePair (this List<SerializableKeyValuePair<Item,int>> enumerable, Item item)
        {
            foreach (var x in  enumerable)
            {
                if (x.Key.Name == item.Name)
                    return x; 
            }
            return default(SerializableKeyValuePair<Item,int>);
        }
        
        public static void SetAmount(this List<SerializableKeyValuePair<Item, int>> enumerable, Item item,
            int newAmount) => enumerable.FindKeyValuePair(item).Value = newAmount;
    }
}