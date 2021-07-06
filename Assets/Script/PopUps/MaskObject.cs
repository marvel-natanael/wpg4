using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour, Interactable
{
    public void interact()
    {
        StartCoroutine(Masker.Instance.showDialog());

        GameMaster.masker = true;
    }
    private void Update()
    {
        Masker.Instance.HandleUpdate();
    }
}
