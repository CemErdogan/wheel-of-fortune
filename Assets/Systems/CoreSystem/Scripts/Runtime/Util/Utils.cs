using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoreSystem
{
    public static class Utils
    {
        public static T GetRandomWithLuck<T>(this List<T> values, List<float> lucks)
        {
            var index = GetItemByLuck(lucks);
            return values[index];
        }
        
        public static T GetRandom<T>(this IEnumerable<T> values)
        {
            return values.ElementAt(UnityEngine.Random.Range(0, values.Count()));
        }
        
        private static int GetItemByLuck(List<float> lucks)
        {
            float total = 0;

            foreach (var item in lucks)
            {
                total += item;
            }

            var randomPoint = Random.value * total;

            for (int i = 0; i < lucks.Count; i++)
            {
                if (randomPoint < lucks[i])
                {
                    return i;
                }

                randomPoint -= lucks[i];
            }

            return lucks.Count - 1;
        }
    }
}