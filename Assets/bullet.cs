using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int bulletDmg;
    private GameObject enemy;
    public int destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("hit!");
            enemy = collider.gameObject;
            enemy.GetComponent<EnemyStats>().TakeDamage(bulletDmg);
            Debug.Log(enemy.GetComponent<EnemyStats>().CheckHealth());
            Destroy(gameObject);
        }

        Destroy(gameObject, destroyTime);
    }


}
