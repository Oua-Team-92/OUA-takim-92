using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject placeHolder;

    // Start is called before the first frame update
    public void PlayGame()
    {
        //user cannot start the game until enter the his/her name
        if (string.IsNullOrEmpty(inputField.GetComponent<TMP_InputField>().text))
        {
            placeHolder.GetComponent<Animator>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
