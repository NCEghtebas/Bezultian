using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Map))]
[CanEditMultipleObjects]
[System.Serializable]
public class MapEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Map map= (Map)target;
		if(GUILayout.Button("Create Map"))
		{
			map.reset ();
			map.create ();
			EditorUtility.SetDirty (target);
		}
	}
}
