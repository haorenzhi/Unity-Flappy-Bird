using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float SpawnInterval = 1;
    public float NextSpawnTime = 0;
    public GameObject Prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= NextSpawnTime)
        {
            NextSpawnTime = Time.time + SpawnInterval;
            Instantiate(Prefab, RandomHeight(), Quaternion.identity);

        }
    }
    public static Vector2 RandomHeight()
    {
        Vector2 position = new Vector2(40, Random.Range(-14.0f, 9.0f));
        return position;
    }
}
