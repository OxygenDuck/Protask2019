using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //spawn enemy
    public void spawnEnemy()
    {
        for (int i = 0; i < 15; i++)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Crab"), new Vector3(Random.Range(0, World.instance.widthAdee), Random.Range(0, World.instance.heightAdee), -0.5f), new Quaternion());
        }
    }
}
