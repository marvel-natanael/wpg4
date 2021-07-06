using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaniObject : MonoBehaviour, Interactable
{
    public void interact()
    {
        StartCoroutine(Sani.Instance.showDialog());
        GameMaster.sanitizer = true;
        GameMaster.n95 = true;
    }
    private void Update()
    {
        Sani.Instance.HandleUpdate();
    }
}
