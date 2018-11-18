using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveScript : MonoBehaviour {

    //Characters on List
    [SerializeField] private List<GameObject> playerSelect;
    [SerializeField] private int count;

    //Current Character rigidbody2D
    Rigidbody2D plRB;

    //Vectors for movement forces
    [SerializeField] Vector2 upDownDirection, leftRightDirection;
    
    //velocity checking vectors
    [SerializeField] Vector2 currentSpeed, maxSpeed, diagonalMaxSpeed;

    private void Start()
    {
        count = 0;
        plRB = playerSelect[count].GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate () {

        plRB = playerSelect[count].GetComponent<Rigidbody2D>();

        //When spacebar is pressed the player controls the next character in the character list
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count += 1;
        }
        if (count >1)
        {
            count = 0;   
        }

        playerControl();
        
    }

    //adding movement forces when horizontal and vertical axis are used 
    void playerControl()
    {
        currentSpeed = plRB.velocity;
        if (Mathf.Abs(currentSpeed.y) < maxSpeed.y && Mathf.Abs(currentSpeed.x) < maxSpeed.x)
        {
            plRB.AddForce(upDownDirection * Input.GetAxis("Vertical"));
            plRB.AddForce(leftRightDirection * Input.GetAxis("Horizontal"));
        }
        
        if (currentSpeed.y > maxSpeed.y || currentSpeed.x > maxSpeed.x )
        {          
            plRB.velocity = new Vector2(maxSpeed.x * Input.GetAxis("Horizontal"), maxSpeed.y * Input.GetAxis("Vertical"));
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            currentSpeed.x = diagonalMaxSpeed.x;
            currentSpeed.y = diagonalMaxSpeed.y;

            plRB.velocity= new Vector2(diagonalMaxSpeed.x * Input.GetAxis("Horizontal"), diagonalMaxSpeed.y * Input.GetAxis("Vertical"));
        }

        diagonalMaxSpeed = new Vector2(maxSpeed.x / 2, maxSpeed.y/2);
    }
    
}




