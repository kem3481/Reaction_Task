using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using System.Threading;


public class Trial : MonoBehaviour
{
    private GameObject fixation;
    private GameObject rightController;
    private PlayerReady PlayerReady;
    private GameObject resetText;

    public GameObject Test;

    // Vive Control GameObjects
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean squeezeAction;

    void Start()
    {
        fixation = GameObject.FindGameObjectWithTag("OrientationCheck");
        rightController = GameObject.FindGameObjectWithTag("RightController");

        Test.SetActive(false);

        //Accessing variables from PlayerReady Script
        PlayerReady = GetComponent<PlayerReady>();
        PlayerReady.litTarget.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerReady.neutralTarget.activeSelf == true && Test.activeSelf == false)
        {
            StartCoroutine("ChangeDelay");
        }

        if (rightController.transform.localPosition.x > -.05 &&
            rightController.transform.localPosition.x <  .05 &&
            rightController.transform.localPosition.z > -.01 &&
            rightController.transform.localPosition.z <  .01 &&
            rightController.transform.localPosition.y > 1.20 &&
            rightController.transform.localPosition.y < 1.30)
        {
            PlayerReady.litTarget.SetActive(false);
            PlayerReady.neutralTarget.SetActive(false);
            fixation.SetActive(true);
            Test.SetActive(true);
        }
 
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LitTarget"))
        {
            PlayerReady.litTarget.SetActive(false);
            PlayerReady.neutralTarget.SetActive(true);
            Test.SetActive(true);
        }
    }*/

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSecondsRealtime(3f);
        PlayerReady.neutralTarget.SetActive(false);
        PlayerReady.litTarget.SetActive(true);
        fixation.SetActive(false);
    }
}
