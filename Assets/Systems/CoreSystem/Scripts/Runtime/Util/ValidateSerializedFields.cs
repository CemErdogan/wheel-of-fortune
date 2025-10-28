using System.Reflection;
using UnityEngine;

namespace CoreSystem
{
    public static class ValidationUtility
    {
        public static void ValidateSerializedFields(MonoBehaviour target)
        {
            var fields = target.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        
            foreach (var field in fields)
            {
                var isSerialized = field.GetCustomAttribute<SerializeField>() != null;
                var requiresValidation = field.GetCustomAttribute<ValidateNotNullAttribute>() != null;

                if (!isSerialized || !requiresValidation)
                {
                    continue;
                }
                
                var value = field.GetValue(target);
                if (value == null)
                {
                    Debug.LogWarning($"{field.Name} is not assigned in {target.GetType().Name}", target);
                }
            }
        }
    }
}