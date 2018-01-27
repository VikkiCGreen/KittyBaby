using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //reference to rigidbody
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float movementSpeed;

    private bool sprint;

    private bool facingRight;

    private Animator myAnimator;
    

	// Use this for initialization
	void Start ()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        //looks at input axis. set up in input settings in unity
        float horizontal = Input.GetAxis("Horizontal");

        //call movement. without calling function in update, it will never play
        HandleMovement(horizontal);

        Flip(horizontal);

        ResetValues();
	}

    //player movement
    private void HandleMovement(float horizontal)
    {

        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("sprint"))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }

        //sprint
        if (sprint)
        {
            myAnimator.SetTrigger("sprint");
        }
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));



    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = true;
            movementSpeed = 20;
        }

		if (Input.GetKeyUp(KeyCode.LeftShift)) 
		{
			sprint = false;
			movementSpeed = 10;
		}
        
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

    private void ResetValues()
    {
        sprint = false;
    }
}
