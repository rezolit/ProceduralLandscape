using System.Collections.Generic;
using UnityEngine;

public class LandscapeRendering : MonoBehaviour
{
	[SerializeField]
	private Renderer _textureRenderer;

	[SerializeField]
	private DrawMode _drawMode;
	
	[SerializeField]
	private List<Biome> _biomes; 

	public void DrawNoiseMap(float[,] heightMap)
	{
		Texture2D texture = new Texture2D(heightMap.GetLength(0), heightMap.GetLength(1));
		switch (_drawMode) {
			case DrawMode.Grayscale:
				texture = TextureGenerator.GenerateGrayscaleTextureFromHeightmap(heightMap);
				break;
			case DrawMode.Color:
				texture = TextureGenerator.GenerateColorTextureFromHeightmap(heightMap, _biomes);
				break;
		}
		
		_textureRenderer.sharedMaterial.mainTexture = texture;
		_textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
	}

	private enum DrawMode
	{
		Grayscale,
		Color
	}
}
