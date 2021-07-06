using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starter : MonoBehaviour
{
    public enemyCounter enemyCounter;
    public TextMeshProUGUI count;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        count.text = "Sisa musuh : " + (enemyCounter.getCount() - 25).ToString();
    }
}
