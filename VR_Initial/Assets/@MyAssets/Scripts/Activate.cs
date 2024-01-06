using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    bool mActivated;
    [SerializeField]
    public GameObject lampara1;
    public GameObject door;
    public Material mat;
    public GameObject locke;

    // Start is called before the first frame update
    void Start()
    {
        mActivated = false;
        door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetActivated()
    {
        return mActivated;
    }

    void Activated()
    {
        if(lampara1 != null && lampara1.GetComponent<ColoresLampara>().GetActivated())
        {
            Debug.Log("Activated");
            if(mat != null)
            {
                this.GetComponent<MeshRenderer>().material = mat;
            }
            locke.SetActive(false);
            door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

    }
}
