using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text helpText;

    private Rigidbody rb;
    private int count;

    // private bool onGround = true;
    private bool doubleJump = true;
    private const int MAX_JUMP =2;
    private int jumpCount =0;

    private AudioSource source;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";

        source = GetComponent<AudioSource>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && (jumpCount < MAX_JUMP))
        {
            
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
            rb.AddForce(jump);
            // Console.WriteLine("Our total {0}", total);
            // onGround = false;
            jumpCount++;
            // Console.WriteLine("Our total");
        }
        
        // if (onGround && Input.GetKeyDown(KeyCode.Space))

        // {
        //     Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
        //     rb.AddForce(jump);

        //     onGround = false;

        // }

        // if (Input.GetKeyDown(KeyCode.Space) && onGround == false)

        // {

        //     Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
        //     rb.AddForce(jump);

        //     doubleJump = false;

        // }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

    }

    void OnCollisionEnter(Collision collision){
        
        // onGround = true;
        // doubleJump = true;
        jumpCount = 0;
            
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();

            // source.Play();
        }


    }



    void SetCountText ()
    {
        helpText.text = "Use arrow keys to play & escape key to quit!!!";
        countText.text = "Count: " + count.ToString ();
        if (count > 12)
        {
            winText.text = "You Win!";
            // source.Play();
        }
    }

    void Update () 
    {
         if(Input.GetKeyDown("escape"))
         {
            Application.Quit();
             
          }
    }
}
