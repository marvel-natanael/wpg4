using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Info : MonoBehaviour
{

    public Image img;
    
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        var objectName = transform.name;
        if (other.collider.tag == "Player")
        {
            img.gameObject.SetActive(true);
            Time.timeScale = 0f;
            if (objectName == "tv")
            {
                Debug.Log("A");
                GameMaster.sanitizer = true;
            }
            else if (objectName == "lemari")
            {
                Debug.Log("b");
                GameMaster.vit = true;
            }
            else if (objectName == "meja")
            {
                Debug.Log("c");
                GameMaster.masker = true;
            }

        }
    }

}
