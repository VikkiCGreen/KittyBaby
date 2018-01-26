using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //reference to rigidbody
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float movementSpeed;

    private bool facingRight;
    

	// Use this for initialization
	void Start ()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        //looks at input axis. set up in input settings in unity
        float horizontal = Input.GetAxis("Horizontal");

        //call movement. without calling function in update, it will never play
        HandleMovement(horizontal);

        Flip(horizontal);
	}

    //player movement
    private void HandleMovement(float horizontal)
    {

        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

    }
    
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            //reference to  player's local scale so we can get the x value to use
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
