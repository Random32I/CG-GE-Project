using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameManager game;
    [SerializeField] int itemID;
    public bool usedItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemInit(int ID, Mesh model, Material mat, Vector3 startPos, Vector3 scale)
    {
        itemID = ID;
        GetComponent<MeshFilter>().mesh = model;
        GetComponent<MeshRenderer>().material = mat;
        transform.position = startPos;
        transform.localScale = scale;
        gameObject.SetActive(true);
        usedItem = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            game.PickUpItem(itemID);
            gameObject.SetActive(false);
            usedItem = false;
        }
    }
}
