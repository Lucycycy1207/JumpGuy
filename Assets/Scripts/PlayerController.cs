using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Player player;
    

    // Start is called before the first frame update


    private void Start()
    {
        
    }
    public void UpdatePlayer()
    {



    }
    private void Update()
    {
        MotionUpdate();


    }

    private void MotionUpdate()
    {
        //stop going left/right
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            //Debug.Log("stop");
            player.Stop();
        }


        if (player.AnimInfo("isGrounded"))
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.jump();

            }

        }
        //go left
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("go left");
            player.GoLeft();
        }

        //go right
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("go right");
            player.GoRight();
        }
    }
}
