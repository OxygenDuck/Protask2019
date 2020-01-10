using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshData 
{
    public static MeshData instance;

    public List<Vector3> verticesAdee;
    public List<Vector2> uvsAdee;
    public List<int> trianglesAdee;

    public MeshData (int xAdee, int yAdee, int widthAdee, int heightAdee)
    {
        verticesAdee = new List<Vector3>();
        uvsAdee = new List<Vector2>();
        trianglesAdee = new List<int>();

        //creating the physical square in unity aka making a mesh
        for (int i = xAdee; i < widthAdee + xAdee; i++)
        {
            for (int j = yAdee; j < heightAdee + yAdee; j++)
            {
                CreateSquare(i, j);
            }
        }
    }

    void CreateSquare(int xAdee, int yAdee)
    {
        Tile tileAdee = World.instance.GetTileAt(xAdee, yAdee);

        //creating square tile
        verticesAdee.Add(new Vector3(xAdee + 0, yAdee + 0)); //bottom left corner
        verticesAdee.Add(new Vector3(xAdee + 1, yAdee + 0)); //bottom right corner
        verticesAdee.Add(new Vector3(xAdee + 0, yAdee + 1)); //top left corner
        verticesAdee.Add(new Vector3(xAdee + 1, yAdee + 1)); //top right corner

        //adding first triangle to the square tile
        trianglesAdee.Add(verticesAdee.Count - 1);
        trianglesAdee.Add(verticesAdee.Count - 3);
        trianglesAdee.Add(verticesAdee.Count - 4);

        //adding second triangle to the square tile
        trianglesAdee.Add(verticesAdee.Count - 2);
        trianglesAdee.Add(verticesAdee.Count - 1);
        trianglesAdee.Add(verticesAdee.Count - 4);

        //adding square with triangles in it
        uvsAdee.AddRange(SpriteLoader.instance.GetTileUvs(tileAdee));
    }
}
