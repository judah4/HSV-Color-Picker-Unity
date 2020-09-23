using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace HSVPicker.Editors
{
	[CustomEditor(typeof(ColorPicker), true)]
	[CanEditMultipleObjects]
	public class ColorPickerEditor : Editor
	{
				
		public override void OnInspectorGUI()
		{
			var colorPicker = (ColorPicker)serializedObject.targetObject;

			var color = colorPicker.CurrentColor;
			var editedColor = EditorGUILayout.ColorField("Color", colorPicker.CurrentColor);
			if(editedColor != color)
            {
				colorPicker.CurrentColor = editedColor;
			}

			DrawDefaultInspector();

		}
	}
}
