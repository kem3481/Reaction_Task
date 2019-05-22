using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RestartTrial : MonoBehaviour
{
    public GameObject Test;
    private VerifyPositions verifyPositions;
    private PlayerReady playerReady;
    private Trial trialScript;

    // Vive Control GameObjects
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean squeezeAction;

    // Start is called before the first frame update
    void Start()
    {
        Test.SetActive(false);

        verifyPositions = GetComponent<VerifyPositions>();
        playerReady = GetComponent<PlayerReady>();
        trialScript = GetComponent<Trial>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Test.activeSelf == true)
          {
              playerReady.headColumn.SetActive(true);
              playerReady.handSphere.SetActive(true);
          }

        bool GetSqueeze()
        {
            return squeezeAction.GetStateDown(handType);
        }

        if (GetSqueeze())
        {
            playerReady.headColumn.SetActive(false);
            playerReady.handSphere.SetActive(false);
            Test.SetActive(false);
        }

    }
}
