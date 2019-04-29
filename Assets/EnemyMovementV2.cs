using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementV2 : MonoBehaviour
{
    public GameObject enemy;
    EnemiesMovement flip;
    public float speed = 1f;
    private Transform currentPos;
    public Transform[] movePos;
    public int pointSelect = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = movePos[pointSelect];
        flip = FindObjectOfType<EnemiesMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //move the platform to the current point position
        if (enemy != null)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, currentPos.position, speed * Time.deltaTime);
            if (enemy.transform.position == currentPos.position)
            {
                pointSelect++;
                if (pointSelect == movePos.Length)
                {
                    pointSelect = 0;//move back to start point
                }
                currentPos = movePos[pointSelect];
                Flip();
            }
        }
        else
        {
            Remove();
        }
    }
    public void Flip()
    {
        Vector3 scale = enemy.transform.localScale;
        scale.x *= -1;
        enemy.transform.localScale = scale;
    }
    public void Remove()
    {
        Destroy(gameObject);
    }
}
