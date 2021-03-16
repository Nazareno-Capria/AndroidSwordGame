using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Rigidbody2D rb;
    [SerializeField]
    GameObject blowEffect;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float health;
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
        Debug.Log(position);
        rb.velocity = (position - transform.position).normalized * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Me choque con " + collision.gameObject.tag);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Me cortó  " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Sword")
        {
            Instantiate(blowEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
