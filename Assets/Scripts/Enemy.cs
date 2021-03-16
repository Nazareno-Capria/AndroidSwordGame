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
            Debug.Log("Golpie con el jugador, le hice da�o y me destrui");
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            MakeDamage(player);
            Explode();
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Me cort�  " + collision.gameObject.tag);
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
