using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public Trial trialScript;
    public List<float> xPositions = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        trialScript = GetComponent<Trial>();
        
    }

    // Update is called once per frame
    void Update()
    {
       for (int i = 0; i < trialScript.count - 1; i++)
        {
            xPositions.Add(trialScript.CollisionPosition_x);

            if (i == trialScript.count )
            {
                print("xPositions");
            }
        }
    }
}
