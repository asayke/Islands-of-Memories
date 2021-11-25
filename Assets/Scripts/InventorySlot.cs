
    using System.Collections.Generic;
    using System;
    using NUnit.Framework;
    using UnityEngine;
    using static MaxQuantity;
    
    //TODO сделать pattern matching в зависимости от типа предмета закастить INFO. НЕ ТУТ!!!
    public class InventorySlot : IInventorySlot
    {
        public bool IsFull => !IsEmpty && Item.Info.MaxQuantity == Item.State.Amount;
        
        public bool IsEmpty => Item == null;
        public IItem Item { get; private set; }
        
        public int Amount => IsEmpty ? 0 : Item.State.Amount;

        public void Set(IItem item)
        {
            if (!IsEmpty)
                return;
            this.Item = item;
        }

        public void Clear()
        {
            if (IsEmpty)
                return;
            
            Item.State.Amount = 0;
            this.Item = null;
        }
    }
