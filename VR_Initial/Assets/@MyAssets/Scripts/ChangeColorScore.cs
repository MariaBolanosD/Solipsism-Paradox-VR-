using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScore : MonoBehaviour
{
    [SerializeField] private Color _colorRed;
    [SerializeField] private Color _colorBlue;
    [SerializeField] private MeshRenderer _meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( _meshRenderer != null )
        {
           /* if(player1.score > player2.score )
            {
                _meshRenderer.material.color = _colorRed;
            }
            else
            {
                _meshRenderer.material.color = _colorBlue;
            }*/
        }
            

    }
}
