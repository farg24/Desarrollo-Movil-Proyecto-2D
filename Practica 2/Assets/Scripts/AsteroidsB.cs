using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsB : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x * -2)
        {
            Debug.Log(screenBounds);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Piso")
        {
            Destroy(this.gameObject);
        }
    }
}
