using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LaserShooting : MonoBehaviour
{

    public int gunDamage = 1;                                            // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.25f;                                        // Number in seconds which controls how often the player can fire
    public float weaponRange = 800f;                                        // Distance in Unity units over which the player can fire
    public float hitForce = 100f;                                        // Amount of force which will be added to objects with a rigidbody shot by the player
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun



    private Camera fpsCam;                                                // Holds a reference to the first person camera
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    //private AudioSource gunAudio;                                        // Reference to the audio source which will play our shooting sound effect
    private LineRenderer laserLine;                                        // Reference to the LineRenderer component which will display our laserline
    private float nextFire;                                                // Float to store the time the player will be allowed to fire again, after firing


    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();

        // Get and store a reference to our AudioSource component
        //gunAudio = GetComponent<AudioSource>();

        // Get and store a reference to our Camera by searching this GameObject and its parents
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count == 1)
        {
            //Input.GetButtonDown("Fire1")
            bool triggerValue;
            // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
            if (rightHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && Time.time > nextFire)
            {
                // Update the time when our player can fire next
                nextFire = Time.time + fireRate;

                // Start our ShotEffect coroutine to turn our laser line on and off
                StartCoroutine(ShotEffect());



                // Create a vector at the center of our camera's viewport
                Vector3 rayOrigin = this.transform.position;// fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                // Declare a raycast hit to store information about what our raycast has hit
                RaycastHit hit;

                // Set the start position for our visual effect for our laser to the position of gunEnd
                laserLine.SetPosition(0, gunEnd.position);

                // Check if our raycast has hit anything
                Ray ray = new Ray(this.transform.position, this.transform.forward);
                //if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                if (Physics.Raycast(ray, out hit, 1000000000000))
                {
                    // Set the end position for our laser line 
                    laserLine.SetPosition(1, hit.point);

                    // Get a reference to a health script attached to the collider we hit
                    ScoreUpdater target = hit.collider.GetComponent<ScoreUpdater>();
                    if (target)
                        target.UpdateScoreOnHit();

                    // Check if the object we hit has a rigidbody attached
                    //if (hit.rigidbody != null)
                    //{
                    //    // Add force to the rigidbody we hit, in the direction from which it was hit
                    //    hit.rigidbody.AddForce(-hit.normal * hitForce);
                    //}
                }
                else
                {
                    // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                    //laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                    laserLine.SetPosition(1, rayOrigin + (this.transform.forward * weaponRange));
                }
            }
        }
    }


    private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        //gunAudio.Play();

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}