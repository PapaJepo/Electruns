using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Renderer DoorSprite;
    private float CONcounter, INcounter;
	void Start ()
    {
        DoorSprite = GetComponent<Renderer>();
	}
	
	
	void Update ()
    {
		if((CONcounter > 0) &&(INcounter > 0))
        {
            DoorSprite.enabled = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Conductor")
        {
            Debug.Log("Enter");
            CONcounter++;
        }
        if (collision.tag == "Insulator")
        {
            Debug.Log("Enter");
            INcounter++;
        }
    }
  
}
