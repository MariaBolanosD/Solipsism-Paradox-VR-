using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWinner : MonoBehaviour
{

    [SerializeField] Material RedMat;
    [SerializeField] Material BlueMat;
    [SerializeField] Material WhiteMat;
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Blue;

    private int RedScore;
    private int BlueScore;

    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        RedScore = Red.GetComponent<ScoreUpdater>().GetScore();
        BlueScore = Blue.GetComponent<ScoreUpdater>().GetScore();

        if(RedScore > BlueScore)
        {
            _renderer.material = RedMat;
        }
        else if ( RedScore == BlueScore)
        {
            _renderer.material = WhiteMat;
        }
        else
        {
            _renderer.material = BlueMat;
        }
    }
}
