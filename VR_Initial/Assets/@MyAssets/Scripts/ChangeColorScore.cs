using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScore : MonoBehaviour
{
    [SerializeField] private GameObject _Red;
    [SerializeField] private GameObject _Blue;
    [SerializeField] private MeshRenderer _meshRenderer;


    ScoreUpdater p1_red;
    ScoreUpdater p2_blue;

    // Start is called before the first frame update
    void Start()
    {
        p1_red = _Red.GetComponent<ScoreUpdater>();
        p2_blue = _Blue.GetComponent<ScoreUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
        if( _meshRenderer != null )
        {

            if(p1_red.GetScore() > p2_blue.GetScore())
            {
                _meshRenderer.material.color = Color.red;
            }
            else
            {
                _meshRenderer.material.color = Color.blue;            
           
            }

        }
            

    }
}
