using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise 
{
    int seed;

    float frequency;
    float amplitude;
    float lacunarity; //modifies frequency
    float persistance; // modifies amplitude
    int octaves;

    public Noise(int seed, float frequency, float amplitude, float lacunarity, float persistance, int octaves)
    {
        this.seed = seed;
        this.frequency = frequency;
        this.amplitude = amplitude;
        this.lacunarity = lacunarity;
        this.persistance = persistance;
        this.octaves = octaves;
    } 

    public float[,] GetNoiseValues(int width, int heigth)
    {
        float[,] noiseValues = new float[width, heigth];

        float max = 0f;
        float min = float.MaxValue;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heigth; j++)
            {
                noiseValues[i, j] = 0f;

                float tempAmp = amplitude;
                float tempFreq = frequency;

                for (int k = 0; k < octaves; k++)
                {
                    noiseValues[i, j] += Mathf.PerlinNoise((i + seed)/ (float)width * frequency, (j + seed) / (float)heigth * frequency) * amplitude;
                    frequency *= lacunarity;
                    amplitude *= persistance;
                }

                amplitude = tempAmp;
                frequency = tempFreq;

                if(noiseValues[i,j] > max)
                {
                    max = noiseValues[i, j];
                }
                if (noiseValues[i, j] < min)
                {
                    min = noiseValues[i, j];
                }
            }
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heigth; j++)
            {
                noiseValues[i, j] = Mathf.InverseLerp(max,min,noiseValues[i,j]);
            }
        }

        return noiseValues;
    }
}
