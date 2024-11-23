using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] int[] inventoryAmount = new int[3]; //stores item amounts (with indexes of the item ids)
    [SerializeField] int enemiesInLevel;
    [SerializeField] int enemiesKilled;
    [SerializeField] float exp;
    [SerializeField] List<Enemy> enemies;

    [Header("UI Objects")]
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI arrowsText;

    [Header("Spawner")]
    [SerializeField] ItemSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"Health: {health}/{maxHealth}";
        expText.text = $"Exp: {exp}";
        arrowsText.text = $"Arrows: {inventoryAmount[1]}";
    }

    public int GetNumberOfItemByID(int ID)
    {
        return inventoryAmount[ID];
    }

    public void RemoveItemFromInventory(int ID)
    {
        if (inventoryAmount[ID] > 0)
        {
            inventoryAmount[ID]--;
        }
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

    public void DoDamage()
    {
        health--;
        spawner.SpawnHeart();
    }

    public void PickUpItem(int ID)
    {
        inventoryAmount[ID]++;
        if (ID == 0) IncreaseHealth();
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
