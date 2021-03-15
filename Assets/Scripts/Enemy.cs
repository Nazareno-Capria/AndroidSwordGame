using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed;
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
        Debug.Log("Me choque con " + collision.gameObject.layer.ToString());
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Me choque con " + collision.gameObject.layer.ToString());
    }
}
