using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerPortal : MonoBehaviour
{

    public PortalAvailable BluePortalAvb;
    public PortalAvailable OrangePortalAvb;

    public MeshRenderer BluePortalMR;
    public MeshRenderer OrangePortalMR;

    public Material BlueViewMaterial;
    public Material OrangeViewMaterial;

    // Update is called once per frame
    void Update()
    {
        if (OrangePortalAvb.isActive == true && BluePortalAvb.isActive == true)
        {
            OrangePortalAvb.gameObject.GetComponent<Collider>().enabled = true;
            BluePortalAvb.gameObject.GetComponent<Collider>().enabled = true;

            OrangePortalMR.material = BlueViewMaterial;
            BluePortalMR.material = OrangeViewMaterial;




        }
    }
}
