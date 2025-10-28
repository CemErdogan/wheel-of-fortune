using System;
using UnityEngine;

namespace CoreSystem
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ValidateNotNullAttribute : PropertyAttribute { }
}