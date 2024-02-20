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
    public TextMeshProUGUI jumpTMP;

    public float leftLeg = 1;
    public float rightLeg = 1;

    public int condition = 0;

    public GameObject testPlayer;

    public float jumpForce = 20;


    // Start is called before the first frame update
    void Start()
    {
        //testPlayer = GameObject.Find("TestPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        DifferenceReset();

        if (leftdifference.y >= 0.3 && rightdifference.y >= 0.3)
        {
            textMeshPro.text = "Jump";
            
            condition = 3;
        }
        else if (leftdifference.y >= 0.3 && rightdifference.y < 0.3)
        {
            textMeshPro.text = "Left";
            condition = 1;
        }
        else if (leftdifference.y < 0.3 && rightdifference.y >= 0.3)
        {
            textMeshPro.text = "Right";
            condition = 2;
        }
        else
        {
            textMeshPro.text = "Stay";
            condition = 0;
        }

        if (Input.GetMouseButton(0))
        {
            JumpAction("TestPlayer");
        }
    }

    public void DifferenceReset()
    {
        leftdifference = leftPosition.difference;
        rightdifference = rightPosition.difference;
    }

    public void JumpAction(string objectName)
    {
        // Find the game object
        GameObject obj = GameObject.Find(objectName);

        // Check if the object exists
        if (obj != null)
        {
            // Get the Rigidbody component
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            // Check if the Rigidbody component exists
            if (rb != null)
            {
                if (IsGrounded(obj))
                {
                    // Reset the velocity
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    // Apply an upward force
                    //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                    rb.velocity = Vector3.up * jumpForce;
                }
            }
            else
            {
                Debug.Log("No Rigidbody component found on " + objectName);
            }
        }
        else
        {
            Debug.Log("No game object named " + objectName + " found");
        }
    }

    bool IsGrounded(GameObject obj)
    {
        // Cast a ray downward with a distance just slightly more than the collider bounds
        return Physics.Raycast(obj.transform.position, -Vector3.up, obj.GetComponent<Collider>().bounds.extents.y + 0.1f);
    }

}
