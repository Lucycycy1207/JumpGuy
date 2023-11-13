using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRb;

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

    public void GoLeft()
    {
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("hit the ground");
            PlayerAnim.SetBool("isGrounded", true);
        }
        else if (other.gameObject.CompareTag("Obstacle")){
            Debug.Log("can't jump");
            PlayerAnim.ResetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("can't jump");
            canJump = false;
            PlayerAnim.ResetTrigger("Jump");
        }
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
