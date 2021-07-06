using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private Animator myAnim;
    public Transform homepos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerControl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>=minRange)
        {
            followPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            goHome();
        }

    }
    public void followPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void goHome()
    {
        myAnim.SetFloat("moveX", (homepos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homepos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position ,homepos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Hitbox")
        {
            Debug.Log("p");
            Vector2 diff = transform.position - coll.transform.position;
            transform.position = new Vector2(transform.position.x + diff.x, transform.position.y + diff.y);

        }
    }
}
