using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //Upward force of the "flap."
    public float upForce;
    //Has the player collided with a wall?
    private bool isDead = false;
    //Rference to the Animator component.
    private Animator anim;
    //Hold a reference to the Rigidbody2D component of the bird.
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        //Get and sstore a r3eference tot the RigidBody2D attachedd to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't allow if the bird has died
        if (isDead == false)
        {
            //Look for input to trigger a "flap."
            if (Input.GetMouseButtonDown(0))
            {
                //...tell the animator about it and then...
                anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
                // new Vector2(rbr2.velocity.x, 0);
                //...giving the bird some upward force. 
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }
    void OnColisionEnter2D(Collision2D other)
    {
        //Zero out the bird's velocity
        rb2d.velocity = Vector2.zero;
        //If the bird collides with something set it to dead...
        isDead = true;
        //...tell the Animator about it...
        anim.SetTrigger("Die");
        //...and tell the game control about it.
        GameControl.instance.BirdDied();
    }
}
