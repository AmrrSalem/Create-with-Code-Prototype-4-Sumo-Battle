using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody enemyRb;
    GameObject player;
    public float speed;
    void Start()
    {

        enemyRb = GetComponent<Rigidbody>(); 
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {



        if (transform.position.y < -10) 
        {
            Destroy(gameObject);
        }
        var direction  = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(direction*speed);
        
    }
}
