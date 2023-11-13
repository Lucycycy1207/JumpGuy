using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetPlayer;


    public Vector3 initalOffset;

    // Start is called before the first frame update
    void Start()
    {
        initalOffset = transform.position - targetPlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initalOffset + targetPlayer.position;
    }
}
