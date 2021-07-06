using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public static int lives;
    public GameObject[] heart;
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    private void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength *0.99)
            {
                Debug.Log("A");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength *0.82)
            {
                Debug.Log("B");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                Debug.Log("C");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                Debug.Log("D");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                Debug.Log("E");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                Debug.Log("F");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                Debug.Log("G");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                Debug.Log("H");
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
            Debug.Log(flashCounter);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        playerSprite = GetComponent<SpriteRenderer>();
        for (int i=0; i < 3; i++)
        {
            heart[i].SetActive(true);
        }
    }

    public void hurtPlayer()
    {
        lives -= 1;
        switch (lives)
        {
            case 2:
                heart[2].SetActive(false);
                flashActive = true;
                flashCounter = flashLength;
                break;
            case 1:
                heart[1].SetActive(false);
                flashActive = true;
                flashCounter = flashLength;
                break;
            case 0:
                SceneManager.LoadScene("act2");
                break;
        }
    }
}
