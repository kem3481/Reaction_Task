using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTrial : MonoBehaviour
{
    private GameObject Test;
    //private GameObject resetText;
    private VerifyPositions verifyPositions;
    private PlayerReady playerReady;

    // Start is called before the first frame update
    void Start()
    {
        Test = GameObject.FindGameObjectWithTag("BEEPBOOP");
        Test.SetActive(false);

        verifyPositions = GetComponent<VerifyPositions>();
        playerReady = GetComponent<PlayerReady>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Test.activeSelf == true)
          {
              playerReady.headColumn.SetActive(true);
              playerReady.handSphere.SetActive(true);
          }

    }
}
