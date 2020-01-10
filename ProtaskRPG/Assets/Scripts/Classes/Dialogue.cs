using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//class to store dialogue
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;

}
