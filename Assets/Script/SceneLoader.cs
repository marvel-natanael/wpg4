using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string toLoad;
    public Image option;
    public void loadScene(string s)
    {
        s = toLoad;
        Debug.Log(s);
        SceneManager.LoadScene(s);
    }
    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
    public void options()
    {
        option.gameObject.SetActive(true);
    }
    public void close()
    {
        gameObject.SetActive(false);
    }
}
