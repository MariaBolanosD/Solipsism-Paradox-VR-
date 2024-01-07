using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public GameObject cadena;
    public GameObject key;
    public GameObject Cube;

    public void Unlock()
    {
        door.SetActive(false);
        cadena.SetActive(false);
        key.SetActive(false);   
        if(Cube != null)
        {
            Cube.SetActive(true);
        }
    }
}
