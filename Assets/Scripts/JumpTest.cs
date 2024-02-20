using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpTest : MonoBehaviour
{

    public LeftPosition leftPosition;
    public RightPosition rightPosition;

    public Vector3 leftdifference;
    public Vector3 rightdifference;

    public TextMeshProUGUI textMeshPro;

    public float leftLeg = 1;
    public float rightLeg = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DifferenceReset();

        if (leftdifference.y >= 0.3 && rightdifference.y >= 0.3)
        {
            textMeshPro.text = "Jump";
        }
        else if (leftdifference.y >= 0.3 && rightdifference.y < 0.3)
        {
            textMeshPro.text = "Left";
        }
        else if (leftdifference.y < 0.3 && rightdifference.y >= 0.3)
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
