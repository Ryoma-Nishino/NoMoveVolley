using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the position of the game object
        Vector3 position = transform.position;

        // Log the position
        Debug.Log("Position: " + position);
    }
}
