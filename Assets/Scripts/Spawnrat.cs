using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnrat : MonoBehaviour
{



    public int ufoSpeed;
    public float Timer = 2;
    public GameObject ufo;
    GameObject ufoClone;
    public Transform spawnPoint;





    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            ufoClone = Instantiate( ufoClone, spawnPoint.position, spawnPoint.rotation);
            //ufoClone = Instantiate(ufo, new Vector3( transform.rotation) as GameObject;
            Timer = 2f;
        }
    }
}
		

