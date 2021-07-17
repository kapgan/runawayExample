using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    private int boslukRandom;
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
    private int boslukBirakildiMi=3;
    [SerializeField]
    Vector3 direction, minDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
    }

   
    private void FixedUpdate()
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
            if (previousTilePosition == spawnPos)
            {//üst üste gelmesi engellendi
                direction += new Vector3(1, 0, 0);
                spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            }
            previousTilePosition = spawnPos;
            startTime = Time.time;
            boslukRandom = Random.Range(1, 10);
            if(boslukRandom <= 5 || boslukBirakildiMi <= 3)
            {

               Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 90, 0));
                boslukBirakildiMi ++;
            }
            else
            {
                boslukBirakildiMi=0;
            }
          
        }

    }
}
