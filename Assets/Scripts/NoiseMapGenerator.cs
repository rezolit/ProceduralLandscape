using UnityEngine;

public class NoiseMapGenerator : MonoBehaviour
{
	[SerializeField]
	private int _width;
	
	[SerializeField]
	private int _height;

	[SerializeField] [Range(0.001f, 50.0f)]
	private float _scale;

	[SerializeField]
	private bool _autoUpdate;

	public bool AutoUpdate => _autoUpdate;

	public void GenerateMap()
	{
		float[,] noiseMap = NoiseGenerator.GeneratePerlinGrayscaleMap(_width, _height, _scale);

		NoiseMapView noiseMapView = GetComponent<NoiseMapView>();
		noiseMapView.DrawNoiseMap(noiseMap);
	}
}
