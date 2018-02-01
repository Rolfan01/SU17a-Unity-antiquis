using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer playerSprite;
    public float moveSpeed;
    public bool isFacingRight;
    Animator animator;
    public bool moving;
    float walking = 1f;
    float notWalking = 0f;

    public int Health = 5;
    public int maxHealth = 5;

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isFacingRight = true;
        moving = false;

        Health = maxHealth;
    }

    void Update()
    {
        if (!moving)
        {
            animator.SetFloat ("speedPercent", notWalking);
        }
        if (moving)
        {
            animator.SetFloat("speedPercent", walking);
        }

        if (Input.GetAxisRaw("Horizontal") > 0.5f )
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            isFacingRight = true;
            moving = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            isFacingRight = false;
            moving = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0f)
        {
            moving = false;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f)
        {
            transform.Translate (new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,  0f));
          
        }

        if (isFacingRight)
        {
            playerSprite.flipX = false;
        }
        if (!isFacingRight)
        {
            playerSprite.flipX = true;
        }

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
        if (Health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }



    }

    public void Damage(int dmg)
    {
        Health -= dmg;
    }
}
