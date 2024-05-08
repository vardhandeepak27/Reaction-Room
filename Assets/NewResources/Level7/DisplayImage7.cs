﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage7 : MonoBehaviour {

    public enum State
    {
        normal, zoom, ChangedView, idle
    };

    public State CurrentState { get; set; }

    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == 2)
                currentWall = 1;
            else if (value == 0)
                currentWall = 1;
            else
                currentWall = value;
        }
    }

    private int currentWall;
    private int previousWall;

    void Start()
    {
        CurrentState = State.idle;
        previousWall = 0;
        currentWall = 1;
    }

    void Update()
    {
        if (currentWall != previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall7" + currentWall.ToString());
        }

        previousWall = currentWall;
    }
}
