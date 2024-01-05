using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLIght : MonoBehaviour
{
    public Light[] lights; // Array to hold the lights for the police effect
    public float rotationSpeed = 50.0f; // Speed of rotation

    void Update()
    {
        // Rotate the object containing the lights around the Z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

    }

}
