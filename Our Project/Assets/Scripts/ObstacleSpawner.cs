using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacleModels;

    public float Offset = 10f;
    public int ObstacleStartCounter;
    public int ObstacleDefaultCounter;

    public int destoryTimer; 


    private float[] places = {7.6f,3f,-1.61f};

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<ObstacleStartCounter;i++){
            GameObject obstacleItem = Instantiate(randomObstacle(), new Vector3(randomPlace(), -5.34f, Offset), Quaternion.identity);
            Offset += -15f;
            Destroy(obstacleItem,destoryTimer);
        }
    }

    public float randomPlace(){
        return places[Random.Range(0,3)];
    }

    public GameObject randomObstacle(){
        return obstacleModels.OrderBy( s => Random.Range(0,(obstacleModels.Count+1))).First();
    }
           
    public void spawnMoreObstacle(){
        for(int i = 0;i<ObstacleDefaultCounter;i++){
            GameObject obstacleItem = Instantiate(randomObstacle(), new Vector3(randomPlace(), -5.34f, Offset), Quaternion.identity);
            Offset += -15f;
            Destroy(obstacleItem,destoryTimer);
        }
    }

    
}
