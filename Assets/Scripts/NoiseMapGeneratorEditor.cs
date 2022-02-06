using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NoiseMapGenerator))]
public class NoiseMapGeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		NoiseMapGenerator mapGenerator = (NoiseMapGenerator)target;

		if (DrawDefaultInspector()) {
			if (mapGenerator.AutoUpdate) {
				mapGenerator.GenerateMap();
			}
		}

		if (GUILayout.Button("Generate")) {
			mapGenerator.GenerateMap();
		}
	}
}
