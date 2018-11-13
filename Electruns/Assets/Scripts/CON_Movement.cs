using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CON_Movement : MonoBehaviour {

    private float speed = 3f;
    private float CharSwap = -1;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool Swap = Input.GetKey(KeyCode.Space);
        if(Swap)
        {
            CharSwap = CharSwap * -1;

        }

        if (CharSwap < 0)
        {
            var x = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            var z = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(z, 0, 0);
            transform.Translate(0, x, 0);
        }
    }
}
