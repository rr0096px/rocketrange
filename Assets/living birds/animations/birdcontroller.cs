using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdcontroller : MonoBehaviour
{

    Vector3 target = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
    }
}
