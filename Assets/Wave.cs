using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> posibleEnemys;
    [SerializeField]
    public int enemyQuantity;
    [SerializeField]
    public float timebetweenEnemys;
    [SerializeField]
    public int enemysSpawnQuantity;

    public bool isFinished = false;

    private void Awake()
    {
        posibleEnemys = new List<GameObject>();
    }

    private void Update()
    {
        if (isFinished)
            return;
        
    }

    private void SpawnEnemys(GameObject spawnPoint)
    {
        
    }
}
