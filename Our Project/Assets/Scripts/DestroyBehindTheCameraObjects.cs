using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehindTheCameraObjects : MonoBehaviour
{
    private GameObject player;
    private float destroyOffset = 20.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.z < 0)
        {
            if (transform.position.z - player.transform.position.z > destroyOffset)
            {
                Destroy(gameObject);
            }
        }
    
    }
}
