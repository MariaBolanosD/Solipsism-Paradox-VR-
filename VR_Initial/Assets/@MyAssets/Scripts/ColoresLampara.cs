using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoresLampara : MonoBehaviour
{
    public enum Color
    {   
        rojo,
        verde,
        azul,
        amarillo
    };


    public Color color;
    // Start is called before the first frame update
    void Start()
    {
    }

    void HitByRay()
    {
        Debug.Log("I was hit by a Ray");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public Color GetColor()
    {
        return color;
    }
    


}
