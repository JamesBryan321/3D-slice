using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightswitch : MonoBehaviour {
    private Animator Lswitch;

    // Use this for initialization
    void Start () {
        Lswitch = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {

         
                Lswitch.SetBool("Light", true);
            

        }
    }
}
