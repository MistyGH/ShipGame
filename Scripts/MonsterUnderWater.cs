using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnderWater : MonoBehaviour
{

    [SerializeField]
    private GameObject seaMonster;

    private float damage = 0;

    [SerializeField]
    private float maxHealth;

    // Start is called before the first frame update
    
    public void setDamage(float _damage) {
        damage = _damage;
    }

    public float getMaxHealth() {
        return maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != null) {
            if (other.tag == "Player" || other.tag == "PirateShip") {
                Vector2 direction = other.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                GameObject seaMonst = Instantiate(seaMonster, transform.position, rotation);
                seaMonst.GetComponentInChildren<MonsterBody>().setTargetRotation(rotation);
                seaMonst.GetComponentInChildren<MonsterBody>().setTargetBody(other);
                seaMonst.GetComponentInChildren<Enemy>().takeDamage(damage);
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}
