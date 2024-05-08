using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler4 : MonoBehaviour {

    private DisplayImage4 currentDisplay;
    private Timer timer; // Reference to the Timer script
    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    private ZoomInObject[] zoomInObjects;
    private GameObject wrongEqnMsg;
    [SerializeField] TextMeshProUGUI wrongEqnText;
    //public GameObject Tutorial;

    void Awake()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage4>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;

        zoomInObjects = FindObjectsOfType<ZoomInObject>();
        wrongEqnMsg = GameObject.Find("WrongEqnMsg");
        //Tutorial.SetActive(false);

        // Find and cache the Timer script component
        timer = FindObjectOfType<Timer>();
    }

    public void OnClickReturn()
    {
        if (currentDisplay.CurrentState == DisplayImage4.State.idle) return;

        if (currentDisplay.CurrentState == DisplayImage4.State.zoom)
        {
            currentDisplay.CurrentState = DisplayImage4.State.normal;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall4" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = DisplayImage4.State.normal;

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
        }
    }

    public void OnClickNextLevel()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    /*public void OnClickReadMessage(GameObject TextObject)
    {
        currentDisplay.CurrentState = DisplayImage4.State.normal;

        Destroy(TextObject);
    }*/

    public void OnClickReadMessage(GameObject TextObject)
    {
        currentDisplay.CurrentState = DisplayImage4.State.normal;

        Destroy(TextObject);

        if (timer != null)
        {
            timer.ResumeTimer();
        }
    }

    /*public void OnClickTryAgain()
    {
        wrongEqnMsg.SetActive(false);
    }*/

    public void OnClickTryAgain()
    {

        wrongEqnMsg.SetActive(false);
        if (timer != null)
        {
            // Restart the timer if it has expired
            if (timer.HasTimerExpired())
            {
                timer.RestartTimer();
                SceneManager.LoadScene("Level 4");
            }
            else
            {
                // Resume the timer
                timer.ResumeTimer();
            }
        }
    }
}
