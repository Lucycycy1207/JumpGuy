using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject EndingUI;
    [SerializeField] private GameObject ScoreObject;
    [SerializeField] private GameObject CurrentScoreObject;
    
    public void DeactiveCanvas(GameObject canvasName)
    {
        canvasName.SetActive(false);
    }

    public void ActiveCanvas(GameObject canvasName)
    {
        canvasName.SetActive(true);
    }
    public void Ending()
    {
        ScoreObject.GetComponent<TextMeshProUGUI>().text  = CurrentScoreObject.GetComponent<TextMeshProUGUI>().text;
        EndingUI.SetActive(true);

   
    }

  
}
