using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class FirePortal : MonoBehaviour
{
    public Transform frontOfGun;
    public float range;
    public GameObject portalParent;
    public PortalAvailable portalAvb;

    public void Fire()
    {
            RaycastHit hit;
            if (Physics.Raycast(frontOfGun.position, frontOfGun.forward, out hit, range))
            {
            portalParent.transform.position = hit.point;
            portalParent.transform.LookAt(frontOfGun.position);
               portalAvb.isActive = true;
            }
    }

}
