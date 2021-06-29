using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    [SerializeField]
    GameObject tileToSpawn;
    [SerializeField]
    GameObject referenceObject;
    [SerializeField]
    float timeOffset = 0.4f;
    [SerializeField]
    float randomValue = 0.8f;
    [SerializeField]
    float distanceBetweenTiles = 5.0f;
    [SerializeField]
    Vector3 previousTilePosition;
    [SerializeField]
    float startTime;
    [SerializeField]
    Vector3 direction, minDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
            {
                direction = minDirection;
            }
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                minDirection = direction;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;
        }
    }
}
