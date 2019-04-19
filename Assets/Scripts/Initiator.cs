using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiator : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform ObstacleParent;
    Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        Invoke("SpawnObstacle", Random.Range(2, 10));
    }

    private void SpawnObstacle()
    {
            Instantiate(obstacles[0], transform.position, new Quaternion(-ObstacleParent.rotation.x, 0, 0, 0), ObstacleParent);
            Invoke("SpawnObstacle", Random.Range(2,10));
    }
}
