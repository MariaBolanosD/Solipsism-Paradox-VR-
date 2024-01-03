using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Reflection1 : MonoBehaviour
{

    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<LineRenderer>().SetVertexCount(maxReflectionCount+1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void DrawPredictedReflectionPattern1(Vector3 position, Vector3 direction, int reflectionsRemaining)
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
            // Gizmos.color = Color.yellow;
            //Gizmos.DrawLine(startingPosition, position);
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
        // set the color of the line
        line.startColor = Color.red;
        line.endColor = Color.red;

        // set width of the renderer
        line.startWidth = 0.3f;
        line.endWidth = 0.3f;

        // set the position
        line.SetPosition(indx, pos0);
        line.SetPosition(indx + 1, pos1);
      
    }
}
