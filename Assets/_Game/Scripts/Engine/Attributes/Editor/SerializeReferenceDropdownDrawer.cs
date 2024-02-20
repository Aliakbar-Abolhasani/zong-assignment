using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ZongDemo.Engine.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(SerializeReferenceDropdownAttribute))]
    public class SerializeReferenceDropdownDrawer : PropertyDrawer
    {
        private bool _isInitialized;
        private Type[] _types;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                _types = GetClasses((attribute as SerializeReferenceDropdownAttribute).FieldType);
            }

            var typeName = property.managedReferenceValue?.GetType().Name ?? "Unset";
            var rect = position;
            rect.x += EditorGUIUtility.labelWidth + 2;
            rect.width -= EditorGUIUtility.labelWidth + 2;
            rect.height = EditorGUIUtility.singleLineHeight;

            if (EditorGUI.DropdownButton(rect, new GUIContent(typeName), FocusType.Passive))
            {
                var menu = new GenericMenu();
                foreach (var type in _types)
                {
                    menu.AddItem(new GUIContent(type.Name), typeName == type.Name, () =>
                    {
                        property.managedReferenceValue = Activator.CreateInstance(type);
                        property.serializedObject.ApplyModifiedProperties();
                    });
                }

                menu.ShowAsContext();
            }

            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, position.height), property, label, true);
        }

        private static Type[] GetClasses(Type baseType)
        {
            return Assembly.GetAssembly(baseType).GetTypes().Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t)).ToArray();
        }
    }
}