using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerAct4 : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;
    private Animator anim;

    public Transform firePoint;
    public GameObject bullet;
    public float jumpPower;
    public float health = 10f;
    public AudioSource sfx;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Boss.gameStart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                anim.SetBool("att", true);
                Shoot();
            }
            if (Input.GetKeyUp(KeyCode.T))
            {
                anim.SetBool("att", false);
                if (!sfx.isPlaying)
                {
                    sfx.Play();
                }
            }

            if (Input.GetKeyDown("space") && grounded)
            {
                Jump();
            }
        }
        if(health <= 0f)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.enabled = true;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void Jump()
    {
        rb.velocity = new Vector2(0, jumpPower);
        grounded = false;
    }

    public void hurtPlayer()
    {
        health -= 1.0f;
    }
}
