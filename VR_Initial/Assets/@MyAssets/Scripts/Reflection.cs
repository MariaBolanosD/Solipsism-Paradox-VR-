using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Reflection : MonoBehaviour
{

    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;
    public GameObject blue;
    public GameObject orange;
    bool lampara;
    public Color colorcito;

    // Start is called before the first frame update
    void Start()
    {
        lampara = false;
        GetComponent<LineRenderer>().positionCount = (maxReflectionCount+1);
    }

    // Update is called once per frame
    void Update()
    {
        blue.GetComponent<LineRenderer>().positionCount = 0;
        orange.GetComponent<LineRenderer>().positionCount = 0;
        lampara = false;
        DrawPredictedReflectionPattern(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, maxReflectionCount);
    }

    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;
        Vector3 x = new Vector3(0, 0, 0);

        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            if (hit.collider.CompareTag("OrangePortal") == true)
            {
                direction = Vector3.Reflect(direction, hit.normal);
                // change position to go out of blue portal
                Vector3 organgepos = hit.point;

                Vector3 organge = hit.collider.transform.position;
                position = hit.point;
                int i = (5 - reflectionsRemaining);
                DrawLine(startingPosition, position, i++);
                for (; i < 5; i++)
                {
                    DrawLine(position, position, i);
                }

                blue.GetComponent<LineRenderer>().positionCount = maxReflectionCount + 1;
                blue.GetComponent<Portalrefle>().DrawPredictedReflectionPattern1(blue.transform.position + blue.transform.forward * 1.0f, direction, 5);
            }
            else if (hit.collider.CompareTag("BluePortal") == true)
            {
                direction = Vector3.Reflect(direction, hit.normal);
                // change position to go out of blue portal
                Vector3 organgepos = hit.point;

                Vector3 organge = hit.collider.transform.position;
                position = hit.point;
                int i = (5 - reflectionsRemaining);
                DrawLine(startingPosition, position, i++);
                for (; i < 5; i++)
                {
                    DrawLine(position, position, i);
                }

                orange.GetComponent<LineRenderer>().positionCount = maxReflectionCount + 1;
                orange.GetComponent<Portalrefle>().DrawPredictedReflectionPattern1(orange.transform.position + orange.transform.forward * 1.0f, direction, 5);
            }
            else if (hit.collider.CompareTag("Lampara") == true)
            {
                // ha colisionado con una lampara
                if (hit.collider.GetComponent<ColoresLampara>().GetColor() == this.GetComponent<ColoresLampara>().GetColor())
                {
                    // los colores son los mismos
                    hit.transform.SendMessage("ActivatedLampara");
                    lampara = true;
                    direction = hit.transform.forward;
                    position = hit.point;
                    int i = (5 - reflectionsRemaining);
                    DrawLine(startingPosition, position, i);

                    DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
                }
                else
                {
                    direction = Vector3.Reflect(direction, hit.normal);
                    position = hit.point;
                    int i = (5 - reflectionsRemaining);
                    DrawLine(startingPosition, position, i++);
                    for (; i < 5; i++)
                    {
                        DrawLine(position, position, i);
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
                DrawLine(startingPosition, position, i);

                DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
            }
        }
        else
        {
            position += direction * maxStepDistance;
        }

       
    }
    // Apply these values in the editor

    void DrawLine(Vector3 pos0, Vector3 pos1, int indx)
    {
        LineRenderer line = this.GetComponent<LineRenderer>();
        // set the color of the line
        line.startColor = Color.red;
        line.endColor = Color.red;

        // set width of the renderer
        //line.startWidth = 0.3f;
        //line.endWidth = 0.3f;

        // set the position
        line.SetPosition(indx, pos0);
        line.SetPosition(indx + 1, pos1);
      
    }
}
