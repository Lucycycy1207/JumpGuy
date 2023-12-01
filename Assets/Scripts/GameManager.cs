using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private PlayerController playerController;

    [SerializeField] private Player player;

    [SerializeField] private float LoadingPointX;

    [SerializeField] private GameObject scene;
    [SerializeField] private float LoadingScenePoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.PlayerPosInX() > LoadingPointX)
        {
            Debug.Log("Loading new scnee");
            GenerateUI();
            LoadingPointX *= 2;
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GenerateUI()
    {
        float yValue = scene.transform.position.y;
        Instantiate(scene, new Vector2(LoadingScenePoint, yValue), Quaternion.identity);
    }


}
