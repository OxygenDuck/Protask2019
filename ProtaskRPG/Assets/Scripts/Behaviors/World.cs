using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public static World instance;

    public Material materialAdee;

    public int widthAdee;
    public int heightAdee;

    public Tile[,] tilesAdee;

    public int seedAdee; //number to make sure the map changes everytime
    public bool randomSeedAdee; //making it able to disable random seed and get the same map everytime

    public float frequencyAdee; //how many times 
    public float amplitudeAdee; //how far it goes 
    public float lacunarityAdee; //modifies frequency
    public float persistanceAdee; // modifies amplitude
    public int octavesAdee; //how many times it must repeat

    public float seaLevelAdee; //sea level

    public float beachStartHeightAdee; //start off the beach
    public float beachEndHeightAdee; //end of the beach

    public float grassStartHeightAdee; //start of grass
    public float grassEndHeightAdee; //end of grass

    Noise noiseAdee;

    
    void Awake()
    {
        instance = this;

        if (randomSeedAdee)
        {
            int valueAdee = Random.Range(-2500, 0);
            seedAdee = valueAdee;
        }

        noiseAdee = new Noise(seedAdee, frequencyAdee, amplitudeAdee, lacunarityAdee, persistanceAdee, octavesAdee);
    }
    void Start()
    {
        //creating tiles
        CreateTiles();
        //divinding tiles into chunks to make performance better
        SubdivideTilesArray();
        
    }

    void CreateTiles()
    {
        //creating the tiles
        tilesAdee = new Tile[widthAdee, heightAdee];

        float[,] noiseValuesAdee = noiseAdee.GetNoiseValues(widthAdee, heightAdee);

        for (int i = 0; i < widthAdee; i++)
        {
            for (int j = 0; j < heightAdee; j++)
            {
                tilesAdee[i, j] = MakeTileAtHeight(noiseValuesAdee[i, j]);
            }
        }
    }

    Tile MakeTileAtHeight(float currentHeightAdee)
    {
        //check the height to make sure what type of material to use
        if(currentHeightAdee <= seaLevelAdee)
        {
            return new Tile(Tile.Type.Water);
        }
        if (currentHeightAdee >= beachStartHeightAdee && currentHeightAdee <= beachEndHeightAdee)
        {
            return new Tile(Tile.Type.Sand);
        }
        if (currentHeightAdee >= grassStartHeightAdee && currentHeightAdee <= grassEndHeightAdee)
        {
            return new Tile(Tile.Type.Grass);
        }

        return new Tile(Tile.Type.Void);
    }

    void SubdivideTilesArray(int i1Adee = 0, int i2Adee = 0)
    {
        //getting lenght of a segment
        int sizeXAdee, sizeYAdee;

        if(tilesAdee.GetLength(0) - i1Adee > 100)
        {
            sizeXAdee = 100;
        }
        else
        {
            sizeXAdee = tilesAdee.GetLength(0) - i1Adee;
        }

        if (tilesAdee.GetLength(1) - i2Adee > 100)
        {
            sizeYAdee = 100;
        }
        else
        {
            sizeYAdee = tilesAdee.GetLength(1) - i2Adee;
        }

        //generate the mesh
        GenerateMesh(i1Adee, i2Adee, sizeXAdee, sizeYAdee);

        if (tilesAdee.GetLength(0) >= i1Adee + 100)
        {
            //make the chunks
            SubdivideTilesArray(i1Adee + 100, i2Adee);
            return;
        }

        if (tilesAdee.GetLength(1) >= i2Adee + 100)
        {
            //make the chunks
            SubdivideTilesArray(0, i2Adee + 100);
            return;
        }
    }

    //generating the mesh with the tiles and it material
    void GenerateMesh(int xAdee, int yAdee, int widthAdee, int heightAdee)
    {
        MeshData dataAdee = new MeshData(xAdee, yAdee, widthAdee, heightAdee);

        //creating chunk gameo bject
        GameObject meshGOAdee = new GameObject("CHUNK_" + xAdee + "_" + yAdee);
        meshGOAdee.transform.SetParent(this.transform);

        //render game object
        MeshFilter filterAdee = meshGOAdee.AddComponent<MeshFilter>();
        MeshRenderer rendererAdee = meshGOAdee.AddComponent<MeshRenderer>();
        rendererAdee.material = materialAdee;

        Mesh meshAdee = filterAdee.mesh;

        meshAdee.vertices = dataAdee.verticesAdee.ToArray();
        meshAdee.triangles = dataAdee.trianglesAdee.ToArray();
        meshAdee.uv = dataAdee.uvsAdee.ToArray();
    }

    //get tile at postion
    public Tile GetTileAt(int xAdee, int yAdee)
    {
        if (xAdee < 0 || xAdee >= widthAdee || yAdee < 0 || yAdee >= heightAdee)
        {
            return null;
        }
        return tilesAdee[xAdee, yAdee];
    }
}
