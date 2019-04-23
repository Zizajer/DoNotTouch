using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform[] TrackPoints;
    int currentTrackPoint = 1;
    public float MoveSpeed;
    Transform transform;
    Vector3 touchPosition;
    BoxCollider boxCollider;
    float screenWidth;
    private Vector3 startPos;
    private float minSwipeDistX = 35f;

    float changePositionValue= 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        transform.position = TrackPoints[1].position;
        boxCollider = GetComponent<BoxCollider>();
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (currentTrackPoint > 0) {
                currentTrackPoint--;
                transform.position = TrackPoints[currentTrackPoint].position;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentTrackPoint < 2)
            {
                currentTrackPoint++;
                transform.position = TrackPoints[currentTrackPoint].position;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0) //right swipe 
                        {
                            if (currentTrackPoint < 2)
                            {
                                currentTrackPoint++;
                                transform.position = TrackPoints[currentTrackPoint].position;
                            }
                        }
                        else if (swipeValue < 0) //left swipe 
                        {
                            if (currentTrackPoint > 0)
                            {
                                currentTrackPoint--;
                                transform.position = TrackPoints[currentTrackPoint].position;
                            }
                        }
                    }
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    
}
