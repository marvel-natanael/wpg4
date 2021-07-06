using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndUI : MonoBehaviour
{
    public List<GameObject> active;

    void Update()
    {
        if(Boss.gameStart)
        {
            foreach(GameObject g in active)
            {
                g.SetActive(true);
            }
        }
    }
}
