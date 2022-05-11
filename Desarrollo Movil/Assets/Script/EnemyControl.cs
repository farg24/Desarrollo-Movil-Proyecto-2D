using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public float SpeedX;
    private Rigidbody2D _rbEnemy;

    private void Awake()
    {
        _rbEnemy = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rbEnemy.position = new Vector2(_rbEnemy.position.x + SpeedX, _rbEnemy.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
