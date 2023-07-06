using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallCollision : MonoBehaviour
{

    [SerializeField]
    private float damage;

    [SerializeField]
    private bool enemyCanonBall;

    public float canonBallSpeed = 0;

    void Update() {
        transform.position += transform.right * canonBallSpeed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Whirlpool" && other.tag != "SeaMonster" && other.tag != "DarkWater")  {
            if (other.tag == "Player" && enemyCanonBall) Destroy(gameObject);
            if (other.tag == "PirateShip" && !enemyCanonBall) Destroy(gameObject);
            if (other.tag != "Player" && other.tag != "PirateShip") Destroy(gameObject);
            if (other.GetComponent<Enemy>() != null && !enemyCanonBall) other.GetComponent<Enemy>().takeDamage(damage);
            if (other.tag == "Player" && enemyCanonBall) {
                other.GetComponent<PlayerHealth>().takeDamage(damage);
            }
        }
    }
}
