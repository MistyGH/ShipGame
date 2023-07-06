using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    private Vector2[] piratePoints = new Vector2[3];
    private Vector2 p1;
    private Vector2 p2;
    private float InterpAmount = 0;
    private float speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        GenerateNextThreePoints();
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip(Time.deltaTime);
    }

    void GenerateNextThreePoints() 
    {
        for (int i = 0; i < 3; i ++) 
        {
            float minDistance = 2;
            float x = Random.Range(-4.0f, 4.0f);
            float y = Random.Range(-4.0f, 4.0f);
            Vector2 point = new Vector2(x, y);
            if (i > 0 && i < 2) {
                while (!(Vector2.Distance(piratePoints[i-1], point) > minDistance)) {
                    x = Random.Range(-4.0f, 4.0f);
                    y = Random.Range(-4.0f, 4.0f);
                    point = new Vector2(x, y);
                }
            }
            piratePoints[i] = point;
        }
    }

    Vector2 GenerateRandomPoint(Vector2 previousPoint)
    {
        float minDistance = 2;
        float x = Random.Range(-4.0f, 4.0f);
        float y = Random.Range(-4.0f, 4.0f);
        Vector2 point = new Vector2(x, y);
        while (!(Vector2.Distance(previousPoint, point) > minDistance)) {
            x = Random.Range(-4.0f, 4.0f);
            y = Random.Range(-4.0f, 4.0f);
            point = new Vector2(x, y);
        }
        return point;
    }

    void MoveShip(float timeDelta)
    {
        InterpAmount += timeDelta;
        p1 = Vector2.Lerp(piratePoints[0],piratePoints[1],InterpAmount*speed);
        p2 = Vector2.Lerp(piratePoints[1],piratePoints[2],InterpAmount*speed);

        transform.position = Vector2.Lerp(p1,p2,InterpAmount*speed);

        float turnAngle1 = Mathf.Atan2(p1.y,p1.x) * Mathf.Rad2Deg;
        Quaternion rotation1 = Quaternion.AngleAxis(turnAngle1, Vector3.forward);
        float turnAngle2 = Mathf.Atan2(p1.y,p1.x) * Mathf.Rad2Deg;
        Quaternion rotation2 = Quaternion.AngleAxis(turnAngle2, Vector3.forward);


        transform.rotation = Quaternion.Slerp(rotation1, rotation2, 100*Time.deltaTime);

        if (new Vector2(transform.position.x,transform.position.y) == piratePoints[2]) {
            piratePoints[0] = piratePoints[2];
            piratePoints[1] = GenerateRandomPoint(piratePoints[0]);
            piratePoints[2] = GenerateRandomPoint(piratePoints[1]);

            InterpAmount = 0;
        }
    }
}
