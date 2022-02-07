using UnityEngine;

public class LandscapeGenerator : MonoBehaviour
{
	[SerializeField]
	private int _width;
	
	[SerializeField]
	private int _height;

	[SerializeField] [Range(0.001f, 50.0f)]
	private float _scale;

	[SerializeField]
	private int _seed;
	
	[SerializeField]
	private float _offset;

	[SerializeField]
	private int _octavesCount;
	
	[SerializeField] [Range(0.0f, 1.0f)]
	private float _persistance;
	
	[SerializeField]
	private float _lacunarity;

	[SerializeField]
	private bool _autoUpdate;

	public bool AutoUpdate => _autoUpdate;

	public void GenerateMap()
	{
		float[,] noiseMap = HeightmapGenerator.GenerateHeightmap(
			_width,
			_height,
			_seed,
			_scale,
			_octavesCount,
			_persistance,
			_lacunarity,
			_offset);

		LandscapeRendering landscapeRendering = GetComponent<LandscapeRendering>();
		landscapeRendering.DrawLandscape(noiseMap);
	}

	private void OnValidate()
	{
		if (_width < 1) {
			_width = 1;
		}
		if (_height < 1) {
			_height = 1;
		}
		if (_lacunarity < 1) {
			_lacunarity = 1;
		}
		if (_octavesCount < 1) {
			_octavesCount = 1;
		}
	}
}




