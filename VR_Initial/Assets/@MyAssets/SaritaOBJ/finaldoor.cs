using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class finaldoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    public XRSocketInteractor socket;
    public GameObject door_l;
    public GameObject door_r;
    public void Green()
    {
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();

       
        if (objName.transform.name == ("Cube_VERDE"))
        {
            door_l.SetActive(false);
            door_r.SetActive(false);
        }
    }

    public void Red()
    {
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        if (objName.transform.name == ("Cube_ROJO"))
        {
            door_l.SetActive(false);
            door_r.SetActive(false);
        }

    }

    public void Blue()
    {
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        if (objName.transform.name == ("Cube_AZUL"))
        {
            door_l.SetActive(false);
            door_r.SetActive(false);
        }
    }
}
