using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform BoundaryPositionLeft;
    public Transform BoundaryPositionRight;
    Transform transform;
    Vector3 touchPosition;
    BoxCollider boxCollider;
    float screenWidth;

    float changePositionValue= 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider>();
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            MovePlayerToPosition(new Vector3(transform.position.x + changePositionValue, transform.position.y, transform.position.z));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayerToPosition(new Vector3(transform.position.x - changePositionValue, transform.position.y, transform.position.z));
        }

        //solution 1 TO-DO change for draging object
        while (i < Input.touchCount)
        {
            if(Input.GetTouch(i).position.x > screenWidth / 2) {
                MovePlayerToPosition(new Vector3(transform.position.x - changePositionValue, transform.position.y, transform.position.z));
            }
            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                MovePlayerToPosition(new Vector3(transform.position.x + changePositionValue, transform.position.y, transform.position.z));
            }
            ++i;
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
