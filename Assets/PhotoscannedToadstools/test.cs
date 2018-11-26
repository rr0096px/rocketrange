using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    float speed = 0;

	// Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
    void Update () {

        this.speed = 0.2f;

        transform.Translate(this.speed, 10, 32);

	}
}
