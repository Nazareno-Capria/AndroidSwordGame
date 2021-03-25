using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Wave 
{
    //public int id; //Me gustaria hacer esto de otra forma ya se podrian agregar valores iguales y romperia la logica
    public List<GameObject> posibleEnemys;
    public int enemyQuantity;
    public float timebetweenEnemys;
    public int enemysSpawnQuantity;
    public bool isFinished;


    public Wave(List<GameObject> posibleEnemys, int enemyQuantity, float timeBetweenEnemys, int enemysSpawnQuantity)
    {
        isFinished = false;
        this.posibleEnemys = posibleEnemys;
        this.enemyQuantity = enemyQuantity;
        timebetweenEnemys = timeBetweenEnemys;
        this.enemysSpawnQuantity = enemysSpawnQuantity;
    }
    public void FinishWave()
    {
        isFinished = true;
    }
    public void RemoveEnemy()
    {
        if (enemyQuantity >= 1)
        {
            enemyQuantity--;
        }
    }
    public List<GameObject> GetPosibleEnemys()
    {
        return posibleEnemys;
    }
}
