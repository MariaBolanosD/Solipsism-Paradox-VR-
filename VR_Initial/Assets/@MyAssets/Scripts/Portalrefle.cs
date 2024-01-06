using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Portalrefle : MonoBehaviour
{
    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;
    bool lampara;
    ColoresLampara color;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<LineRenderer>().positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lampara = false;
    }

    public void DrawPredictedReflectionPattern1(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;


        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            if (hit.collider.CompareTag("Lampara") == true)
            {
                // ha colisionado con una lampara
                if (hit.collider.GetComponent<ColoresLampara>().GetColor() == color.GetColor())
                {
                    // los colores son los mismos
                    hit.transform.SendMessage("ActivatedLampara");
                    lampara = true;
                    direction = hit.transform.forward;
                    position = hit.point;
                    int i = (5 - reflectionsRemaining);
                    DrawLine1(startingPosition, position, i);

                    DrawPredictedReflectionPattern1(position, direction, reflectionsRemaining - 1);
                }
                else
                {
                    direction = Vector3.Reflect(direction, hit.normal);
                    position = hit.point;
                    int i = (5 - reflectionsRemaining);
                    DrawLine1(startingPosition, position, i++);
                    for (; i < 5; i++)
                    {
                        DrawLine1(position, position, i);
                    }
                }
            }
            else if (hit.collider.CompareTag("Target") == true)
            {
                if (lampara)
                {
                    hit.transform.SendMessage("Activated");
                }

            }
            else
            {
                direction = Vector3.Reflect(direction, hit.normal);
                position = hit.point;
                int i = (5 - reflectionsRemaining);
                DrawLine1(startingPosition, position, i);

                DrawPredictedReflectionPattern1(position, direction, reflectionsRemaining - 1);
            }
        }
        else
        {
            position += direction * maxStepDistance;
        }


    }
    // Apply these values in the editor

    public void SetLightColor(ColoresLampara col)
    {
        this.color = col;
    }

    public void SetMaterial(Material mat)
    {
        LineRenderer line = this.GetComponent<LineRenderer>();

        line.material = mat;
    }

    void DrawLine1(Vector3 pos0, Vector3 pos1, int indx)
    {
        LineRenderer line = this.GetComponent<LineRenderer>();

        // set width of the renderer
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;

        // set the position
        line.SetPosition(indx, pos0);
        line.SetPosition(indx + 1, pos1);

    }
}