using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] int[] inventory = new int[4]; //stores item ids
    [SerializeField] int enemiesInLevel;
    [SerializeField] int enemiesKilled;
    [SerializeField] float exp;
    [SerializeField] List<Enemy> enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubscribeToAggro(Enemy instance)
    {
        enemies.Add(instance);
    }

    public void NotifyAggro()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Aggravate();
        }
    }
}
