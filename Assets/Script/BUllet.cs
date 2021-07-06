using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUllet : MonoBehaviour
{
    public float bulletSpeed;
    PlayerAct4 player;

    private void Start()
    {
        player = FindObjectOfType<PlayerAct4>();
    }
    void Update()
    {
        transform.Translate(new Vector2(bulletSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.hurtPlayer();
            }
            Destroy(gameObject);
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
