using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ECM.Components;

public class FightController : MonoBehaviour
{
    public float drawTimer;

    GameObject player;
    EnemyAI enemyAI;

    public Button drawButton;
    public Text drawTimerText;

    float randomXPos;
    float randomYpos;

    bool fightStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
        player = GameObject.FindGameObjectWithTag("PlayerController");

        player.GetComponentInChildren<MouseLook>().lockCursor = false;
        //player.GetComponentInChildren<MouseLook>().lateralSensitivity = 0;
        //player.GetComponentInChildren<MouseLook>().verticalSensitivity = 0;
        player.GetComponentInChildren<WeaponController>().enabled = false;

        randomXPos = Random.Range(0, 600);
        randomYpos = Random.Range(0, 250);

        drawButton.transform.position = new Vector3(randomXPos, randomYpos, 0);
        drawButton.gameObject.SetActive(false);
        //drawButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fightStarted)
        {
            drawTimer += Time.deltaTime;
            drawTimerText.text = drawTimer.ToString("F2");

            if (drawTimer >= 3f)
            {
                enemyAI.gunIsDrawn = true;

                drawTimerText.text = "Draw!!!";

                drawButton.gameObject.SetActive(true);
                //drawButton.interactable = true;
            }
        }
    }

    public void DrawButton()
    {
        fightStarted = true;
        drawTimer = 0;
        drawButton.gameObject.SetActive(false);
        player.GetComponentInChildren<MouseLook>().lockCursor = true;
        //player.GetComponentInChildren<MouseLook>().lateralSensitivity = 2;
        //player.GetComponentInChildren<MouseLook>().verticalSensitivity = 2;
        player.GetComponentInChildren<WeaponController>().enabled = true;
    }
}
