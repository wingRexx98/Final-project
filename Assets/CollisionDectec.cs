using UnityEngine;

public class CollisionDectec : MonoBehaviour
{
    public float colisionJumpHeght = 5f;
    GameManager manager;
    private Animator anim;
    private CharacterController controller;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Deadly")
        {
            Debug.Log("Player touch deadly");
            DeadlyCollision(collision);
        }
        if (collision.tag == "Enemy")
        {
            EnemyCollision(collision);
        }
        if(collision.tag == "Item")
        {
            ItemCollision(collision);
        }
        if(collision.name == "house")
        {
            houseCollision();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "moving platform")
        {
            transform.parent = collision.transform;//making the character the child of the platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "moving platform")
        {
            transform.parent = null;//return the player back to normal
        }
    }

    void EnemyCollision(Collider2D collision)
    {
        if (transform.position.y > collision.transform.position.y)
        {
            Debug.Log("Enemy is dead");
            EnemiesMovement enemy = collision.GetComponent<EnemiesMovement>();
            enemy.Death();
            rb.velocity = new Vector2(transform.localScale.x, colisionJumpHeght);
            ScoreManager.AddPoints(100);
        }
        if (transform.position.y <= collision.transform.position.y)
        {
            Debug.Log("Player is dead");
            manager.Restart();
            anim.SetBool("isDead", true);
            DisableController();
            DisableGravity();
            LivesManager.loseLife();
        }
    }

    void ItemCollision(Collider2D collision)
    {
        ItemCollision item = collision.GetComponent<ItemCollision>();
        item.Collect();
    }

    void DeadlyCollision(Collider2D collision)
    {
        //the player can still move eventhough they have died due to the blend 
        //tree not being able to transiotion from jum and fall to death
        //this is due to not being familiar with working with blend tree
        anim.SetBool("isDead", true);
        controller.runSpeed = 0f;
        controller.jumpForce = 0f;
        LivesManager.loseLife();
        manager.Restart();//lose 2 lives due to 2 colliders, fixed by adding poly collider and diactivating box and circle collider
    }

    void houseCollision()
    {
        manager.CompleteLevel();
    }


    void DisableController()
    {
        controller.enabled = false;
    }

    void DisableGravity()
    {
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Static;
    }

}
