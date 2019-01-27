using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> spawnPrefabPool = new List<GameObject>();
    public Transform spawnPoint;

    public float spawnDelay = 1;//how many seconds between each spawn
    public Vector2 defaultInitialDirection = Vector2.down;
    public float defaultDestroyDelay = 1.0f;
    public float defaultDestroySpeed = 0.1f;

    private float lastSpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoint == null)
        {
            spawnPoint = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnTime + spawnDelay)
        {
            lastSpawnTime = Time.time;
            GameObject spawnPrefab = spawnPrefabPool[Random.Range(0, spawnPrefabPool.Count)];
            GameObject spawn = Instantiate(spawnPrefab);
            spawn.transform.position = spawnPoint.position;
            SpawnedObject so = spawn.GetComponent<SpawnedObject>();
            if (so == null)
            {
                so = spawn.AddComponent<SpawnedObject>();
                so.initialDirection = defaultInitialDirection;
            }
            if (so.initialDirection == Vector2.zero)
            {
                so.initialDirection = defaultInitialDirection;
            }
            if (so.destroyDelay == 0)
            {
                so.destroyDelay = defaultDestroyDelay;
            }
            if (so.destroySpeed == 0)
            {
                so.destroySpeed = defaultDestroySpeed;
            }
            Rigidbody2D spawnRB2D = spawn.GetComponent<Rigidbody2D>();
            spawnRB2D.velocity = so.initialDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnedObject so = collision.gameObject.GetComponent<SpawnedObject>();
        if (so)
        {
            so.destroy();
        }
    }
}
