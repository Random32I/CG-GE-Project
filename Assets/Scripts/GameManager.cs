using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    //Dirty Flags
    bool healthDirty = true;
    bool expDirty = true;
    bool arrowsDirty = true;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthDirty)
        {
            healthText.text = $"Health: {health}/{maxHealth}";
            healthDirty = false;
        }
        if (expDirty)
        {
            expText.text = $"Exp: {exp}";
            expDirty = false;
        }
        if (arrowsDirty)
        {
            arrowsText.text = $"Arrows: {inventoryAmount[1]}";
            arrowsDirty = false;
        }
    }

    public int GetNumberOfItemByID(int ID)
    {
        return inventoryAmount[ID];
    }

    public void RemoveItemFromInventory(int ID)
    {
        if (ID == 1) arrowsDirty = true;
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
        healthDirty = true;
        if (health > 0)
        {
            health--;
            switch (Random.Range(0, 10))
            {
                case 9:
                    spawner.SpawnHeart();
                    break;
            }
        }
    }

    public void PickUpItem(int ID)
    {
        inventoryAmount[ID]++;
        if (ID == 0) IncreaseHealth();
        if (ID == 1) arrowsDirty = true;
    }

    public void IncreaseHealth()
    {
        healthDirty = true;
        if (health < maxHealth) health++;
    }

    public void SetMaxHealth(int newHealth)
    {
        maxHealth = newHealth;
        healthDirty = true;
    }

    public void IncreaseExp(float amount)
    {
        expDirty = true;
        exp += amount;
    }
}
