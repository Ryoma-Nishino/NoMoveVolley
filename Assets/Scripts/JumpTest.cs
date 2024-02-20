using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpTest : MonoBehaviour
{

    LeftPosition leftPosition;
    RightPosition rightPosition;

    public Vector3 leftdifference;
    public Vector3 rightdifference;

    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DifferenceReset();

        if (leftdifference.y >= 1 && rightdifference.y >= 1)
        {
            textMeshPro.text = "Jump";
        }
        else if (leftdifference.y >= 1 && rightdifference.y < 1)
        {
            textMeshPro.text = "Left";
        }
        else if (leftdifference.y < 1 && rightdifference.y >= 1)
        {
            textMeshPro.text = "Right";
        }
        else
        {
            textMeshPro.text = "Stay";
        }
    }

    public void DifferenceReset()
    {
        leftdifference = leftPosition.difference;
        rightdifference = rightPosition.difference;
    }
}
