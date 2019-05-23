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
    private GameObject litHead;
    private GameObject unlitHand;
    private GameObject litHand;
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
        // If the controller is within the sphere that designates beginning hand position and the unlit hand prefab exists, destroy the unlit hand prefab and create lit hand prefab
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

        // If the controller is not within the start sphere and the lithand prefab exists, destory the lit hand prefab and create the unlit hand prefab
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

        // If the headset is within the start column and the lithead prefab does not exist, destory the unlit head prefab and create the lit head prefab
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

        // If the headset is not within the start column and the lithead prefab does exist, destory the lit head prefab and create the unlit head prefab
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
