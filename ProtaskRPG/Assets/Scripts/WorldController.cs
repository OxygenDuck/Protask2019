﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/OverworldCharacter"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
