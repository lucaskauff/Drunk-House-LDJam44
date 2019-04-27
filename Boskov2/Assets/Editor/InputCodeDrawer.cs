using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Boskov.Inputs
{
    [CustomPropertyDrawer(typeof(InputCode))]
    public class InputCodeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            int inputType = property.FindPropertyRelative("type").enumValueIndex;

            position = EditorGUI.PrefixLabel(position, EditorGUIUtility.GetControlID(FocusType.Passive), label);

            var rect = new Rect(position.position - Vector2.down * 5 + Vector2.left * 3, Vector2.one * 12);
            
            if (EditorGUI.DropdownButton(rect, new GUIContent(EditorGUIUtility.IconContent("LookDevPaneOption")), FocusType.Keyboard, new GUIStyle() { fixedWidth = 50f, border = new RectOffset(1, 1, 1, 1) }))
            {

                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("KeyCode"), inputType == 0, () => SetProperty(property, 0));
                menu.AddItem(new GUIContent("AxisCode"), inputType == 1, () => SetProperty(property, 1));
                menu.AddItem(new GUIContent("Axis"), inputType == 2, () => SetProperty(property, 2));

                menu.ShowAsContext();
            }
            
            position.position += Vector2.right * 15;
            int value = property.FindPropertyRelative("type").enumValueIndex;
            

            if (inputType == 0)
            {
                KeyCode newValue = (KeyCode)property.FindPropertyRelative("keyCode").enumValueIndex;
                newValue = (KeyCode)EditorGUI.EnumPopup(position, newValue);
                value = (int)newValue;
                property.FindPropertyRelative("keyCode").enumValueIndex = value;
            }
            else if( inputType == 1)
            {
                AxisCode newValue = (AxisCode)property.FindPropertyRelative("axisCode").enumValueIndex;
                newValue = (AxisCode)EditorGUI.EnumPopup(position, newValue);
                value = (int)newValue;
                property.FindPropertyRelative("axisCode").enumValueIndex = value;
            }
            else
            {
                Axis newValue = (Axis)property.FindPropertyRelative("axis").enumValueIndex;
                newValue = (Axis)EditorGUI.EnumPopup(position, newValue);
                value = (int)newValue;
                property.FindPropertyRelative("axis").enumValueIndex = value;
            }
            
            EditorGUI.EndProperty();
        }

        private void SetProperty(SerializedProperty property, int value)
        {
            var propRelative = property.FindPropertyRelative("type");
            propRelative.enumValueIndex = value;
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
