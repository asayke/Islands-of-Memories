using System;
using UnityEngine;

public interface IItem
{ 
    string Name { get; } 
    Sprite Icon { get; }
    Recipe Recipe { get; }
    ItemType ItemType { get; }
}
