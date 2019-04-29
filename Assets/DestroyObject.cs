using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float waitTime;

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;//reducing the time
        if(waitTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
