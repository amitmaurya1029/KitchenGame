using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private int counter = 0;

    void Start()
    {
        GenerateButtons();

    }

    private void GenerateButtons()
    {
        for (int i = 0; i < 10; i++)
        {
            Button instanciateButton = GameObject.Instantiate(button,transform.GetChild(0)).GetComponent<Button>();
            instanciateButton.onClick.AddListener(() => {ButtonCount(); ButtonInfo($"amit + {counter}");});


        }
    }


    private void ButtonCount()
    {
        Debug.Log($"button count : {counter += 1}");
    }
    
    private void ButtonInfo(string info)
    {
        Debug.Log($"button info : {info}");    
    }
}
