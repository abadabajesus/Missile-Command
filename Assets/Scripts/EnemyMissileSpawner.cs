using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float Ypadding = 0.5f;
    public float minX, maxX;

    public int missilesToSpawn = 10;
    public float delayBetweenMissiles = .5f;

    float yValue;
    // Start is called before the first frame update
    void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;

        float randomX = Random.Range(minX, maxX);
        yValue = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRound()
    {
        StartCoroutine(SpawnMissiles());
    }

    public IEnumerator SpawnMissiles()
    {
        while (missilesToSpawn > 0)
        {
            float randomX = Random.Range(minX, maxX);
            float yValue = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
            Instantiate(missilePrefab, new Vector3(randomX, yValue + Ypadding, 0), Quaternion.identity);

            missilesToSpawn--;
        }
        yield return new WaitForSeconds(delayBetweenMissiles);
    }

    }
