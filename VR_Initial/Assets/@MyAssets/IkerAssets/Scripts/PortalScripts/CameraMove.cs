using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Quaternion TargetRotation;

    [SerializeField]
    private Camera maincamera;

    // Start is called before the first frame update
    void Awake()
    {
        TargetRotation = maincamera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
