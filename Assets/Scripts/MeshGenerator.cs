using UnityEngine;

public static class MeshGenerator
{
	public static LandscapeMeshData GenerateLandscapeMeshFromHeightmap(float[,] heightMap)
	{
		int width = heightMap.GetLength(0);
		int height = heightMap.GetLength(1);

		float topLeftX = (width - 1) / -2.0f;
		float topLeftZ = (height - 1) / 2.0f;

		LandscapeMeshData landscapeMeshData = new LandscapeMeshData(width, height);
		int lastAddedVertexIndex = 0;

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				landscapeMeshData.vertices[lastAddedVertexIndex] = new Vector3(topLeftX + x, heightMap[x, y], topLeftZ - y);
				landscapeMeshData.uvs[lastAddedVertexIndex] = new Vector2(x / (float) width, y / (float) height);
				
				if (x < width - 1 && y < height - 1) {
					landscapeMeshData.AddTriangle(lastAddedVertexIndex, lastAddedVertexIndex + width + 1, lastAddedVertexIndex + width);
					landscapeMeshData.AddTriangle(lastAddedVertexIndex + width + 1, lastAddedVertexIndex, lastAddedVertexIndex + 1);
				}

				lastAddedVertexIndex++;
			}
		}

		return landscapeMeshData;
	}
}

public class LandscapeMeshData
{
	public Vector3[] vertices;
	public int[] triangles;
	public Vector2[] uvs;

	private int _lastAddedTriangleIndex;

	public LandscapeMeshData(int width, int height)
	{
		vertices = new Vector3[width * height];
		triangles = new int[(width - 1) * (height - 1) * 6];
		uvs = new Vector2[width * height];
	}

	public void AddTriangle(int v1, int v2, int v3)
	{
		triangles[_lastAddedTriangleIndex] = v1;
		triangles[_lastAddedTriangleIndex + 1] = v2;
		triangles[_lastAddedTriangleIndex + 2] = v3;
		_lastAddedTriangleIndex += 3;
	}

	public Mesh CreateMesh()
	{
		Mesh mesh = new Mesh {
			vertices = vertices,
			triangles = triangles,
			uv = uvs
		};
		mesh.RecalculateNormals();
		return mesh;
	}
}
