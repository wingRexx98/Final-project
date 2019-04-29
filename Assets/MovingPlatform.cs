using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public float speed = 1f;
    private Transform currentPos;
    public Transform[] movePos;
    public int pointSelect = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = movePos[pointSelect];
    }

    // Update is called once per frame
    void Update()
    {
        //move the platform to the current point position
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPos.position, speed*Time.deltaTime);
        if(platform.transform.position == currentPos.position)
        {
            pointSelect++;
            if(pointSelect == movePos.Length)
            {
                pointSelect = 0;//move back to start point
            }
            currentPos = movePos[pointSelect];
        }
    }
}
