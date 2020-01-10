using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise 
{
    int seedAdee; //number to make sure the map changes everytime

    //making the variables off a noise map.
    float frequencyAdee; //how many times 
    float amplitudeAdee; //how far it goes 
    float lacunarityAdee; //modifies frequency
    float persistanceAdee; // modifies amplitude
    int octavesAdee; //how many times it must repeat

    //constructor
    public Noise(int a_seedAdee, float a_frequencyAdee, float a_amplitudeAdee, float a_lacunarityAdee, float a_persistanceAdee, int a_octavesAdee)
    {
        this.seedAdee = a_seedAdee;
        this.frequencyAdee = a_frequencyAdee;
        this.amplitudeAdee = a_amplitudeAdee;
        this.lacunarityAdee = a_lacunarityAdee;
        this.persistanceAdee = a_persistanceAdee;
        this.octavesAdee = a_octavesAdee;
    } 

    //get values of noise map
    public float[,] GetNoiseValues(int widthAdee, int heigthAdee)
    {
        //make two dimensonal arry for the noise values
        float[,] noiseValuesAdee = new float[widthAdee, heigthAdee];

        float maxAdee = 0f;
        float minAdee = float.MaxValue;

        //looping through the noise values
        for (int i = 0; i < widthAdee; i++)
        {
            for (int j = 0; j < heigthAdee; j++)
            {
                noiseValuesAdee[i, j] = 0f;

                //making sure the frequency and amplitude wont fail in the calculation
                float tempAmpAdee = amplitudeAdee;
                float tempFreqAdee = frequencyAdee;

                //loop throug  amout of octaves aka how much it needs to repeat and calculate the noise map 
                for (int k = 0; k < octavesAdee; k++)
                {
                    noiseValuesAdee[i, j] += Mathf.PerlinNoise(
                        (i + seedAdee) / (float)widthAdee * frequencyAdee, 
                        (j + seedAdee) / (float)heigthAdee * frequencyAdee) * amplitudeAdee;
                    frequencyAdee *= lacunarityAdee;
                    amplitudeAdee *= persistanceAdee;
                }

                amplitudeAdee = tempAmpAdee;
                frequencyAdee = tempFreqAdee;

                //setting noise values if higher then max
                if(noiseValuesAdee[i,j] > maxAdee)
                {
                    maxAdee = noiseValuesAdee[i, j];
                }
                //setting noise values if less then min
                if (noiseValuesAdee[i, j] < minAdee)
                {
                    minAdee = noiseValuesAdee[i, j];
                }
            }
        }

        //loop through noise values and inverse them
        for (int i = 0; i < widthAdee; i++)
        {
            for (int j = 0; j < heigthAdee; j++)
            {
                noiseValuesAdee[i, j] = Mathf.InverseLerp(maxAdee, minAdee, noiseValuesAdee[i,j]);
            }
        }

        return noiseValuesAdee;
    }
}
