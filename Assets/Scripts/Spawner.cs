using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float spawnInterval = 2f;
    private Vector3 spawnPos;
    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        Debug.Log(enemyPrefab.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.IsGameOver) return;
        if(!isSpawning) StartCoroutine(spawnCoroutine());
    }

    private IEnumerator spawnCoroutine()
    {
        isSpawning = true;
        yield return new WaitForSeconds(spawnInterval);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        spawnPos.x = Random.Range(-7f, 7f);
        GameObject enemy = Instantiate(enemyPrefab[randomEnemy], spawnPos, transform.rotation);
        isSpawning = false;
        Destroy(enemy, 6);
    }
}
