using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemyCounter : MonoBehaviour
{
    public int getChildren(GameObject obj)
    {
        int count = 0;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            count++;
            counter(obj.transform.GetChild(i).gameObject, ref count);
        }
        return count;
    }

    private void counter(GameObject currentObj, ref int count)
    {
        for (int i = 0; i < currentObj.transform.childCount; i++)
        {
            count++;
            counter(currentObj.transform.GetChild(i).gameObject, ref count);
        }
    }

    public int getCount()
    {
        return getChildren(gameObject);
    }

    void Update()
    {
        int childs = getChildren(gameObject);
        Debug.Log(childs);
        if(childs <= 26)
        {
            SceneManager.LoadScene("act3");
        }
    }
}
