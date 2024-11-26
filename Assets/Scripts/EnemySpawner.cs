using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject instantiableBun;
    [SerializeField] GameObject instantiableWizard;
    GameObject[] enemies = new GameObject[30];
    int enemyIndex;
    int activeEnemies;
    int maxEnemies = 15;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            if (i < 15) enemies[i] = Instantiate(instantiableBun);
            else if (i >= 15) enemies[i] = Instantiate(instantiableWizard);
            enemies[i].name = "Enemy";
            enemies[i].transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeEnemies < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int enemyID;
        if (Random.Range(0, 2) == 1) enemyID = Random.Range(0, 2); else enemyID = 0;

        enemies[enemyIndex + enemyID * 15].GetComponent<Enemy>().InitEnemy(Random.Range(1, 4), enemyID, Random.Range(0, 10), new Vector3(Random.Range(-44f, 44f), 1.5f + enemyID * 0.6f, Random.Range(-43f,44f)));
        enemies[enemyIndex + enemyID * 15].SetActive(true);
        enemyIndex++;
        if (enemyIndex == 15) enemyIndex = 0;
        activeEnemies++;
    }

    public void SetMaxEnemies(int newAmount)
    {
        maxEnemies = newAmount;
    }
}
