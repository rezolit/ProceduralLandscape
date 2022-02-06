using System;
using UnityEngine;

public static class NoiseGenerator
{
	public static float[,] GeneratePerlinNoiseGrayscaleMap(
		int width, int height, int seed, float scale, int octavesCount, float persistance, float lacunarity, float offset)
    {
	    float[,] grayscaleMap = new float[width, height];

	    Vector2[] octaveOffsets = new Vector2[octavesCount];
	    System.Random random = new System.Random(seed);
	    
	    for (int i = 0; i < octavesCount; i++) {
		    octaveOffsets[i].x = random.Next(-10000, 10000) + offset;
		    octaveOffsets[i].y = random.Next(-10000, 10000) + offset;
	    }
	    
	    float maxNoiseHeight = float.MinValue;
	    float minNoiseHeight = float.MaxValue;

	    float halfWidth = width / 2.0f;
	    float halfHeight = height / 2.0f;
	    
	    for (int y = 0; y < height; y++) {
		    for (int x = 0; x < width; x++) {

			    float amplitude = 1;
			    float frequence = 1;
			    float noiseHeight = 0;

			    for (int i = 0; i < octavesCount; i++) {
				    float sampleX = (x - halfWidth) / scale * frequence + octaveOffsets[i].x;
				    float sampleY = (y - halfHeight) / scale * frequence + octaveOffsets[i].y;
				    
				    float perlinNoiseValue = Mathf.PerlinNoise(sampleX, sampleY);
				    noiseHeight += perlinNoiseValue * amplitude;
				    
				    amplitude *= persistance;
				    frequence *= lacunarity;
			    }

			    if (maxNoiseHeight < noiseHeight) {
				    maxNoiseHeight = noiseHeight;
			    } else if (minNoiseHeight > noiseHeight) {
				    minNoiseHeight = noiseHeight;
			    }

			    grayscaleMap[x, y] = noiseHeight;
		    }
	    }

	    for (int y = 0; y < height; y++) {
		    for (int x = 0; x < width; x++) {
			    grayscaleMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, grayscaleMap[x, y]);
		    }
	    }

	    return grayscaleMap;
    }
}
