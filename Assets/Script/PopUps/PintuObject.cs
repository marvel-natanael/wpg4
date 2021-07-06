using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PintuObject : MonoBehaviour, Interactable
{
    private bool lanjut=false;
    public void interact()
    {
        if (!lanjut)
            StartCoroutine(Pintu.Instance.showDialog());
        if (GameMaster.masker && GameMaster.sanitizer && GameMaster.vit)
        {
            LoadScene("act2");
        }
    }
    private void Update()
    {
        if (GameMaster.masker && GameMaster.sanitizer && GameMaster.vit)
        {
            lanjut = true;
        }
        Pintu.Instance.HandleUpdate();
    }

    void LoadScene(string a)
    {
        SceneManager.LoadScene(a);
    }
}
