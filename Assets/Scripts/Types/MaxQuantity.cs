using System.Collections.Generic;

public static class MaxQuantity
{
    /// <summary>
    /// Максимальное количество предметов разных типов в слоте,
    /// </summary>
    public static readonly Dictionary<ItemType, int> Quantity = new Dictionary<ItemType, int>()
    {
        [ItemType.Equipment] = 1,
        [ItemType.Tools] = 1,
        [ItemType.Weapons] = 1,
        [ItemType.Food] = 64,
        [ItemType.Foraging] = 64,
        [ItemType.Mining] = 20,
        [ItemType.None] = 1,
    };
}