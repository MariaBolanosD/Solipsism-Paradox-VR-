using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Portalrefle : MonoBehaviour
{
    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<LineRenderer>().positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            int i = (5 - reflectionsRemaining);
            DrawLine1(startingPosition, position, i);
            DrawPredictedReflectionPattern1(position, direction, reflectionsRemaining - 1);

        }
        else
        {
            position += direction * maxStepDistance;
        }


    }
    // Apply these values in the editor

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