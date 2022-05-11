using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            a += 1;
            Destroy(collision.gameObject);
            Debug.Log("Enemigos: " + a);
            //collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
}
