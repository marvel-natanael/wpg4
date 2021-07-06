using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VitObject : MonoBehaviour, Interactable
{
    public void interact()
    {
        StartCoroutine(Vit.Instance.showDialog());
        GameMaster.vit = true;
    }
    private void Update()
    {
        Vit.Instance.HandleUpdate();
    }
}
