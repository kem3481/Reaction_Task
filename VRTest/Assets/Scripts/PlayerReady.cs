using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using System.Threading;

public class PlayerReady : MonoBehaviour
{
    // Position Check GameObjects
    private GameObject beginText;
    public GameObject headColumn;
    public GameObject handSphere;
    public GameObject invisiblehandSphere;

    // Vive Control GameObjects
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean squeezeAction;

    // Countdown Related GameObjects
    public GameObject GO;
    public int timeLeft = 3;
    public Text countdown;

    // Trial Objects
    public GameObject neutralTarget;
    public GameObject litTarget;

    public void Start()
    {
        // Define all starting objects by accessing tag names
        beginText = GameObject.FindGameObjectWithTag("BeginText");
        headColumn = GameObject.FindGameObjectWithTag("HeadColumn");
        handSphere = GameObject.FindGameObjectWithTag("HandSphere");

        // Set targets and intermediate game objects to false
        neutralTarget.SetActive(false);
        litTarget.SetActive(false);
        GO.SetActive(false);

        Time.timeScale = 1;
        invisiblehandSphere.SetActive(false);
    }

    public void Update()
    {
        // Accessing trigger pull on controller
        bool GetSqueeze()
        {
            return squeezeAction.GetStateDown(handType);
        }

        // If the trigger is pulled, get rid of all the positioning objects and display countdown
        if (neutralTarget.activeSelf == false && litTarget.activeSelf == false)
            { if (GetSqueeze())
            {
                headColumn.SetActive(false);
                handSphere.SetActive(false);
                invisiblehandSphere.SetActive(true);
                beginText.SetActive(false);
                GO.SetActive(true);

                StartCoroutine("LoseTime");
            }
        }

        // Using intermediate game objects to delay start of countdown
        if (GO == null)
        {
            countdown.text = string.Empty;
        }

        if (GO != null)
        {
            countdown.text = ("" + timeLeft);
        }

        // When the timer runs out, stop displaying the timer and set the neutral target to true
        if (timeLeft == 0)
        {
            GO.SetActive(false);
            neutralTarget.SetActive(true);
        }

    }

    // Countodwn function
    IEnumerator LoseTime()
    {
         while (timeLeft > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
        }
    }
}
