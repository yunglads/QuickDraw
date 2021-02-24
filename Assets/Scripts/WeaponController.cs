﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int ammoCount = 6;
    public float range = 100f;
    public float force = 10f;

    [HideInInspector]
    public RaycastHit hit;

    public Camera playerCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoCount > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.tag == "Enemy")
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
                enemyAI.isDead = true;
                enemyAI.Die();
            }
        }

        ammoCount--;
    }
}
