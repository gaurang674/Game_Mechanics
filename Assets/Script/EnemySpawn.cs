using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float XspawnPosition;
    private float ZspawnPosition;
    private Vector3 spawnPosition;
    private int NoOfEnemy;
    public int waveNumber=1;
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {

    }

    void spawnEnemy(int numOfEnemy)
    {
        for(int i = 0; i<numOfEnemy; i++)
        {
            Instantiate(enemyPrefab,randomSpawn(),Quaternion.identity);
        }
    }

    private Vector3 randomSpawn()
    {
        XspawnPosition = Random.Range(-4f, 4f);
        ZspawnPosition = Random.Range(-3f, 3f);
        spawnPosition = new Vector3(XspawnPosition, 0, ZspawnPosition);
        return spawnPosition;
    }
    // Update is called once per frame
    void Update()
    {
        NoOfEnemy = FindObjectsOfType<Enemy>().Length;
        if(NoOfEnemy == 0)
        {
            waveNumber++;
            spawnEnemy(waveNumber);
            Instantiate(powerUp, randomSpawn() + new Vector3(0, -0.7f,0), Quaternion.identity);
        }
    }
}
