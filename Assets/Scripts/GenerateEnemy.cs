using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnPoint;

    public int xPos;
    public int yPos;

    public int enemyCount = 3;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 1000) {
        	xPos = Random.Range(1,10);
        	yPos = Random.Range(1,10);
            

        	Instantiate(enemy, new Vector3(spawnPoint.transform.position.x + xPos, 43, spawnPoint.transform.position.y + yPos), Quaternion.identity);
        	enemyCount++;
        	print(enemyCount);
        }
    }
}
