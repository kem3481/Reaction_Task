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

    private GameObject fixation;
    private GameObject rightController;
    private PlayerReady PlayerReady;
    private VerifyPositions verifyPositions;
    private float Timer = 0f;
    public int count = 0;
    public GameObject Test;

    // Vive Control GameObjects
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean squeezeAction;

    void Start()
    {
        fixation = GameObject.FindGameObjectWithTag("OrientationCheck");
        rightController = GameObject.FindGameObjectWithTag("RightController");

        Test.SetActive(false);
        
        litTarget.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (neutralTarget.activeSelf == true && Test.activeSelf == false)
        {
            StartCoroutine("ChangeDelay");
        }

        if (count > 10)
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
        }
    }

IEnumerator ReactionTime()
    {
        while (PlayerReady.litTarget.activeSelf == true)
        {
            yield return new WaitForSecondsRealtime(1f);
            Timer = Timer + 1f;
        }

        if (PlayerReady.litTarget.activeSelf == false && Timer>0)
        {
            print(Timer);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LitTarget"))
        {
            litTarget.SetActive(false);
            fixation.SetActive(true);
            Test.SetActive(true);
        }
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        neutralTarget.SetActive(false);
        litTarget.SetActive(true);
        fixation.SetActive(false);
    }
}
