using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterController r = GameObject.Find("XR Origin").GetComponent<CharacterController>();
        Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), r, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
