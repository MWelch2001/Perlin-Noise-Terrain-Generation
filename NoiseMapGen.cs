using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class NoiseMapGen : MonoBehaviour
{
    public static float[,] Generate(int width, int depth, float scale, float xOffset, float zOffset){
        float[,] noiseMap = new float[width, depth];
        for (int z = 0; z < width; z++){
            for (int x = 0; x < depth; x++){
                float zSample = (z + zOffset) / scale;
                float xSample = (x +xOffset) / scale;


                float noise = Mathf.PerlinNoise(xSample, zSample);

                noiseMap[z, x] = noise;

            }
        }
        return noiseMap;
    }

    // Start is called before the first frame update
}
