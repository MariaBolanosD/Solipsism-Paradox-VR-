using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] GameObject Limit;

    private Vector3 distance_Player = new Vector3(150,150,150);
    private string tagger ;
    private void Start()
    {
        tagger= Limit.tag;
    }


    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(tagger))
        {
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * 0.5f);
            Target.transform.position = rndPosWithin;
        }
    }
}
