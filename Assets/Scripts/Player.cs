using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform BoundaryPositionLeft;
    public Transform BoundaryPositionRight;
    Transform transform;
    float changePositionValue= 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            MovePlayerToPosition(new Vector3(transform.position.x + changePositionValue, transform.position.y, transform.position.z));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayerToPosition(new Vector3(transform.position.x - changePositionValue, transform.position.y, transform.position.z));
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            MovePlayerToPosition(touchWorldPos);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    public void MovePlayerToPosition(Vector3 position)
    {
        Vector3 clampedPlayerPosition = new Vector3(Mathf.Clamp(position.x, BoundaryPositionRight.position.x,BoundaryPositionLeft.position.x)
                                                                    ,transform.position.y,
                                                                    transform.position.z);

        transform.position = clampedPlayerPosition;
    }
}
