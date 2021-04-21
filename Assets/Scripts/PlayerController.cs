using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int score;
    public UI userUI;
    private void Awake()
    {
        score = 0;
    }

    private void Update()
    {
        if(health <= 0)
        {
            LevelController lvlController = FindObjectOfType<LevelController>();
            lvlController.enabled = false;
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void SetScore(int score)
    {
        this.score = score;
        userUI.SetScoreUI(score);
    }
    public int GetScore()
    {
        return score;
    }
}
