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
    private void MakeDamage(PlayerController player)
    {
        player.TakeDamage(damage);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Me choque con " + collision.gameObject.tag);
        LayerMask collisionMask = collision.gameObject.layer;
        Debug.Log("Layer" + LayerMask.LayerToName(collisionMask));
        if (LayerMask.LayerToName(collisionMask).Equals("Player"))
        {
            Debug.Log("Golpie con el jugador, le hice daño y me destrui");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
<<<<<<< HEAD
            try
            {
                MakeDamage(player);
            }
            catch (Exception)
            {
                Debug.LogWarning("El enemigo impacto con el jugador, pero estaba destruido");
            }
=======
            MakeDamage(player);
            Explode();
<<<<<<< HEAD
=======
>>>>>>> 0e069982129d3cac8f03a0484b746553cebbb10b
>>>>>>> 0f734a58eef4c7e45e96302c3b5bb12e3216185d
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Me cortó  " + collision.gameObject.tag);
        //if(collision.gameObject.tag == "Sword")
        //{
        //    Explode();
        //    Destroy(gameObject);
        //}   
    }
    public void Explode()
    {
        Instantiate(blowEffect, transform.position, transform.rotation);
    }
    
}
