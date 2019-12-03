using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Dice : MonoBehaviour
{
    Rigidbody rb;
    Collider col;
    [SerializeField]
    private Vector3 _initialForce;

    [SerializeField]
    private Vector3 _num1Rotation;
    [SerializeField]
    private Vector3 _num2Rotation;
    [SerializeField]
    private Vector3 _num3Rotation;
    [SerializeField]
    private Vector3 _num4Rotation;
    [SerializeField]
    private Vector3 _num5Rotation;
    [SerializeField]
    private Vector3 _num6Rotation;

    public int _finalResult;

    private void FixedUpdate()
    { 

        //Add more gravity:
        rb.AddTorque(rb.velocity.magnitude, rb.velocity.magnitude, rb.velocity.magnitude);
        // rb.AddForce(Physics.gravity * 25, ForceMode.Acceleration);
    }

    public void ForceFifthRollDoubleOne()
    {

    }

    private void PredetermineResult(int result)
    {
        //Modify rotation in the beginning:
        // For dice 1:
        //Dice 1 child rotation:Vector3(-90,-90,-0)
        //Dice 2 child rotation:Vector3(0,0,-90)
        //Dice 3 child rotation:Vector3(0,0,0)
        //Dice 4 child rotation:Vector3(0,0,180)
        //Dice 5 child rotation:Vector3(0,0,90)
        //Dice 6 child rotation:Vector3(90,90,0)

        // For dice 2:
        //Dice 1 child rotation:Vector3(0,270,0)
        //Dice 2 child rotation:Vector3(0,0,270)
        //Dice 3 child rotation:Vector3(0,0,0)
        //Dice 4 child rotation:Vector3(0,180,0)
        //Dice 5 child rotation:Vector3(0,90,0)
        //Dice 6 child rotation:Vector3(0,0,0)

        int num = 0;
        if (result < 1 || result > 6)
        {
            num = Random.Range(0, 6) + 1;
        }
        else
        {
            num = result;
        }
        
        switch (num)
        {
            case 1:
                transform.GetChild(0).eulerAngles = _num1Rotation;
                break;
            case 2:
                transform.GetChild(0).eulerAngles = _num2Rotation;
                break;
            case 3:
                transform.GetChild(0).eulerAngles = _num3Rotation;
                break;
            case 4:
                transform.GetChild(0).eulerAngles = _num4Rotation;
                break;
            case 5:
                transform.GetChild(0).eulerAngles = _num5Rotation;
                break;
            case 6:
                transform.GetChild(0).eulerAngles = _num6Rotation;
                break;
            default:
                Debug.Log("Number Doesn't Exist!");
                break;
        }

        _finalResult = num;
    }

    public void Roll(int result)
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        PredetermineResult(result);
        
        rb.useGravity = true;
        rb.AddForce(_initialForce, ForceMode.Impulse);
    }
}
