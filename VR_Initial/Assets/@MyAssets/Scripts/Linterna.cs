using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    int count;
    int max;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        max = 3;
    }

    // Update is called once per frame
    void Update()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];
            //Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
            bool triggerValue;
            if (rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
            {
                Debug.Log("Secondary button is pressed.");

                if(count >= max)
                {
                    // check que este dentro del area
                    this.GetComponent<Light>().enabled = !this.GetComponent<Light>().enabled;
                    count = 0;
                }
                else
                {
                    count++;
                }
            }
        }
    }
    


}
