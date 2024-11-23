using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject instantiableItem;
    [SerializeField] Material[] materials = new Material[3];
    [SerializeField] Mesh[] meshes = new Mesh[3];

    [SerializeField] GameManager game;
    [SerializeField] PlayerController weapon;

    GameObject[] items = new GameObject[3];
    int itemIndex;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            items[i] = Instantiate(instantiableItem);
            items[i].transform.parent = transform;
        }
        SpawnHeart();
        SpawnArrow();
        SpawnSword();
    }

    // Update is called once per frame
    void Update()
    {
        //if (game)
    }


    public void SpawnHeart()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!items[itemIndex].GetComponent<Item>().usedItem)
            {
                items[itemIndex].GetComponent<Item>().ItemInit(0, meshes[0], materials[0], new Vector3(-15, 2, -1), Vector3.one * 100);
                itemIndex++;
                if (itemIndex == 3) itemIndex = 0;
                break;
            }
            itemIndex++;
            if (itemIndex == 3) itemIndex = 0;
        }
    }
    public void SpawnArrow()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!items[itemIndex].GetComponent<Item>().usedItem)
            {
                items[itemIndex].GetComponent<Item>().ItemInit(1, meshes[1], materials[1], new Vector3(-3, 2, -30), Vector3.one * 15);
                itemIndex++;
                if (itemIndex == 3) itemIndex = 0;
                break;
            }
            itemIndex++;
            if (itemIndex == 3) itemIndex = 0;
        }
    }
    void SpawnSword()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!items[itemIndex].GetComponent<Item>().usedItem)
            {
                items[itemIndex].GetComponent<Item>().ItemInit(2, meshes[2], materials[2], new Vector3(11, 2, -29),Vector3.one * 20);
                itemIndex++;
                if (itemIndex == 3) itemIndex = 0;
                break;
            }
            itemIndex++;
            if (itemIndex == 3) itemIndex = 0;
        }
    }
}
