using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleActivate : MonoBehaviour
{
    bool red;
    bool blue;
    bool green;
    bool yellow;
    public GameObject locke;
    public GameObject door1;
    public GameObject door2;

    // Start is called before the first frame update
    void Start()
    {
        red = false;
        blue = false;
        green = false;
        yellow = false;
        door1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        door2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ActivateRed()
    {
        Debug.Log("Red");
        red = true;
        if(blue && red && green && yellow)
        {
            Activated();
        }
    }
    public void ActivateBlue()
    {
        Debug.Log("Blue");
        blue = true;
        if (blue && red && green && yellow)
        {
            Activated();
        }
    }
    public void ActivateGreen()
    {
        Debug.Log("Green");
        green = true;
        if (blue && red && green && yellow)
        {
            Activated();
        }
    }
    public void ActivateYellow()
    {
        Debug.Log("Yellow");
        yellow = true;
        if (blue && red && green && yellow)
        {
            Activated();
        }
    }

    void Activated()
    {
         Debug.Log("Activated");
         locke.SetActive(false);
         door1.SetActive(false);
         door2.SetActive(false);
    }
}
