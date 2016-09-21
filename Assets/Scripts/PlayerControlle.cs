using UnityEngine;
using System.Collections;

public class PlayerControlle : MonoBehaviour {


    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool walled;

    private bool Jumped;
    private bool doubleJumped;
    private bool Climbed;

    public AudioClip Sjump;
    public AudioClip Djump;
    AudioSource Audio;



    // Use this for initialization
    void Start () {
        Audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()   {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        walled = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
    }
	
	// Update is called once per frame
	void Update () {

        if (grounded)
        {
            doubleJumped = false;
        }

        if (walled)
        {
            Climbed = false;
            Jumped = true;
            print("walled");
        }

        



        if (Input.GetKeyDown (KeyCode.UpArrow) && grounded)
        {
            Jump();
            Audio.clip = Sjump;
            Audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && walled)
        {
            Jump();
            Climbed = true;
            print("Climbed");
            Audio.clip = Sjump;
            Audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && walled && Climbed)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !doubleJumped && !grounded)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
            doubleJumped = true;
            Audio.clip = Djump;
            Audio.Play();
        }

        //Wall ifs
        

        if (Input.GetKey (KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey (KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed + 2, GetComponent<Rigidbody2D>().velocity.y);
        }

        




    }

    

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , jumpHeight);
    }
}
