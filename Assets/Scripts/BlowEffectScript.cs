using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowEffectScript : MonoBehaviour
{
    ParticleSystem ps;
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ps.time >= 1.5f)
            Destroy(gameObject);
    }
}
