﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/OverworldCharacter"), new Vector3(0,0,-0.5f), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}