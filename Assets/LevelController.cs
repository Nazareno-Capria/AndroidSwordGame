using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private List<Wave> waves;
    [SerializeField]
    private List<GameObject> spawnPoints;
    [SerializeField]
    private List<GameObject> enemies;

    private bool wavesFinished = false;
    private float time;
    private Wave actualWave;
    [SerializeField]
    private float totalTime;
    [SerializeField]
    private int difficulty;

    private void Start()
    {
        waves = new List<Wave>();
        difficulty = 1;
    }
    private void Update()
    {
        CalculateDifficulty();
        if (actualWave.isFinished || waves.Count == 0 || waves == null) 
        {
            Debug.Log("Creo la siguiente wave o primer wave");
            NextWave();
        }

        totalTime += Time.deltaTime;
        time += Time.deltaTime;

        if (time >= actualWave.timebetweenEnemys)
        {
            SpawnEnemys();
            time = 0;
        }

    }

    private void NextWave()
    {
        
        Wave nextWave = CreateNextWave();

        int nextIndex = waves.FindIndex(x => x.Equals(nextWave));
        actualWave = waves[nextIndex];

    }
    private void SpawnEnemys()
    {
        for (int i = 0; i < actualWave.enemysSpawnQuantity; i++)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            if (actualWave.enemyQuantity > 0)
            {
                var posibleEnemys = actualWave.GetPosibleEnemys();
                Instantiate(posibleEnemys[Random.Range(0, posibleEnemys.Count)], spawnPoint.transform);
                actualWave.RemoveEnemy();//Aca talvez estoy rompiendo un par de reglas sobre encapsulamiento
                //solo un par?
            }
            else
            {
                //FinishWave(actualWave);//Aca tambien
                actualWave.isFinished = true;
            }
        }
    }

    public Wave CreateNextWave()
    {
        float timeBetweenEnemys = 4f/difficulty;
        List<GameObject> possibleEnemies = new List<GameObject>();

        if (difficulty < 3)
        {
            possibleEnemies.Add(enemies[0]);
        }
        else
        {
            possibleEnemies.Add(enemies[0]);
            possibleEnemies.Add(enemies[1]);
        }
        int enemyQuantity = 2 + (2 * difficulty);
        int enemySpawnQuantity = 1;
        Wave nextWave = new Wave(possibleEnemies, enemyQuantity, timeBetweenEnemys, enemySpawnQuantity);

        waves.Add(nextWave);

        return nextWave;
    }

    private void CalculateDifficulty()
    {
        if ((int)totalTime % 10 == 0)
        {
            difficulty = (int)(Mathf.Round(totalTime) / 10) + 1;
        }
    }

    private void FinishWave(Wave waveToFinish)
    {
        waveToFinish.FinishWave();
    }
}
