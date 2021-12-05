    
    using System;
    using UnityEngine;
    public interface IItemInfo
    {
         string Name { get; }
         string Description { get; }
         Sprite Icon { get; }
         ItemType ItemType { get; }
         int MaxQuantity { get; }
         Type Type { get; }
         GameObject GameObject { get; }
    }