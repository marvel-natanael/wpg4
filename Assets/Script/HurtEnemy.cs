using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            Debug.Log("A");
            EnemyHealth em;
            em = other.gameObject.GetComponent<EnemyHealth>();
            em.hurtEnemy();
        }
    }
}
