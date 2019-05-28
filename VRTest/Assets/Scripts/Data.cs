/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public Trial trialScript;
    public List<float> xPositions;

    // Start is called before the first frame update
    void Start()
    {
        trialScript = GetComponent<Trial>();

        List<float> xPositions = new List<float>();

        if (xPositions.Count < 2)
        {
            print(xPositions);
        }
    }

    // Update is called once per frame
    void Update()
    {
       for (int i = 0; i < trialScript.count - 1; i++)
        {
            xPositions.Add(trialScript.CollisionPosition_x);
        }
    }
}
*/