using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Rigidbody2D rb;
    [SerializeField]
<<<<<<< HEAD
    GameObject blowEffect;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float health;
=======
    private float speed = 1;
    [SerializeField]
    private int damage = 1;

>>>>>>> c46676f1ea73ad116aad79e47bbaeaed4e1f1233
    private Vector3 playerPosition;
    
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
<<<<<<< HEAD
        Debug.Log("Me choque con " + collision.gameObject.tag);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Me cortó  " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Sword")
        {
            Instantiate(blowEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
=======
        player.TakeDamage(damage);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask collisionMask = collision.gameObject.layer;
        Debug.Log("Layer" + LayerMask.LayerToName(collisionMask));
        if (LayerMask.LayerToName(collisionMask).Equals("Sword"))
        {
            Debug.Log("Golpie con la espada y me destrui");
            Destroy(gameObject);
        }else if (LayerMask.LayerToName(collisionMask).Equals("Player"))
        {
            Debug.Log("Golpie con el jugador, le hice daño y me destrui");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            MakeDamage(player);
            Destroy(gameObject);
>>>>>>> c46676f1ea73ad116aad79e47bbaeaed4e1f1233
        }
    }

}
