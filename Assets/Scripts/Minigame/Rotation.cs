using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    private float rotationZ;
    public float RotationSpeed;
    public bool ClockwiseRotation;

    void Update()
    {
        if (ClockwiseRotation == false)
        {
            rotationZ += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotationZ += Time.deltaTime * RotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
