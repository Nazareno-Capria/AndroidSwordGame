using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Enemy
{

    private GameObject sword;
    public float hitForceSpeed;

    public float retractionTime;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sword = GameObject.Find("Sword");
    }
    void Start()
    {
        MoveToPosition(playerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public new void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Me golpeó con " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Sword")
        {
            pController = collision.GetComponentInParent<PlayerController>();
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            pController.SetScore(pController.GetScore() + 1);
            Explode();
            Destroy(gameObject);

        }
        else
        {
            HitMove();
        }
    }

    private void HitMove()
    {
        Vector3 rbVelocity = (transform.position - sword.transform.position).normalized;
        rb.velocity = rbVelocity * hitForceSpeed;
        Invoke("MoveToPlayer", 0.75f);
    }
    private void MoveToPlayer()
    {
        rb.velocity = (playerPosition - transform.position).normalized * speed;
    }
}
