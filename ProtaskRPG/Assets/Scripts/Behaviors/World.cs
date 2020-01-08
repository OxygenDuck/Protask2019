using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public static World instance;

    public Material material;

    public int width;
    public int height;

    public Tile[,] tiles;

    public int seed;
    public bool randomSeed;

    public float frequency;
    public float amplitude;
    public float lacunarity; //modifies frequency
    public float persistance; // modifies amplitude
    public int octaves;

    public float seaLevel;

    public float beachStartHeight;
    public float beachEndHeight;

    public float grassStartHeight;
    public float grassEndHeight;

    Noise noise;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        if (randomSeed)
        {
            int value = Random.Range(-2500, 0);
            seed = value;
        }

        noise = new Noise(seed, frequency, amplitude, lacunarity, persistance, octaves);
    }
    void Start()
    {
        CreateTiles();
        SubdivideTilesArray();
        
    }

    void CreateTiles()
    {
        tiles = new Tile[width,height];

        float[,] noiseValues = noise.GetNoiseValues(width, height);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                tiles[i, j] = MakeTileAtHeight(noiseValues[i, j]);
            }
        }
    }

    Tile MakeTileAtHeight(float currentHeight)
    {
        if(currentHeight <= seaLevel)
        {
            return new Tile(Tile.Type.Water);
        }
        if (currentHeight >= beachStartHeight && currentHeight <= beachEndHeight)
        {
            return new Tile(Tile.Type.Sand);
        }
        if (currentHeight >= grassStartHeight && currentHeight <= grassEndHeight)
        {
            return new Tile(Tile.Type.Grass);
        }

        return new Tile(Tile.Type.Void);
    }

    void SubdivideTilesArray(int i1 = 0, int i2 = 0)
    {
        //getting lenght of a segment
        int sizeX, sizeY;

        if(tiles.GetLength(0) - i1 > 100)
        {
            sizeX = 100;
        }
        else
        {
            sizeX = tiles.GetLength(0) - i1;
        }

        if (tiles.GetLength(1) - i2 > 100)
        {
            sizeY = 100;
        }
        else
        {
            sizeY = tiles.GetLength(1) - i2;
        }

        GenerateMesh(i1,i2, sizeX, sizeY);

        if (tiles.GetLength(0) >= i1 + 100)
        {
            SubdivideTilesArray(i1 + 100, i2);
            return;
        }

        if (tiles.GetLength(1) >= i2 + 100)
        {
            SubdivideTilesArray(0, i2 + 100);
            return;
        }
    }

    void GenerateMesh(int x,int y, int width, int height)
    {
        MeshData data = new MeshData(x,y, width, height);

        GameObject meshGO = new GameObject("CHUNK_" + x + "_" + y);
        meshGO.transform.SetParent(this.transform);

        MeshFilter filter = meshGO.AddComponent<MeshFilter>();
        MeshRenderer renderer = meshGO.AddComponent<MeshRenderer>();
        renderer.material = material;

        Mesh mesh = filter.mesh;

        mesh.vertices = data.vertices.ToArray();
        mesh.triangles = data.triangles.ToArray();
        mesh.uv = data.uvs.ToArray();
    }

    public Tile GetTileAt(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            return null;
        }
        return tiles[x, y];
    }
}
