using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*public GameObject enemy;
    float randX;
    Vector2 WhereToSpawn;
    public float spawnRate = 3f;
    float nextSpawn = 0.0f;*/
    [SerializeField]
    private GameObject IzquierdaObjeto;

    [SerializeField]
    private GameObject DerechaObjeto;

    //[SerializeField]
    //private float IzquierdaObjetoIntervalo = Random.Range(1f,3f);

    //[SerializeField]
    //private float DerechaObjetoIntervalo = Random.Range(2f,4f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyA(Random.Range(1f, 5f), IzquierdaObjeto));
        StartCoroutine(spawnEnemyB(Random.Range(1f, 5f), DerechaObjeto));
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.73f, -1.69f);
            WhereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, WhereToSpawn, Quaternion.identity);
        }*/
    }

    private IEnumerator spawnEnemyA(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, -2f), /*Random.Range(-6f, 6)*/ 2.29f, 0), Quaternion.identity);
        StartCoroutine(spawnEnemyA(interval, enemy));
    }

    private IEnumerator spawnEnemyB(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(4.5f, 3.2f), /*Random.Range(-6f, 6)*/ 2.29f, 0), Quaternion.identity);
        StartCoroutine(spawnEnemyB(interval, enemy));
    }
}
