using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] Renderer coinRenderer;
    [SerializeField] BoxCollider2D coinCollider;
    [SerializeField] AudioSource collectCoin;
    [SerializeField] ScoreManager scoreManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinRenderer.enabled = false;
            coinCollider.enabled = false;
            collectCoin.enabled = true;
            //Debug.Log("collect the coin");
            scoreManager.CollectingCoin();
        }
    }
}
