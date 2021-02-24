﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterList;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    public void LeftButton()
    {
        characterList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
    }

    public void RightButton()
    {
        characterList[index].SetActive(false);

        index++;
        if(index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
    }
}
