using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform TargetToFollow;

    public float heigth;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(TargetToFollow.position.x, TargetToFollow.position.y + heigth, TargetToFollow.position.z + distance);
        transform.LookAt(TargetToFollow);
    }
}
