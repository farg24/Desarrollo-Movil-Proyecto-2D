using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManagerControl2 : MonoBehaviour
{
    [Header("UI Text Variables")]
    public Text textTouchPhase;/* textFirstPress, textSecondPress, textNormalized;*/

    [Header("Swipe Variables")]
    public Vector2 firstPressPos, secondPressPos;
    private Vector2 _currentSwipe;

    private Animator animator;
    public GameObject PrefabBullet;
    Vector3 direction;
    private float LastShoot;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstPressPos = new Vector2(touch.position.x, touch.position.y);
                    //textFirstPress.text = "X: " + touch.position.x + " Y: " + touch.position.y;
                    break;

                case TouchPhase.Ended:
                    secondPressPos = new Vector2(touch.position.x, touch.position.y);
                    //textSecondPress.text = "X: " + touch.position.x + " Y: " + touch.position.y;
                    _currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                    _currentSwipe.Normalize();

                    //textNormalized.text = "X: " + _currentSwipe.x + " ,Y: " + _currentSwipe.y;
                    if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                        textTouchPhase.text = "UP SWIPE";

                    else if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                        textTouchPhase.text = "DOWN SWIPE";

                    else if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        transform.localScale = new Vector3(-3.0f, 3.0f, 3.0f);
                        animator.SetBool("Shooting", true);
                        direction = Vector2.left;
                        textTouchPhase.text = "LEFT SWIPE";
                    }

                    else if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f && Time.time > LastShoot + 0.25f)
                    {
                        transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                        animator.SetBool("Shooting", true);
                        direction = Vector2.right;
                        Shoot();
                        LastShoot = Time.time;
                        textTouchPhase.text = "RIGHT SWIPE";
                    }

                    else
                    {
                        animator.SetBool("Shooting", false);
                        textTouchPhase.text = "NOTHING";
                    }
                        

                    break;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(PrefabBullet, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemyigo Derecha")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
}
