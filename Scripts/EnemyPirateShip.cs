using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirateShip : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2[] piratePoints = new Vector2[5];

    int step = 0;
    public int boatSpeed = 10;
    void Start()
    {
        for (int i = 0; i < 5; i ++) 
        {
            float minDistance = 2;
            float x = Random.Range(-4.0f, 4.0f);
            float y = Random.Range(-4.0f, 4.0f);
            Vector2 point = new Vector2(x, y);
            if (i > 0 && i < 4) {
                while (!(Vector2.Distance(piratePoints[i-1], point) > minDistance)) {
                    x = Random.Range(-4.0f, 4.0f);
                    y = Random.Range(-4.0f, 4.0f);
                    point = new Vector2(x, y);
                }
            }
            else if (i == 4) {
                while (!(Vector2.Distance(piratePoints[i-1], point) > minDistance) && (Vector2.Distance(piratePoints[0], point) > minDistance)) {
                    x = Random.Range(-4.0f, 4.0f);
                    y = Random.Range(-4.0f, 4.0f);
                    point = new Vector2(x, y);
                }
            }
            piratePoints[i] = point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveOneStep(Time.deltaTime);
    }

    void MoveOneStep(float timeDelta)
    {
        if (new Vector2(transform.position.x,transform.position.y) == piratePoints[0]) {
            step = 0;
        }
        if (new Vector2(transform.position.x,transform.position.y) == piratePoints[1]) {
            step = 1;
        }
        if (new Vector2(transform.position.x,transform.position.y) == piratePoints[2]) {
            step = 2;
        }
        if (new Vector2(transform.position.x,transform.position.y) == piratePoints[3]) {
            step = 3;
        }
        if (new Vector2(transform.position.x,transform.position.y) == piratePoints[4]) {
            step = 4;
        }
        if (step == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,piratePoints[1],boatSpeed*timeDelta);
        }
        if (step == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position,piratePoints[2],boatSpeed*timeDelta);
        }
        if (step == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position,piratePoints[3],boatSpeed*timeDelta);
        }
        if (step == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position,piratePoints[4],boatSpeed*timeDelta);
        }
        if (step == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position,piratePoints[0],boatSpeed*timeDelta);
        }

    }
}
