﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMolecule13 : MonoBehaviour, IInteractable13
{
    
    public GameObject item;
    public GameObject item1;
    //public GameObject item2;

    void Start()
    {
        item.SetActive(false);
        item1.SetActive(false);
        //item2.SetActive(false);
    }

    public void Interact13(DisplayImage13 currentDisplay)
    {
        item.SetActive(true);
        item1.SetActive(true);
        //item2.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
