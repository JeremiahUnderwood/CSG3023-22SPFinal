/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    [Header("General Settings")]
    public int numberOfBalls;
    public int score;                //assumeed score cannot be a decimal number
    [HideInInspector] public Rigidbody rb;             //reference to rigid body
    [HideInInspector] public AudioSource audioSource;
    public GameObject paddle;         //reference to paddle, set in inspector
    public bool isInPlay;


    [Header("Ball Settings")]
    public Text ballTxt;               //references to text, set in inspector
    public Text scoreTxt;
    public Vector3 initialForce;
    public float speed;                //to actually make the game interesting, I made the ball start moving diagonanally





    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        //set variables
        rb = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();

    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        //set UI
        ballTxt.text = "Balls Left: " + numberOfBalls.ToString();
        scoreTxt.text = "Score: " + score.ToString();

        if (!isInPlay)
        {
            //set new position (might change later) to match paddle
            Vector3 newPos = transform.position;
            newPos.x = paddle.transform.position.x;
            this.transform.position = newPos;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isInPlay = true;
                Move();
            }
        }
    }//end Update()


    private void LateUpdate()
    {
        if (isInPlay) {
            rb.velocity = rb.velocity.normalized * speed;  //keeps speed constant
        }
    }//end LateUpdate()


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()


    public void Move()
    {
        rb.AddForce(initialForce);
    }//end move

    private void OnCollisionEnter(Collision collision)      //when ball collides with an object
    {
        audioSource.Play();          //play audio
        if (collision.gameObject.tag == "Brick")            //if it was a brick, destroy the brick and increase score
        {
            score += 100;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OutBounds")
        {
            numberOfBalls -= 1;
            if (numberOfBalls > 0)
            {
                Invoke("SetStartingPos", 2f);
            }
        }
    }

}
