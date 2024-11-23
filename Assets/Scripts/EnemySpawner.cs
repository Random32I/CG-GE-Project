using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject instantiableEnemy;
    GameObject[] enemies = new GameObject[30];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            enemies[i] = Instantiate(instantiableEnemy);
            enemies[i].GetComponent<Enemy>().InitEnemy(Random.Range(1,4), Random.Range(0, 2), Random.Range(0, 10));
            enemies[i].name = "Enemy";
            enemies[i].transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
