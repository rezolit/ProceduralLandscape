using System;
using UnityEngine;

public class NoiseMapView : MonoBehaviour
{
	[SerializeField]
	private Renderer _textureRenderer;

	public void DrawNoiseMap(float[,] noiseMap)
	{
		int mapSizeY = noiseMap.GetLength(0);
		int mapSizeX = noiseMap.GetLength(1);
		
		print(mapSizeY);
		print(mapSizeX);
		
		Color[] colorMap = new Color[mapSizeY * mapSizeX];
		for (int y = 0; y < mapSizeY; y++) {
			for (int x = 0; x < mapSizeX; x++) {
				colorMap[y + mapSizeX * x] = Color.Lerp(Color.black, Color.white, noiseMap[y, x]);
			}
		}

		Texture2D texture = new Texture2D(mapSizeX, mapSizeY);
		texture.SetPixels(colorMap);
		texture.Apply();

		_textureRenderer.sharedMaterial.mainTexture = texture;
		_textureRenderer.transform.localScale = new Vector3(mapSizeX, 1, mapSizeY);
	}
}
