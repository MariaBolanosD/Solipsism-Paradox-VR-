using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSound : MonoBehaviour
{

    public AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "XR Origin")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            m_AudioSource.Play();
        }

    }

    void OnTriggerExit(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "XR Origin")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            m_AudioSource.Stop();
        }

    }
}
