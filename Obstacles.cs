using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 3f;
    public float spawnDelay = 3f;
    public float minY = -3f;
    public float maxY = 3f;
    public float minX = -8f;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Vector3 pos = new Vector3(8f, Random.Range(minY, maxY), 0f);
            GameObject obstacle = Instantiate(gameObject, pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}