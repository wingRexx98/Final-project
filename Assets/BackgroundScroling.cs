using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroling : MonoBehaviour
{
    public float backgroundSize;
    private Transform cameraPosition;
    private Transform[] layers;
    private float viewZone = 0f;
    private int leftIndex;
    private int rightIndex;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = Camera.main.transform;
        layers = new Transform[transform.childCount];//count the amount of chile in the array
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraPosition.position.x < (layers[leftIndex].position.x + viewZone))
            ScrollLeft();
        if (cameraPosition.position.x > (layers[rightIndex].position.x + viewZone))
            ScrollRight();
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex<0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
