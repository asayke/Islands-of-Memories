using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Equipment")]
public class Equipment : Item
{
    [SerializeField] private double _durability;
}
        