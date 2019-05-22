using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class VerifyPositions : MonoBehaviour
{
    private GameObject rightController;
    private GameObject head;
    private GameObject headStart;
    private GameObject unlitHead;
    public GameObject litHead;
    private GameObject unlitHand;
    public GameObject litHand;
    private GameObject beginText;
    private GameObject headColumn;
    private GameObject handSphere;

    public GameObject LightPrefab_unlit;
    public GameObject LightPrefab_lit;

    // Start is called before the first frame update
    void Start()
    {
        rightController = GameObject.FindGameObjectWithTag("RightController");
        head = GameObject.FindGameObjectWithTag("Camera");

        unlitHead = Instantiate(LightPrefab_unlit);
        unlitHead.transform.position = new Vector3 (0f, 1.05f, -0.2f);

        unlitHand = Instantiate(LightPrefab_unlit);
        unlitHand.transform.position = new Vector3 (0f, 1.05f, -0.15f);
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (unlitHand != null &&
            rightController.transform.localPosition.x > .20 &&
            rightController.transform.localPosition.x < .30 &&
            rightController.transform.localPosition.y > 1.1 &&
            rightController.transform.localPosition.y < 1.2 &&
            rightController.transform.localPosition.z > -.3 &&
            rightController.transform.localPosition.z < -.2)
        {
            Destroy(unlitHand);
            litHand = Instantiate(LightPrefab_lit);
            litHand.transform.position = new Vector3(0f, 1.05f, -0.15f);
        }

        if (litHand != null &&
           (rightController.transform.localPosition.x < .20 ||
           rightController.transform.localPosition.x > .30 ||
           rightController.transform.localPosition.y < 1.1 ||
           rightController.transform.localPosition.y > 1.2 ||
           rightController.transform.localPosition.z < -.3 ||
           rightController.transform.localPosition.z > -.2))
        {
            Destroy(litHand);
            unlitHand = Instantiate(LightPrefab_unlit);
            unlitHand.transform.position = new Vector3(0f, 1.05f, -0.15f);
        }

        if (unlitHead != null &&
           head.transform.localPosition.x > -.05 &&
           head.transform.localPosition.x < .05 &&
           head.transform.localPosition.y > 1.2 &&
           head.transform.localPosition.y < 1.6 &&
           head.transform.localPosition.z > -.55 &&
           head.transform.localPosition.z < -.45)
        {
            Destroy(unlitHead);
            litHead = Instantiate(LightPrefab_lit);
            litHead.transform.position = new Vector3(0f, 1.05f, -0.2f);
        }

        if (litHead != null &&
           (head.transform.localPosition.x < -.05 ||
           head.transform.localPosition.x > .05 ||
           head.transform.localPosition.y < 1.2 ||
           head.transform.localPosition.y > 1.6 ||
           head.transform.localPosition.z < -.55 ||
           head.transform.localPosition.z > -.45))
        {
            Destroy(litHead);
            unlitHead = Instantiate(LightPrefab_unlit);
            unlitHead.transform.position = new Vector3(0f, 1.05f, -0.2f);
        }
    }

}
