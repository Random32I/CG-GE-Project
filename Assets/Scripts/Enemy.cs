using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool mad;
    [SerializeField] GameManager game;
    int health;
    int enemyID;

    // Start is called before the first frame update
    void Start()
    {
        game.SubscribeToAggro(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Aggravate()
    {
        mad = true;
    }

    public void DoDamage(int damage)
    {
        health -= damage;
        game.NotifyAggro();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
