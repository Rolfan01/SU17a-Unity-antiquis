using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public GameObject Enemy;
    private Vector3 Player;
    private Vector2 Playerdirection;
    private float Xdif;
    private float Ydif;
    public float speed;
    Animator animator;
    public bool isWalking = true;
    public float walkingSpeed = 1f;
    SpriteRenderer enemySprite;
    public bool isFacingRight;
    private Vector3 enemyPosition;
    PlayerController playerController;
    
    // Update is called once per frame



    private void Start()
    {
        animator = GetComponent<Animator>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
       playerController = Player.GetComponent<PlayerController>();
       

    }

    void Update()
    {
        Enemy = GameObject.Find("Enemy");
        Player = GameObject.Find("Player").transform.position;
        //Xdif = Player.x - transform.position.x;
        //Ydif = Player.y - transform.position.y;

        //Playerdirection = new Vector2(Xdif, Ydif);
        //transform.Translate(Playerdirection * speed);

        transform.position = Vector2.Lerp(transform.position, Player, Time.deltaTime * speed);

      /*  if (Player.x > Enemy.x)
        {
            enemySprite.flipX = true;
        }
        else if (Player.x < enemyPosition.x)
        {
            enemySprite.flipX = false;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
           
           
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
        }
    }
}
