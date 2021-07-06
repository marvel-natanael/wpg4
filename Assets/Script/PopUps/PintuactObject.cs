using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PintuactObject : MonoBehaviour, Interactable
{
    private bool lanjut = false;
    public void interact()
    {
        Debug.Log(lanjut);
        if (!lanjut)
            StartCoroutine(Pintuact.Instance.showDialog());
        if (GameMaster.n95)
        {
            LoadScene("act4");
        }
    }
    private void Update()
    {
        if (GameMaster.n95)
        {
            lanjut = true;
        }
        Pintuact.Instance.HandleUpdate();
    }

    void LoadScene(string a)
    {
        SceneManager.LoadScene(a);
    }
}
