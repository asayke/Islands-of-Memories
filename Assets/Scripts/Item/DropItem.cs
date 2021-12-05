
using System;
using UnityEngine;

[Serializable]
public class DropItem : MonoBehaviour
{
    [SerializeField] private ItemInfo _itemInfo;
    public ItemInfo ItemInfo => _itemInfo;
}
