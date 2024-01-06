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

        if(lampara1 != null)
        {
            ColoresLampara col = lampara1.GetComponent<ColoresLampara>();
            if(col == null)
            {
                col = lampara1.GetComponentInChildren<ColoresLampara>();
            }
            if (col.GetActivated())
            {
                if (this.GetComponentInParent<MultipleActivate>() != null)
                {
                    if (lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.rojo)
                    {
                        this.GetComponentInParent<MultipleActivate>().ActivateRed();
                        if (mat != null)
                        {
                            this.GetComponent<MeshRenderer>().material = mat;
                        }
                    }
                    else if (lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.azul)
                    {
                        this.GetComponentInParent<MultipleActivate>().ActivateBlue();
                        if (mat != null)
                        {
                            this.GetComponent<MeshRenderer>().material = mat;
                        }
                    }
                    else if (lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.verde)
                    {
                        this.GetComponentInParent<MultipleActivate>().ActivateGreen();
                        if (mat != null)
                        {
                            this.GetComponent<MeshRenderer>().material = mat;
                        }
                    }
                    else if (lampara1.GetComponent<ColoresLampara>().GetColor() == ColoresLampara.Color.amarillo)
                    {
                        this.GetComponentInParent<MultipleActivate>().ActivateYellow();
                        if (mat != null)
                        {
                            this.GetComponent<MeshRenderer>().material = mat;
                        }
                    }

                }
                else
                {
                    Debug.Log("Activated");
                    if (mat != null)
                    {
                        this.GetComponent<MeshRenderer>().material = mat;
                    }
                    if (locke)
                        locke.SetActive(false);
                    door.SetActive(false);
                }
            }
        }

    }
}
