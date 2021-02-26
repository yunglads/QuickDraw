﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Components;

public class Player : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject deathPanel;
    public GameObject winPanel;
    public GameObject playerWeapon;
    public GameObject playerModel;
    public GameObject ECM_FirstPerson;

    public bool isDead = false;

    EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
        playerModel = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAI.playerHit)
        {
            PlayerDead();
        }

        if (enemyAI.isDead)
        {
            Invoke("PlayerWon", 3f);
        }

        if (deathPanel == null)
        {
            deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        }

        if (winPanel == null)
        {
            winPanel = GameObject.FindGameObjectWithTag("WinPanel");
        }

        if (playerModel == null)
        {
            playerModel = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void PlayerDead()
    {
        playerWeapon.GetComponent<Rigidbody>().useGravity = true;
        playerWeapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        playerCamera.GetComponent<Animator>().enabled = true;
        deathPanel.SetActive(true);
        deathPanel.GetComponent<Animator>().enabled = true;
        playerModel.SetActive(false);
        ECM_FirstPerson.GetComponent<MouseLook>().lateralSensitivity = 0;
        ECM_FirstPerson.GetComponent<MouseLook>().verticalSensitivity = 0;
        ECM_FirstPerson.GetComponent<MouseLook>().lockCursor = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void PlayerWon()
    {
        ECM_FirstPerson.GetComponent<MouseLook>().lateralSensitivity = 0;
        ECM_FirstPerson.GetComponent<MouseLook>().verticalSensitivity = 0;
        ECM_FirstPerson.GetComponent<MouseLook>().lockCursor = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        winPanel.SetActive(true);
    }
}
