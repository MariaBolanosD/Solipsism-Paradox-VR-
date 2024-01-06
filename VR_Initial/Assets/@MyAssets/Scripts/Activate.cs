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
            if (this.GetComponentInParent<MultipleActivate>() != null)
            { 
                if(lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.rojo)
                {
                    this.GetComponentInParent<MultipleActivate>().ActivateRed();
                }
                else if (lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.azul)
                {
                    this.GetComponentInParent<MultipleActivate>().ActivateBlue();
                }
                if (lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.verde)
                {
                    this.GetComponentInParent<MultipleActivate>().ActivateGreen();
                }
                if (lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.amarillo)
                {
                    this.GetComponentInParent<MultipleActivate>().ActivateYellow();
                }
            }
            else 
            {
                Debug.Log("Activated");
                if (mat != null)
                {
                    this.GetComponent<MeshRenderer>().material = mat;
                }
                locke.SetActive(false);
                door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }

    }
}
