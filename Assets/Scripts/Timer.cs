/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject wrongEqnMsg; // Reference to the GameObject to be activated


    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            //UIManager.Instance.ShowGameOver(false);
            // Activate the wrongEqnMsg GameObject
            if (wrongEqnMsg != null)
            {
                wrongEqnMsg.SetActive(true);
            }


        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}*/


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float totalTime; // Total time for the timer
    private float remainingTime; // Current remaining time
    [SerializeField] GameObject wrongEqnMsg; // Reference to the GameObject to be activated
    //[SerializeField] Button tryAgainButton; // Reference to the "Try Again" button
    [SerializeField] TextMeshProUGUI wrongEqnText; // Text component of wrongEqnMsg
    private bool timerPaused;
    private bool timerExpired; // Flag to indicate if the timer has expired


    void Start()
    {
        // Initialize remainingTime to totalTime when the game starts
        remainingTime = totalTime;
        timerExpired = false;
        PauseTimer();
        // Disable the wrongEqnMsg GameObject at the start
        if (wrongEqnMsg != null)
        {
            wrongEqnMsg.SetActive(false);
        }
        // Add an onClick listener to the "Try Again" button
        /*if (tryAgainButton != null)
        {
            tryAgainButton.onClick.AddListener(RestartTimer);
        }*/ 
    }

    /*void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            // Activate the wrongEqnMsg GameObject
            if (wrongEqnMsg != null)
            {
                wrongEqnMsg.SetActive(true);
                if (wrongEqnText != null)
                {
                    wrongEqnText.text = "Time is up";
                }

            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/

    void Update()
    {
        if (!timerExpired && remainingTime > 0)
        {
            if (!timerPaused)
            {
                remainingTime -= Time.deltaTime;
            }
        }
        else
        {
            remainingTime = 0;
            timerExpired = true;
            // Activate the wrongEqnMsg GameObject
            if (wrongEqnMsg != null)
            {
                wrongEqnMsg.SetActive(true);
                if (wrongEqnText != null)
                {
                    if (remainingTime > 0)
                    {
                        wrongEqnText.text = "Incorrect";
                    }
                    else
                    {
                        wrongEqnText.text = "Time is up";
                    }
                }
            }
            // Pause the timer
            //PauseTimer();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    // Method to restart the timer
    public void RestartTimer()
    {
        // Reset remainingTime to totalTime
        remainingTime = totalTime;
        timerPaused = false;
        timerExpired = false;
        // Hide the wrongEqnMsg GameObject
        /*if (wrongEqnMsg != null)
        {
            wrongEqnMsg.SetActive(false);
        }
        */
    }


    public void PauseTimer()
    {
        // Pause the timer
        //Time.timeScale = 0f;
        timerPaused = true;
    }

    public void ResumeTimer()
    {
        // Resume the timer
        //Time.timeScale = 1f;
        timerPaused = false;
    }

    public bool HasTimerExpired()
    {
        return timerExpired;
    }
}

