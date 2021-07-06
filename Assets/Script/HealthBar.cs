using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float curHealth;

    public Image bossHB;
    public float bossHealth;

    private float bossMax = 50f;
    private float maxHealth = 10f;
    PlayerAct4 player;
    EnemyHealth boss;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.gameObject.SetActive(false);
        bossHB.gameObject.SetActive(false);
        boss = FindObjectOfType<EnemyHealth>();
        player = FindObjectOfType<PlayerAct4>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss.gameStart)
        {
            healthBar.gameObject.SetActive(true);
            bossHB.gameObject.SetActive(true);

        }

        curHealth = player.health;
        bossHealth = boss.curHealth-1;

        bossHB.fillAmount = bossHealth / bossMax;
        healthBar.fillAmount = curHealth / maxHealth;
    }
}
