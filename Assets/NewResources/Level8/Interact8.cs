﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact8 : MonoBehaviour {

    private DisplayImage8 currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage8>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPostion, Vector2.zero, 100);

            if (hit && hit.transform.tag == "Interactable8" && currentDisplay.CurrentState != DisplayImage8.State.idle)
            {
                hit.transform.GetComponent<IInteractable8>().Interact8(currentDisplay);
            }
        }

    }
}
