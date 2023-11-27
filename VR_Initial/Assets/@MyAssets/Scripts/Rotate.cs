using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float speed;


    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.Rotate(speed * direction * Time.deltaTime);
    }
}
