using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private int damage = 1;

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
        }
    }

}
