using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Wave 
{
    public int id; //Me gustaria hacer esto de otra forma ya se podrian agregar valores iguales y romperia la logica
    public List<GameObject> posibleEnemys;
    public int enemyQuantity;
    public float timebetweenEnemys;
    public int enemysSpawnQuantity;
    public bool isFinished;
}
