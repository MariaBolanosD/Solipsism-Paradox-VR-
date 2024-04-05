using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] GameObject Limit;
    [SerializeField] GameObject ScoreGO;

    private Vector3 distance_Player = new Vector3(150,150,150);
    private string tagger ;

    private int score = 0;

    private void Start()
    {
        tagger= Limit.tag;
    }


    void Update()
    {
       //if (Input.GetKeyDown(KeyCode.Space))
       //{
       //     TeleportInsideTaggedArea();
       //}


    }

    public void UpdateScoreOnHit()
    {
        score += 1;
        ScoreGO.GetComponent<ColorWinner>().UpdateScore();
        TeleportInsideTaggedArea();
    }

    public int GetScore()
    {
        return score;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagger))
        {
            TeleportInsideTaggedArea();
        }
    }

    void TeleportInsideTaggedArea()
    {
        GameObject taggedObject = GameObject.FindGameObjectWithTag(tagger);
        if (taggedObject != null)
        {
            Collider collider = taggedObject.GetComponent<Collider>();
            if (collider != null)
            {
                Vector3 center = collider.bounds.center;
                Vector3 size = collider.bounds.size;

                Vector3 rndPosInside;
                rndPosInside = new Vector3(Random.Range(-size.x / 2f, size.x / 2f),
                                           Random.Range(-size.y / 2f, size.y / 2f),
                                           Random.Range(-size.z / 2f, size.z / 2f));
                rndPosInside += center;
                Target.transform.position = rndPosInside;
            }
            else
            {
                Debug.LogError("No collider found on object with tag: " + tagger);
            }
        }
        else
        {
            Debug.LogError("No object found with tag: " + tagger);
        }
    }

}
