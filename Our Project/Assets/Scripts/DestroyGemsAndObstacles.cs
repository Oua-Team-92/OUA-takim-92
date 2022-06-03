using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGemsAndObstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("giriyor");

        if (gameObject.CompareTag("Gems") && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Score.score += 10;
            Debug.Log("score  " + Score.score);
        }

        if (gameObject.CompareTag("Cars") && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Score.health -= 20;
            Debug.Log("Health  " + Score.health);
        }
    }
}
