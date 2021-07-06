using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;
    private bool shootNow;
    EnemyHealth en;

    public static bool gameStart;
    public Transform firePoint;
    public GameObject bullet;
    public float jumpPower;
    public float delay;
    public float shotDelay;


    void Start()
    {
        firePoint.transform.Rotate(0f, 180f, 0f);
        rb = GetComponent<Rigidbody2D>();
        shootNow = true;
        gameStart = false;

        en = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = en.curHealth;
        if(gameStart)
        {
            fire();
            if (grounded)
                Jump();
            shotDelay = Random.Range(0.0f, 1.0f);
            delay = Random.Range(0.0f, 1.0f);
            jumpPower = Random.Range(5.5f, 12.0f);
        }
        if(health ==1)
        {
            Debug.Log("F");
            SceneManager.LoadScene("End");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    void Jump()
    {
        StartCoroutine(wait());
        rb.velocity = new Vector2(0, jumpPower);
        grounded = false;
    }

    void fire()
    {
        StartCoroutine(wait());
    }
    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        shootNow = false;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(shotDelay);
        StartCoroutine(Pattern1());
    }

    IEnumerator Pattern1()
    {
        if(shootNow)
        {
            Shoot();
            yield return new WaitForSeconds(delay);
            shootNow = !shootNow;
        }
    }
}
