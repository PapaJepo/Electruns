using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

    public bool powered;

	void Start () {
        powered = false;
	}
	
	
	void Update ()
    {
        print(powered);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wire")
        {
            //print("WirePowered");
            GameObject wire = GameObject.Find("Wire");
            Wire P = wire.GetComponent<Wire>();
            if(P.powered == true)
            {
                powered = P.powered;
            }
           
            
        }
    }
}
