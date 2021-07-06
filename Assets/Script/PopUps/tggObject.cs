using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tggObject : MonoBehaviour, Interactable
{
    public void interact()
    {
        StartCoroutine(Tgg.Instance.showDialog());

        GameMaster.vit = true;
    }
    private void Update()
    {
        Tgg.Instance.HandleUpdate();
    }
}
