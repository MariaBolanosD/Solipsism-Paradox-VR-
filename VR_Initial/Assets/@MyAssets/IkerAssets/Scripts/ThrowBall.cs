using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField]
    GameObject controller;
    Rigidbody rb;
    public float force = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    public void LanzarPelota()
    {
        //rb.AddForce(controller.transform.vetc * force, ForceMode.Impulse);
    }
}



