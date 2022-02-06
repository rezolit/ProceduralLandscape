using UnityEngine;

public static class NoiseGenerator
{
	public static float[,] GeneratePerlinGrayscaleMap(int width, int height, float scale)
    {
	    float[,] grayscaleMap = new float[height, width];

	    for (int y = 0; y < height; y++) {
		    for (int x = 0; x < width; x++) {
			    grayscaleMap[y, x] = Mathf.PerlinNoise(x / scale, y / scale);
		    }
	    }

	    return grayscaleMap;
    }
}
