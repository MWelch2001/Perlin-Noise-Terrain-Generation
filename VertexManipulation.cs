using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexManipulation : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;

    [SerializeField]
    float mapScale;

    [SerializeField]
    float heightMultiplyer;

    [SerializeField]
    private AnimationCurve heightCurve;

    [SerializeField]
    public MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] meshVertices = this.meshFilter.mesh.vertices;
        int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
        int tileWidth = tileDepth;
        mesh = GetComponent<MeshFilter>().mesh;
        for (int z = 0; z < tileWidth; z++)
        {
            for (int x = 0; x < tileDepth; x++)
            {
                vertices = mesh.vertices;

            }
        }
        generateMap(tileDepth, tileWidth);
    }

    // Update is called once per frame
   void generateMap(int depth, int width)
    {
        float xOffset = -gameObject.transform.position.x / transform.localScale.x;
        float zOffset = -gameObject.transform.position.z / transform.localScale.z;

        float[,] heightMap = NoiseMapGen.Generate(width, depth, mapScale, xOffset, zOffset);
        
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                
                int vIndex = z * width + x;
                float height = heightMap[z, x];
                
                vertices[vIndex] =new Vector3(vertices[vIndex].x, heightCurve.Evaluate(height) * heightMultiplyer, vertices[vIndex].z);
                
            }
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();
    }
   
    
}
