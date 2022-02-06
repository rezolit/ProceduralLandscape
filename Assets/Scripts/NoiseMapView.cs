using System;
using UnityEngine;

public class NoiseMapView : MonoBehaviour
{
	[SerializeField]
	private Renderer _textureRenderer;

	public void DrawNoiseMap(float[,] noiseMap)
	{
		int width = noiseMap.GetLength(0);
		int height = noiseMap.GetLength(1);
		
		Color[] colorMap = new Color[width * height];
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
			}
		}

		Texture2D texture = new Texture2D(width, height);
		texture.SetPixels(colorMap);
		texture.Apply();

		_textureRenderer.sharedMaterial.mainTexture = texture;
		_textureRenderer.transform.localScale = new Vector3(width, 1, height);
	}
}
