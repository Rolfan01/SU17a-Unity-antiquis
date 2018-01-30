using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInTerritory : MonoBehaviour
{



    public BoxCollider2D territory;
    GameObject player;
    bool playerInTerritory;

    public GameObject enemy;
    Enemy basicEnemy;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        basicEnemy = enemy.GetComponent<Enemy>();
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory = true)
        {
            basicEnemy.MoveToPlayer();

        }
        if (playerInTerritory = false)
        {
            basicEnemy.Rest();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject == player)
        {
            playerInTerritory = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = false;
        }
    }

}
