using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject City;
    public float Offset = -189.7f;

    void OnTriggerEnter()
    {
        Debug.Log("hayhay");
        Instantiate(City, new Vector3(0, 5.6f, Offset), Quaternion.identity);
        Offset +=-189.7f; 

    }
}
