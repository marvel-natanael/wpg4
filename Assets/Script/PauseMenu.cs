using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject homeButton;
    public GameObject retryButton;
    public GameObject bg;
    public GameObject backButton;
    public GameObject pauseButton;
    bool paused = false;
    public void onPause()
    {
        if (!paused)
        {
            pauseButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
            bg.gameObject.SetActive(true);
            paused = true;
        }
        Time.timeScale = 0f;
        Debug.Log(paused);
    }

    public void onContinue()
    {
        if (paused)
        {
            pauseButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(false);
            homeButton.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
            bg.gameObject.SetActive(false);
            paused = false;
        }
        Time.timeScale = 1f;
    }

    public void restartGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void goHome()
    {
        SceneManager.LoadScene("Menu");
    }

}
