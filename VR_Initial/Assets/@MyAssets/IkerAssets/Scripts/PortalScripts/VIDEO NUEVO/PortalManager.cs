using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform BluePos;
    public Transform OrangePos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BluePortal"))
        {
            if (GetComponent<CharacterController>() == true)
            {
                CharacterController cc = GetComponent<CharacterController>();

                cc.enabled = false;
                transform.position = OrangePos.transform.position;
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                this.GetComponent<CharacterController>().attachedRigidbody.velocity = cc.velocity;

                cc.enabled = true;
            }
            else
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.Sleep();
                transform.position = OrangePos.transform.position;
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                this.GetComponent<Rigidbody>().velocity = rb.velocity;

                rb.WakeUp();
            }
        }

        if (other.CompareTag("OrangePortal"))
        {
            if (GetComponent<CharacterController>() == true)
            {
                CharacterController cc = GetComponent<CharacterController>();

                cc.enabled = false;
                transform.position = BluePos.transform.position;
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                this.GetComponent<CharacterController>().attachedRigidbody.velocity = cc.velocity;

                cc.enabled = true;
            }
            else
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.Sleep();
                transform.position = BluePos.transform.position;
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                this.GetComponent<Rigidbody>().velocity = rb.velocity;

                rb.WakeUp();
            }
        }
    }
}
