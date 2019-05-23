using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using System.Threading;


public class Trial : MonoBehaviour
{
    public GameObject playField;
    public GameObject neutralTarget;
    public GameObject litTarget;
    public GameObject mainCanvas;
    public GameObject endCanvas;
    public float x_position;
    public float y_position;

    private GameObject fixation;
    private GameObject rightController;
    private int ProcessingTime;
    public float CollisionPosition_x;
    public float CollisionPosition_y;
    private int CollisionTime;
    private int Timer = 0;
    public int count = 0;
    public GameObject Test;
    public GameObject Data;

    // Vive Control GameObjects
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean squeezeAction;

    void Start()
    {
        fixation = GameObject.FindGameObjectWithTag("OrientationCheck");
        rightController = GameObject.FindGameObjectWithTag("RightController");

        Test.SetActive(false);
        Data.SetActive(false);

        litTarget.SetActive(false);
        endCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (neutralTarget.activeSelf == true && Test.activeSelf == false && playField.activeSelf == true)
        {
            StartCoroutine("ChangeDelay");
        }

        if (count > 2)
        {
            playField.SetActive(false);
            neutralTarget.SetActive(false);
            litTarget.SetActive(false);
            mainCanvas.SetActive(false);
            endCanvas.SetActive(true);
        }

        bool GetSqueeze()
        {
            return squeezeAction.GetStateDown(handType);
        }

        if (GetSqueeze())
        {
            count++;
            Data.SetActive(false);
            Timer = 0;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Invisible"))
        {
            print("Processing Time: " + Timer);
            ProcessingTime = Timer;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LitTarget"))
        {
            neutralTarget.SetActive(true);
            litTarget.SetActive(false);
            fixation.SetActive(true);
            Test.SetActive(true);
            StartCoroutine("DataCollection");
        }
    }

    IEnumerator DataCollection()
    {
        if (Data.activeSelf == false)
        {
            CollisionPosition_x = rightController.transform.position.x;
            CollisionPosition_y = rightController.transform.position.y;
            print("Collision Position: " + CollisionPosition_x + ", " + CollisionPosition_y);
            print("Collision Time: " + CollisionTime);
            CollisionTime = Timer;
        }
        yield return new WaitForEndOfFrame();
        Data.SetActive(true);
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        neutralTarget.SetActive(false);
        litTarget.SetActive(true);
        fixation.SetActive(false);
        StartCoroutine("Timers");
    }

    IEnumerator Timers()
    {
        if (litTarget.activeSelf == true)
        {
            yield return new WaitForSecondsRealtime(.01f);
            Timer++;
        }
    }
}
