using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPair : MonoBehaviour
{
    private Portal inPortal;
    private Portal outPortal;

    public Portal[] Portals = new Portal[2];

    // Start is called before the first frame update
    void Awake()
    {
        Portals[0] = inPortal;
        Portals[1] = outPortal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
