using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFinalDoor : MonoBehaviour
{
    public GameObject CubeGreen;
    public GameObject CubeBlue;
    public GameObject CubeRed;
    public GameObject FinalDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CubeGreen.activeSelf && CubeBlue.activeSelf && CubeRed.activeSelf)
        {
            FinalDoor.SetActive(false);
        }
    }
}
