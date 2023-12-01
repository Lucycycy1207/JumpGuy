using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRb;

    [SerializeField] ScoreManager scoreManager;

    private Vector3 startPosition;
    private Quaternion startRotation;

    [SerializeField]
    private float runningSpeed = 2;
    [SerializeField]
    private float jumpSpeed = 300;

    [SerializeField]
    private Animator PlayerAnim;

    private bool canJump = true;

    private void Start()
    {
        

    startPosition = transform.position;
    startRotation = transform.rotation;

    playerRb = GetComponent<Rigidbody2D>();
    
    }

    public float PlayerPosInX()
    {
        return transform.position.x;
    }

    public void GoLeft()
    {
        //Debug.Log("Go left\n");
        if (AnimInfo("isGrounded"))
        {
            PlayerAnim.SetBool("isRunning", true);
        }
        if (transform.rotation.y != 180)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        transform.Translate(runningSpeed * Time.deltaTime, 0, 0);
    }

    
    public void GoRight()
    {
        //Debug.Log("Go right\n");
        if (AnimInfo("isGrounded"))
        {
            PlayerAnim.SetBool("isRunning", true);
        }

        if (transform.rotation.y != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.Translate(runningSpeed * Time.deltaTime, 0, 0);
    }

    public void jump()
    {
        if (canJump)
        {
            Debug.Log("Go jump\n");
            PlayerAnim.SetTrigger("Jump");
            PlayerAnim.SetBool("isGrounded", false);
            PlayerAnim.SetBool("isRunning", false);
            playerRb.AddForce(new Vector2(0, jumpSpeed));
        }
    }

    public void Stop()
    {
        PlayerAnim.SetBool("isRunning", false);
    }


    //input is "isGrounded", "isRunning"....
    //return status of these
    public bool AnimInfo(string input)
    {
        return PlayerAnim.GetBool(input);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("can't jump");
            canJump = false;
            PlayerAnim.ResetTrigger("Jump");
            scoreManager.CollideObstacle();


        }
        if (other.gameObject.CompareTag("platform"))
        {
            Debug.Log("hit the platform");
            PlayerAnim.SetBool("isGrounded", true);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit the ground");
            PlayerAnim.SetBool("isGrounded", true);
        }

        //on platform
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("not touching obstacle anymore");
            canJump = true;
        }
    }

}
