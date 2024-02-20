using System;
using UnityEngine;

namespace ZongDemo.Engine.Attributes
{
    public class SerializeReferenceDropdownAttribute : PropertyAttribute
    {
        public Type FieldType { get; }

        public SerializeReferenceDropdownAttribute(Type fieldType)
        {
            FieldType = fieldType;
        }
    }
}