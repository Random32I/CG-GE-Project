using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool mad;
    [SerializeField] GameManager game;
    [SerializeField] int health;
    int enemyID;
    float exp;

    // Start is called before the first frame update
    void Start()
    {
        game.SubscribeToAggro(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InitEnemy(int newHealth, int ID, float newExp, Vector3 startPos)
    {
        health = newHealth;
        enemyID = ID;
        exp = newExp;
        transform.position = startPos;
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

    public int GetID()
    {
        return enemyID;
    }

    public bool GetMad()
    {
        return mad;
    }

    public float GetExp()
    {
        return exp;
    }
}
