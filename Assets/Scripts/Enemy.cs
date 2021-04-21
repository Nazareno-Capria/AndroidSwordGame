using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField]
    public GameObject blowEffect;
    [SerializeField]
    public float speed = 1;
    [SerializeField]
    public float health;
    [SerializeField]
    public int damage = 1;

    public Vector3 playerPosition;
    public PlayerController pController;   
    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform.position;
        MoveToPosition(playerPosition);
    }
     
    public void MoveToPosition(Vector3 position)
    {
        rb.velocity = (position - transform.position).normalized * speed;
    }
    public  void MakeDamage(PlayerController player)
    {
        player.TakeDamage(damage);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        pController = collision.GetComponentInParent<PlayerController>();

        if (collision.gameObject.tag.Equals("Sword"))
        {  
            TakeDamage(1);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerController pController = collision.gameObject.GetComponent<PlayerController>();
            MakeDamage(pController);
            Explode();
            Destroy(gameObject);
        }
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            pController.SetScore(pController.GetScore() + 1);
            Explode();
            Destroy(gameObject);

        }
    }
    public void Explode()
    {
        Instantiate(blowEffect, transform.position, transform.rotation);
    }
    
}
