using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    GameObject[] defenders;
    [SerializeField] private GameObject explosionPrefab;

    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        defenders = GameObject.FindGameObjectsWithTag("Defenders");
        target = defenders[Random.Range(0, defenders.Length)].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Defenders")
        {

            MissileExplode();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Explosions")
        {
            //this add points from enemy destroyed
            FindObjectOfType<GameController>().AddMissileDetroyedScore();

            MissileExplode();
            //Destroy(collision.gameObject);
        }
    }

    //Spawns explosion and destroys missile
    private void MissileExplode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Destroy(collision.gameObject);
    }
}
