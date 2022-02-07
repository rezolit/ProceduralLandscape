using System.Collections.Generic;
using UnityEngine;

public class LandscapeRendering : MonoBehaviour
{
	[SerializeField]
	private Renderer _textureRenderer;
	
	[SerializeField]
	private MeshFilter _meshFilter;
	
	[SerializeField]
	private MeshRenderer _meshRenderer;

	[SerializeField]
	private DrawMode _drawMode;
	
	[SerializeField]
	private List<Biome> _biomes; 

	public void DrawLandscape(float[,] heightMap)
	{
		switch (_drawMode) {
			case DrawMode.Grayscale:
				DrawGrayscaleTexture(heightMap);
				break;
			case DrawMode.Color:
				DrawColorTexture(heightMap);
				break;
			case DrawMode.Mesh:
				DrawMesh(heightMap);
				break;
		}
	}

	private void DrawGrayscaleTexture(float[,] heightMap)
	{
		Texture2D texture = TextureGenerator.GenerateGrayscaleTextureFromHeightmap(heightMap);
		_textureRenderer.sharedMaterial.mainTexture = texture;
		_textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
	}

	private void DrawColorTexture(float[,] heightMap)
	{
		Texture2D texture = TextureGenerator.GenerateColorTextureFromHeightmap(heightMap, _biomes);
		_textureRenderer.sharedMaterial.mainTexture = texture;
		_textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
	}

	private void DrawMesh(float[,] heightMap)
	{
		LandscapeMeshData landscapeMeshData = MeshGenerator.GenerateLandscapeMeshFromHeightmap(heightMap);
		_meshRenderer.sharedMaterial.mainTexture = TextureGenerator.GenerateColorTextureFromHeightmap(heightMap, _biomes);
		_meshFilter.sharedMesh = landscapeMeshData.CreateMesh();
	}

	private enum DrawMode
	{
		Grayscale,
		Color,
		Mesh
	}
}
