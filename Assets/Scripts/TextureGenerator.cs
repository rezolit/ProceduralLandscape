using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
	public static Texture2D GenerateGrayscaleTextureFromHeightmap(float[,] heightMap)
	{
		int width = heightMap.GetLength(0);
		int height = heightMap.GetLength(1);
		
		Color[] colorMap = new Color[width * height];
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
			}
		}

		return GenerateTextureFromColormap(colorMap, width, height);
	}
	
	public static Texture2D GenerateColorTextureFromHeightmap(float[,] heightMap, List<Biome> biomes)
	{
		int width = heightMap.GetLength(0);
		int height = heightMap.GetLength(1);
		
		Color[] colorMap = new Color[width * height];
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				for (int i = 0; i < biomes.Count; ++i) {
					if (heightMap[x, y] <= biomes[i].Height) {
						colorMap[y * width + x] = biomes[i].Color;
					}
				}
			}
		}

		return GenerateTextureFromColormap(colorMap, width, height);
	}
	
	private static Texture2D GenerateTextureFromColormap(Color[] colorMap, int width, int height)
	{
		Texture2D texture = new Texture2D(width, height);
		texture.SetPixels(colorMap);
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.Apply();
		return texture;
	}
}
