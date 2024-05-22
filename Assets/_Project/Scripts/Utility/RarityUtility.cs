using System.Collections.Generic;
using UnityEngine;

public static class RarityUtility
{

    private static Dictionary<Rarity, float> _rarityWeights = new()
    {
        { Rarity.Common, 0.5f },
        { Rarity.Uncommon, 0.3f },
        { Rarity.Rare, 0.1f },
        { Rarity.Exotic, 0.07f },
        { Rarity.Legendary, 0.03f }
    };
    
    /// <summary>
    /// Selects an item from a given list based on their rarities
    /// </summary>
    /// <param name="items">A collection of items</param>
    /// <typeparam name="T">IRarity</typeparam>
    /// <returns>An item from the given list</returns>
    public static T SelectByRarity<T>(List<T> items) where T : IRarity
    {
        List<KeyValuePair<T, float>> weightedItems = new List<KeyValuePair<T, float>>();
        float totalWeight = 0f;

        foreach (var item in items)
        {
            float weight = _rarityWeights[item.Rarity];
            weightedItems.Add(new KeyValuePair<T, float>(item, weight));
            totalWeight += weight;
        }
        
        float randomValue = Random.value * totalWeight;
        foreach (var weightedItem in weightedItems)
        {
            if (randomValue < weightedItem.Value)
            {
                return weightedItem.Key;
            }
            randomValue -= weightedItem.Value;
        }

        return default;
    }
}

public interface IRarity
{
    Rarity Rarity { get; }
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Exotic,
    Legendary 
}