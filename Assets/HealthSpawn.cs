using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    public GameObject health;
    public float spawnRate = 10;
    private float time = 0;
    public Vector3 spawnPos1;
    public Vector3 spawnPos2;
    private Vector3 spawnPos;
    public float spawningDistance = 5f;
    public Transform player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnRate)
        {
            spawnPos.x = Random.Range(spawnPos1.x, spawnPos2.x);
            spawnPos.y = Random.Range(spawnPos1.y, spawnPos2.y);
            float dist = Vector3.Distance(spawnPos, player.position);
            if (dist > spawningDistance)
            {
                GameObject clone = Instantiate(health, spawnPos, transform.rotation);
                time = 0;
            }

        }
    }
}
