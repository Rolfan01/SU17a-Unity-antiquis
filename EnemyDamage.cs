using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int damage = 1;
    private PlayerController health;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            health.Damage(1);
        }
    }
}
