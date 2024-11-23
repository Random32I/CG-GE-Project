using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] List<int> inventory; //stores item ids
    [SerializeField] int enemiesInLevel;
    [SerializeField] int enemiesKilled;
    [SerializeField] float exp;
    [SerializeField] List<Enemy> enemies;

    [Header("UI Objects")]
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI expText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"Health: {health}/{maxHealth}";
        expText.text = $"Exp: {exp}";
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

    public void PickUpItem(int ID)
    {
        inventory.Add(ID);
    }

    public void IncreaseHealth()
    {
        maxHealth++;
        health++;
    }

    public void IncreaseExp(float amount)
    {
        exp += amount;
    }
}
