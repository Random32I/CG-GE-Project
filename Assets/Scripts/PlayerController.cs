using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rig;
    [SerializeField] float speed;
    [SerializeField] Weapon bullet;


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
            bullet.AttackArrow(1, false, transform.forward * 5, transform.position);
        }
    }

}
