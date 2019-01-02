using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    private float speedMultiplier;

    public int livesNumber;
    public int gemCounter;

    public Text textGems;

    private bool onGround;

    public AudioSource jumpSound;
    public AudioSource grassSound;


    // Start is called before the first frame update
    void Start()
    {

        textGems.text = gemCounter.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "UI")
        {
        UILife();
        }
        if (gameObject.tag == "Player")
        {
            Movement();
            Jump();

        }

    }

    void Movement()
    {

        //Sprint

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speedMultiplier = 2;
        }
        else
        {
            speedMultiplier = 1;
        }

        //Left and Right Arrows for Regular Movement

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        float xMovement = Input.GetAxis("Horizontal");
        
        rb2d.velocity = new Vector2(xMovement*moveSpeed*speedMultiplier, rb2d.velocity.y);
        


        // Flip Sprite
        
            if (xMovement > 0)
            {
            GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (xMovement < 0)
            {
            GetComponent<SpriteRenderer>().flipX = true;
            }

        //Walking Sprite Animation

        if (xMovement != 0)
        {
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }

        //Sound

        if (xMovement != 0 && !grassSound.isPlaying)
        {
            grassSound.Play();
        }


    }

    void Jump()
    {

        //Spacebar to Jump

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
 
        //Jumping Sprite Animation


    }

    //Lives Animation

    void UILife()
    {

            GetComponent<Animator>().SetInteger("LifeCounter", livesNumber);
        
    }

    //Colliders 

    void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.CompareTag("Platforms"))
        {
            //
        }


        if (collision2D.gameObject.CompareTag("Gem"))
        {
            //
        }

    }

    void OnCollisionExit2D(Collision2D collision2D)

    {
    
    }
}
