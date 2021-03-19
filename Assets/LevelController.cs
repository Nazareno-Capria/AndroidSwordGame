using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private List<Wave> waves;
    [SerializeField]
    private List<GameObject> spawnPoints;

    private bool wavesFinished = false;
    private float time;
    private Wave actualWave;

    private void Start()
    {
        actualWave = waves[0];
    }
    private void Update()
    {
        if (actualWave.isFinished)
            NextWave();
        if (wavesFinished)
            return;

        time += Time.deltaTime;
        if (time >= actualWave.timebetweenEnemys)
        {
            SpawnEnemys();
            time = 0;
        }

    }

    private void NextWave()
    {
        int nextIndex = waves.FindIndex(x => x.id == actualWave.id) + 1;
        if (nextIndex < waves.Count)
            actualWave = waves[waves.FindIndex(x => x.id == actualWave.id) + 1];
        else
            wavesFinished = true;
    }
    private void SpawnEnemys()
    {
        for (int i = 0; i < actualWave.enemysSpawnQuantity; i++)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
            if (actualWave.enemyQuantity > 0)
            {
                var posibleEnemys = actualWave.posibleEnemys;
                Instantiate(posibleEnemys[Random.Range(0, posibleEnemys.Count - 1)], spawnPoint.transform);
                actualWave.enemyQuantity--;//Aca talvez estoy rompiendo un par de reglas sobre encapsulamiento
            }
            else
            {
                actualWave.isFinished = true;//Aca tambien
            }
        }
    }
}
