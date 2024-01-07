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


    public void SocketCheck()
    {
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        if (this.gameObject.name.Equals("Cube_BLUE") && (objName.transform.name == ("Cube_AZUL")))
        {
            parent.GetComponent<ParentCube>().Cube_blue = true;
            if (parent.GetComponent<ParentCube>().Cube_green && parent.GetComponent<ParentCube>().Cube_blue && parent.GetComponent<ParentCube>().Cube_red)
            {
                door_l.SetActive(false);
                door_r.SetActive(false);
            }
        }
        else if (this.gameObject.name.Equals("Cube_BLUE") && (objName.transform.name != ("Cube_AZUL")))
        {
            parent.GetComponent<ParentCube>().Cube_blue = false;
        }
        if (this.gameObject.name.Equals("Cube_RED") && (objName.transform.name == ("Cube_ROJO")))
        {
            parent.GetComponent<ParentCube>().Cube_red = true;
            if (parent.GetComponent<ParentCube>().Cube_green && parent.GetComponent<ParentCube>().Cube_blue && parent.GetComponent<ParentCube>().Cube_red)
            {
                door_l.SetActive(false);
                door_r.SetActive(false);
            }
        }
        else if (this.gameObject.name.Equals("Cube_RED") && (objName.transform.name != ("Cube_ROJO")))
        {
            {
                parent.GetComponent<ParentCube>().Cube_red = false;
            }
        }
        if (this.gameObject.name.Equals("Cube_GREEN") && (objName.transform.name == ("Cube_VERDE")))
        {
            parent.GetComponent<ParentCube>().Cube_green = true;
            if (parent.GetComponent<ParentCube>().Cube_green && parent.GetComponent<ParentCube>().Cube_blue && parent.GetComponent<ParentCube>().Cube_red)
            {
                door_l.SetActive(false);
                door_r.SetActive(false);
            }
        }
        else if (this.gameObject.name.Equals("Cube_GREEN") && (objName.transform.name != ("Cube_VERDE")))

        {
            parent.GetComponent<ParentCube>().Cube_green = false;
        }
    }
    

}
