using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemyChaser;

    public GameObject pirateEnemy;

    public GameObject whirlPool;

    public GameObject monster;

    public Transform[] SpawnPositions;

    private List<Vector2> spawnPoints = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnChaser");
        StartCoroutine("SpawnPirate");
        StartCoroutine("SpawnWhirlPool");
        StartCoroutine("SpawnMonster");
    }

    IEnumerator SpawnChaser() {
        int index = Random.Range(0,16);
        Instantiate(enemyChaser,SpawnPositions[index].transform.position,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnChaser");
    }

    IEnumerator SpawnPirate() {
        int index = Random.Range(0,16);
        Instantiate(pirateEnemy,SpawnPositions[index].transform.position,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnPirate");
    }

    IEnumerator SpawnWhirlPool() {
        Vector2 point2D = generateVector();
        Vector3 spawnPoint = new Vector3(point2D.x, point2D.y, whirlPool.transform.position.z);
        Instantiate(whirlPool, spawnPoint ,Quaternion.identity);
        yield return new WaitForSeconds(5f);
        StartCoroutine("SpawnWhirlPool");
    }

    IEnumerator SpawnMonster() {
        Vector2 point2D = generateVector();
        Vector3 spawnPoint = new Vector3(point2D.x, point2D.y, monster.transform.position.z);
        Instantiate(monster, spawnPoint ,Quaternion.identity);
        yield return new WaitForSeconds(5f);
        StartCoroutine("SpawnMonster");
    }

    Vector2 generateVector() {
        Vector2 point = new Vector2(Random.Range(-3.7f, 3.7f), Random.Range(-3.7f, 3.7f));

        bool valid = false; 
        
        while (!valid) {
            valid = true;
            foreach(Vector2 spawnP in spawnPoints) {
                if (Vector2.Distance(spawnP, point) < 1) {
                    valid = false;
                    break;
                }
            }
            if (!valid) point = new Vector2(Random.Range(-3.7f, 3.7f), Random.Range(-3.7f, 3.7f));
        }

        spawnPoints.Add(point);
        return point;
    }
}
