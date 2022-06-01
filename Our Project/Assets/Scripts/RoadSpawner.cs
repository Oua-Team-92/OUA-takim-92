using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> cities;
    public GameObject city;
    public float Offset = 0; 
    public int CityCount;
    
    // Start is called before the first frame update
    void Start()
    {
        //init object
        for(int i = 0;i<CityCount;i++){
            GameObject cityObject = Instantiate(city, new Vector3(0, 0, Offset), Quaternion.identity);
            cities.Add(cityObject);
            Offset +=-189.7f; 
        }
    }


    public void MoveRoad()
    {
        GameObject newCity = cities[0];
        cities.RemoveAt(0);
        newCity.transform.position = new Vector3(0,0,Offset);
        Offset +=-189.7f;
        cities.Add(newCity);
    }
}
