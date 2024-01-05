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
            if (this.gameObject.GetComponent<CharacterController>() == true)
            {
                CharacterController cc = GetComponent<CharacterController>();

                cc.enabled = false;
                transform.position = OrangePos.transform.position;
                Quaternion rotation = Quaternion.Euler(0, this.transform.rotation.y-90, 0);
                transform.rotation = rotation;
                cc.enabled = true;
            }
            else
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.Sleep();
                transform.position = OrangePos.transform.position;
                transform.rotation = OrangePos.transform.rotation;
                this.GetComponent<Rigidbody>().velocity = rb.velocity;

                rb.WakeUp();
            }
        }

        if (other.CompareTag("OrangePortal"))
        {
            if (this.gameObject.GetComponent<CharacterController>() == true)
            {
                CharacterController cc = GetComponent<CharacterController>();

                cc.enabled = false;
                transform.position = BluePos.transform.position;
                Quaternion rotation = Quaternion.Euler(0, 180f, 0);
                transform.rotation = rotation;
                cc.enabled = true;
            }
            else
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.Sleep();
                transform.position = BluePos.transform.position;
                transform.rotation = BluePos.transform.rotation;
                this.GetComponent<Rigidbody>().velocity = rb.velocity;

                rb.WakeUp();
            }
        }
    }
}
