using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LandscapeGenerator))]
public class LandscapeGeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		LandscapeGenerator landscapeGenerator = (LandscapeGenerator)target;

		if (DrawDefaultInspector()) {
			if (landscapeGenerator.AutoUpdate) {
				landscapeGenerator.GenerateMap();
			}
		}

		if (GUILayout.Button("Generate")) {
			landscapeGenerator.GenerateMap();
		}
	}
}
