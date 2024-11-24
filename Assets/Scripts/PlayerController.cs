using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rig;
    [SerializeField] float speed;
    [SerializeField] Weapon bullet;
    [SerializeField] ItemSpawner spawner;
    [SerializeField] GameManager game;
    [SerializeField] GameObject sword;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rig.velocity.y, Input.GetAxis("Vertical") * speed);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (game.GetNumberOfItemByID(1) > 0)
            {
                bullet.AttackArrow(1, false, (transform.right * -1).normalized * 10, transform.position);
                game.RemoveItemFromInventory(1);
            }
        }
        if (game.GetNumberOfItemByID(2) == 1)
        {
            sword.SetActive(Input.GetMouseButton(0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bun")
        {
            game.DoDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
        {
            other.GetComponent<Enemy>().DoDamage(1);
        }
    }

}
