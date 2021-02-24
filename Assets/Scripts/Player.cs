using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject deathPanel;
    public GameObject playerWeapon;

    public bool isDead = false;

    EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAI.playerHit)
        {
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        playerWeapon.GetComponent<Rigidbody>().useGravity = true;
        playerWeapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        playerCamera.GetComponent<Animator>().enabled = true;
        deathPanel.SetActive(true);
        deathPanel.GetComponent<Animator>().enabled = true;
    }
}
