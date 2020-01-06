using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    //TODO: Make stat modifyers
    public ushort MaxHealth, Attack, Defence, Magic, Luck;
    public byte level;

    /// <summary>
    /// Randomizes the stats based on level
    /// </summary>
    public void Randomize()
    {
        MaxHealth =    (ushort)(2 * Random.Range(level / 2, level * 2));
        Attack =    (ushort)(2 * Random.Range(level / 2, level * 2));
        Defence =   (ushort)(2 * Random.Range(level / 2, level * 2));
        Magic =     (ushort)(2 * Random.Range(level / 2, level * 2));
        Luck =      (ushort)Random.Range(level / 2, level);
    }

}
