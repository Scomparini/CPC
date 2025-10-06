using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float minTime;
    public float maxTime;
    public Vector2[] lanes;

    // Start is called before the first frame update
    void Start()
    {
        // síntaxe padrão da coroutine
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));

        int randomLane = Random.Range(0, 3);

        // elemento 1 (objeto a ser criado); elemento 2 (posição a ser criado); elemento 3 (rotação a ser criado)
        // Quaternio é a rotação, identity pega a sua própria rotação
        Instantiate(spawnObject, lanes[randomLane], Quaternion.identity);

        // inicia o loop da coroutine
        StartCoroutine(Spawn());
    }
}
