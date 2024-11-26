using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] Rigidbody rig;
    [SerializeField] float speed = 4;
    [SerializeField] GameObject player;
    [SerializeField] Weapon mage;
    Enemy enemy;
    int AIType;
    [SerializeField] Vector3 target;

    float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        AIType = enemy.GetID();
        target = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {

        if (target == new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)))
        {
            if (!enemy.GetMad())
            {
                target = new Vector3(Mathf.Round(Random.Range(-44f, 44f)), transform.position.y, Mathf.Round(Random.Range(-43f, 44f)));
            }
            else
            {
                switch (AIType)
                {
                    case 0:
                        target = player.transform.position;
                        break;
                    case 1:
                        if (Time.timeSinceLevelLoad - timestamp >= 1)
                        {
                            mage.AttackArrow(1, true, (player.transform.position - transform.position).normalized * 10, transform.position);
                            timestamp = Time.timeSinceLevelLoad;
                        }
                        break;
                }
            }
        }
        else
        {
            if (enemy.GetMad() && AIType == 0)
            {
                target = player.transform.position;
            }
            rig.velocity = (target - transform.position).normalized * speed;
        }
    }

    public void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }
}
