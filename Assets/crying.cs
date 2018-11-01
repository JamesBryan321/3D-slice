using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crying : MonoBehaviour {

    public AudioSource baby;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            baby.Play();
        }
    }
}
