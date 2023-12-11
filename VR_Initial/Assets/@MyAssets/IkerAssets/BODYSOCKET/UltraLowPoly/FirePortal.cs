using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(AudioSource))]
public class FirePortal : MonoBehaviour
{
    public Transform frontOfGun;
    public float range;
    public GameObject portal;
    public PortalAvailable portalAvb;
 
    public static event Action GunFired;
    public void Fire()
    {
        GetComponent<AudioSource>().Play();
        RaycastHit hit;
        if(Physics.Raycast(frontOfGun.position, frontOfGun.forward, out hit,range))
        {
            portal.transform.position = hit.point;
            portalAvb.isActive = true;
        }
        GunFired?.Invoke();
    }


}
