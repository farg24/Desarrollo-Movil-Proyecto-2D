using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TouchManagerControl : MonoBehaviour
{
    public float speed;
    [Header("UI Text Variables")]
    public Text textVidas;
    public Text textPuntos;

    private Vector2 firstPressPos, secondPressPos;
    private Vector2 _currentSwipe;
    public int VidasRestantes = 5;
    public int PuntosRestantes = 0;
    public GameObject PantallaPerdida;
    public GameObject CreadorAsteroides;
    public GameObject CreadorPuntos;
    public Rigidbody2D rig;
    int i = 0;
    public float jumpSpeed = 5;

    private void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        if (VidasRestantes != 0)
        {
            if (i == 0)
            {
                Touch();
            }

            else if (i == 1)
            {
                Gyro();
            }
        }

        Debug.Log(i);
    }
    public void Eleccionboton()
    {
            if(i == 0)
            {
                i += 1;
            }

            else if (i == 1)
            {
                i -= 1;
            }
     }


    private void Gyro()
    {
        if(Mathf.Abs(Input.acceleration.y) > 0.05f)
        {
            rig.gravityScale = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Input.acceleration.y * Time.deltaTime, transform.position.z);
        }
    }

    private void Touch()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstPressPos = new Vector2(touch.position.x, touch.position.y);
                    break;

                case TouchPhase.Ended:
                    secondPressPos = new Vector2(touch.position.x, touch.position.y);
                    _currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                    _currentSwipe.Normalize();

                    if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        rig.gravityScale = -1;
                        rig.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                    }

                    else if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        rig.gravityScale = 1;
                        Physics2D.gravity = new Vector2(0, -9.8f);
                    }


                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid" && VidasRestantes > 0)
        {
            VidasRestantes -= 1;
            textVidas.text = "VIDAS: " + VidasRestantes;
            Destroy(other.gameObject);

            if (VidasRestantes <= 0)
            {
                Destroy(CreadorAsteroides);
                PantallaPerdida.SetActive(true);
            }
        }

        if (other.gameObject.tag == "Puntos")
        {
            PuntosRestantes += 1;
            textPuntos.text = "PUNTOS: " + PuntosRestantes;
            Destroy(other.gameObject);

            if (VidasRestantes <= 0)
            {
                Destroy(CreadorPuntos);
            }
        }
    }
}
