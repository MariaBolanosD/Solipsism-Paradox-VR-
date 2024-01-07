using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FinalCubes : MonoBehaviour
{
    public GameObject parent;
    public XRSocketInteractor socket;
    public GameObject door_l;
    public GameObject door_r;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SocketCheck()
    {
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        if(this.gameObject.name.Equals("Cube_BLUE") && objName.Equals("Cube_AZUL"))
        {
            parent.GetComponent<ParentCube>().Cube_blue = true;
            if(parent.GetComponent<ParentCube>().Cube_green && parent.GetComponent<ParentCube>().Cube_blue && parent.GetComponent<ParentCube>().Cube_red)
            {
                door_l.SetActive(false);
                door_r.SetActive(false);
            }
        }
        else
        {
            parent.GetComponent<ParentCube>().Cube_blue = false;
        }
        if (this.gameObject.name.Equals("Cube_RED") && objName.Equals("Cube_ROJO"))
        {
            parent.GetComponent<ParentCube>().Cube_red = true;
            if (parent.GetComponent<ParentCube>().Cube_green && parent.GetComponent<ParentCube>().Cube_blue && parent.GetComponent<ParentCube>().Cube_red)
            {
                door_l.SetActive(false);
                door_r.SetActive(false);
            }
        }
        else
        {
            parent.GetComponent<ParentCube>().Cube_red = false;
        }
        if (this.gameObject.name.Equals("Cube_GREEN") && objName.Equals("Cube_VERDE"))
        {
            parent.GetComponent<ParentCube>().Cube_green = true;
            if (parent.GetComponent<ParentCube>().Cube_green && parent.GetComponent<ParentCube>().Cube_blue && parent.GetComponent<ParentCube>().Cube_red)
            {
                door_l.SetActive(false);
                door_r.SetActive(false);
            }
        }
        else
        {
            parent.GetComponent<ParentCube>().Cube_green = false;
        }
    }

}
