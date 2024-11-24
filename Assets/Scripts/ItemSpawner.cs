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
        }
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
                items[itemIndex].GetComponent<Item>().ItemInit(0, meshes[0], materials[0], transform.position + Vector3.forward * 3 + Vector3.up * 1.5f, Vector3.one * 100);
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
                items[itemIndex].GetComponent<Item>().ItemInit(1, meshes[1], materials[1], transform.position + Vector3.forward * 3 + Vector3.up * 1.5f, Vector3.one * 15);
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
                items[itemIndex].GetComponent<Item>().ItemInit(2, meshes[2], materials[2], transform.position + Vector3.forward * 3 + Vector3.up * 1.5f, Vector3.one * 20);
                itemIndex++;
                if (itemIndex == 3) itemIndex = 0;
                break;
            }
            itemIndex++;
            if (itemIndex == 3) itemIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (game.GetNumberOfItemByID(2) == 0)
            {
                SpawnSword();
            }
            else
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        SpawnHeart();
                        break;
                    case 1:
                        SpawnArrow();
                        break;
                }
            }
        }
    }
}
