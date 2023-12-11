using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAvailable : MonoBehaviour
{
    public bool isActive = false;

    public Material BlackBackground;
    public MeshRenderer thisMR;

    // Start is called before the first frame update
    void Start()
    { 
        this.GetComponent<Collider>().enabled = false;
        thisMR.material = BlackBackground;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
