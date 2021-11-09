
    using System;
    using UnityEngine;

    public class UIInventory : MonoBehaviour
    {
        [SerializeField] private ItemInfo _info1;
        [SerializeField] private ItemInfo _info2;
        public Inventory Inventory { get; private set; }

        private void Awake()
        {
            Inventory = new Inventory(20);
            Inventory.TryToAdd(new Item(_info1));
            Inventory.TryToAdd(new Item(_info2));
        }
    }
