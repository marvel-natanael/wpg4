using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator myAnim;
    public Transform homepos;
    public Transform target;
    private bool isThere = false;
    private bool turnNow = false;
    public AgentAI ai;
    bool horts;
    [SerializeField]
    private float curSpeed;
    private float speed;
    [SerializeField]
    private float curDelay;
    private float delay;

    private float tr;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        horts = ai.hort;
        speed = curSpeed;
        delay = curDelay;
        tr = 0;
    }
    public bool getTurnNow()
    {
        return turnNow;
    }
    // Update is called once per frame
    void Update()
    {
        goThere();

        if (transform.position == target.transform.position || transform.position == homepos.transform.position)
        {

            speed = 0;
            tr += Time.deltaTime;
            myAnim.enabled = false;
            if (tr >= delay)
            {
                speed = curSpeed;
                tr = 0;
                turnNow = true;
                myAnim.enabled = true;
                isThere = !isThere;
                Debug.Log(turnNow);
            }
    
        }

    }

    private void goThere()
    {
        if (!isThere)
        {
            //Debug.Log("A");
            myAnim.SetBool("isMoving", true);
            myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
            myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        else
        {
            //Debug.Log("V");
            myAnim.SetFloat("moveX", (homepos.position.x - transform.position.x));
            myAnim.SetFloat("moveY", (homepos.position.y - transform.position.y));
            transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, homepos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
        turnNow = false;
    }
}
