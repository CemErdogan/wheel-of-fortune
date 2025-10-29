using System.Collections.Generic;
using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "WheelItemConfig", menuName = "WheelOfFortuneSystem/Configs/WheelItemConfig")]
    public class WheelItemConfig : ScriptableObject
    {
        [field:SerializeField] public WheelItemData[] WheelItemsData { get; private set; }

        public WheelItemData GetRandomData(WheelOfFortuneBaseType baseType, List<WheelItemData> excludeItems = null, bool skipDeadly = false)
        {
            var filteredItems = new List<WheelItemData>();

            foreach (var item in WheelItemsData)
            {
                if ((item.AppearType & baseType) == 0)
                {
                    continue;
                }
                
                if (excludeItems != null && excludeItems.Contains(item))
                {
                    continue;
                }

                if (skipDeadly && item.IsDeadly)
                {
                    continue;
                }

                filteredItems.Add(item);
            }

            if (filteredItems.Count == 0)
            {
                Debug.LogError($"[WheelItemConfig] No valid wheel items found for base type {baseType}. Returning default item.");
                return new WheelItemData();
            }

            var totalWeight = 0;
            foreach (var item in filteredItems)
            {
                totalWeight += item.Weight;
            }

            var randomValue = Random.Range(0, totalWeight);
            var cumulativeWeight = 0;
            foreach (var item in filteredItems)
            {
                cumulativeWeight += item.Weight;
                if (randomValue < cumulativeWeight)
                {
                    return item;
                }
            }

            Debug.LogError("[WheelItemConfig] Random selection failed. Returning default item.");
            return new WheelItemData();
        }
    }
}