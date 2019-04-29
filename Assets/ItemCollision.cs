using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    public GameObject collisionEffect;

    public int pointToAdd = 100;

    public void Collect()
    {
        //Clone the prefab
        Instantiate(collisionEffect, transform.position, Quaternion.identity);
        Debug.Log("Item collected");

        ScoreManager.AddPoints(pointToAdd);

        Destroy(gameObject);
    }
}
