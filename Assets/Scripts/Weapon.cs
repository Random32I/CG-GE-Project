using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    bool hurtPlayer;
    float timeSpawned;

    // Start is called before the first frame update
    void Start()
    {
        timeSpawned = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSpawned > 1 && timeSpawned + 3 <= Time.timeSinceLevelLoad)
        {
            Destroy(gameObject);
        }
    }

    public void Attack(int damage, bool hurtPlayer, Vector3 velocity, Vector3 startPos)
    {
        GameObject newBullet = Instantiate(gameObject);
        newBullet.name = "Arrow";
        newBullet.transform.position = startPos;
        newBullet.GetComponent<Rigidbody>().velocity = velocity;
        newBullet.GetComponent<Weapon>().hurtPlayer = hurtPlayer;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Enemy" && hurtPlayer == false)
        {
            Destroy(gameObject);
        }
        else if (collision.name == "Player" && hurtPlayer == true)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
