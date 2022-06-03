using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log(inputField.GetComponent<TMP_InputField>().text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
