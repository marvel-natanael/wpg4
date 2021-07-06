using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AgentAI : MonoBehaviour
{
    public bool left;
    public bool hort;
    public Agent agent;
    // Update is called once per frame
    private void Start()
    {
        if (hort)
        {
            transform.Rotate(0, 00, 90);
        }
        if (left)
        {
            transform.Rotate(0, 0, 180);
        }

    }
    void Update()
    {
        patrol();
    }

    private void patrol()
    {
        turn();
    }

    private void stoptheGame()
    {
        SceneManager.LoadScene("act3");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            stoptheGame();
    }

    void turn()
    {
        if (agent.getTurnNow())
        {
            transform.Rotate(0, 0, 180);
        }

    }
}
