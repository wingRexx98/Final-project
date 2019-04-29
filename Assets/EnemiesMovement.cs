using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    private Animator anim;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Physics.IgnoreLayerCollision(9, 10);
    }

    public void Death()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("Enemy dead animation");
        Destroy(gameObject);
    }
}
