using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPoints : MonoBehaviour
{
    public GameObject PointsPrefab;
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }

    void SpawnEnemy()
    {
        GameObject a = Instantiate(PointsPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}