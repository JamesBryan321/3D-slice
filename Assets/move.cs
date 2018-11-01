using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public GameObject rat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
        rat.GetComponent<Rigidbody>().velocity = rat.transform.forward * 6;

   ;
    }
}
